using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System.IO;


namespace Bluetooth.Chat
{
    public partial class Form1 : Form
    {

        List<string> items;
        public Form1()
        {
            items = new List<string>();
            InitializeComponent();
        }

        private void bGo_Click(object sender, EventArgs e)
        {
            if (serverStarted)
            {
                updateUI("Servidor já iniciado!");
                return;
            }
            if (rbClient.Checked)
            {
                startScan();
            }
            else
            {
                connectAsServer();
            }
        }


        private void startScan()
        {
            listBox1.DataSource = null;
            listBox1.Items.Clear();
            items.Clear();
            Thread bluetoothScanThread = new Thread(new ThreadStart(scan));
            bluetoothScanThread.Start();
        }
        BluetoothDeviceInfo[] devices;
        private void scan()
        {

            updateUI("Iniciando scaneamento..");
            BluetoothClient client = new BluetoothClient();
            devices = client.DiscoverDevicesInRange();
            updateUI("Scaneamento completo");
            updateUI(devices.Length.ToString()+" despositivos descobertos");
            foreach (BluetoothDeviceInfo d in devices)
            {
                items.Add(d.DeviceName);
            }

            updateDeviceList();
        }

        private void connectAsServer()
        {
            Thread bluetoothServerThread = new Thread(new ThreadStart(ServerConnectThread));
            bluetoothServerThread.Start();
        }

        private void connectAsClient()
        {
            throw new NotImplementedException();
        }

        Guid mUUID = new Guid("00001101-0000-1000-8000-00805F9B34FB");
        bool serverStarted = false;
        public void ServerConnectThread()
        {
            updateUI("Server iniciado...");
            serverStarted = true;

            while (true)
            {
                updateUI("Aguardando por clientes...");
                BluetoothListener blueListener = new BluetoothListener(mUUID);
                blueListener.Start();
                BluetoothClient conn = blueListener.AcceptBluetoothClient();
                updateUI("Cliente conectado");

                Stream mStream = conn.GetStream();
                var connected = true;
                while (connected)
                {
                    try
                    {
                        //handle server connection
                        byte[] received = new byte[1024];
                        mStream.Read(received, 0, received.Length);
                        updateUI("Recebido: " + Encoding.ASCII.GetString(received) + Environment.NewLine);
                        byte[] sent = Encoding.ASCII.GetBytes("Mensagem recebida!");
                        mStream.Write(sent, 0, sent.Length);
                    }
                    catch (IOException)
                    {
                        updateUI("Cliente foi desconectado!");
                        connected = false;
                    }
                }
            }
        }

        private void updateUI(string message)
        {
            Func<int> del = delegate()
            {
                tbOutput.AppendText(message + System.Environment.NewLine);
                return 0;
            };
            Invoke(del);
        }

        private void updateDeviceList()
        {
            Func<int> del = delegate()
            {
                listBox1.DataSource = items;
                return 0;
            };
            Invoke(del);
        }


        BluetoothDeviceInfo deviceInfo;
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            deviceInfo = devices.ElementAt(listBox1.SelectedIndex);
            updateUI(deviceInfo.DeviceName + " foi selecionado, tentando se conectar");

            if (pairDevice())
            {
                updateUI("Pariando dispositivos...");
                updateUI("Iniciando thread de conexão...");
                Thread bluetoothClientThread = new Thread(new ThreadStart(ClientConnectThread));
                bluetoothClientThread.Start();
            }
            else
            {
                updateUI("Falha no pariamento!");
            }
        }

        private void ClientConnectThread()
        {
            BluetoothClient client = new BluetoothClient();
            updateUI("Tentando conexão...");
            client.BeginConnect(deviceInfo.DeviceAddress, mUUID, this.BluetoothClientConnectCallback, client);
        }

        void BluetoothClientConnectCallback(IAsyncResult result)
        {
            BluetoothClient client = (BluetoothClient)result.AsyncState;
            client.EndConnect(result);

            Stream stream = client.GetStream();
            stream.ReadTimeout = 1000;

            updateUI("Conexão efetuado com sucesso!");
            while (true)
            {
                while (!ready) ;

                stream.Write(message, 0, message.Length);
                updateUI($"Enviado: {message}");
                ready = false;
            }

        }

        string myPin = "1234";
        private bool pairDevice()
        {
            if (!deviceInfo.Authenticated)
            {
                if (!BluetoothSecurity.PairRequest(deviceInfo.DeviceAddress, myPin))
                {
                    return false;
                }
            }
            return true;
        }


        bool ready = false;
        byte[] message;
        private void tbText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                message = Encoding.ASCII.GetBytes(tbText.Text);
                ready = true;
                tbText.Clear();
            }
        }
    }
}
