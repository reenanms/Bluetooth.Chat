namespace Bluetooth.Chat
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.tbText = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbServer = new System.Windows.Forms.RadioButton();
            this.rbClient = new System.Windows.Forms.RadioButton();
            this.bGo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbOutput
            // 
            this.tbOutput.Location = new System.Drawing.Point(10, 25);
            this.tbOutput.Multiline = true;
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.Size = new System.Drawing.Size(635, 271);
            this.tbOutput.TabIndex = 0;
            // 
            // tbText
            // 
            this.tbText.Location = new System.Drawing.Point(12, 346);
            this.tbText.Name = "tbText";
            this.tbText.Size = new System.Drawing.Size(876, 20);
            this.tbText.TabIndex = 1;
            this.tbText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbText_KeyPress);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(655, 149);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(231, 147);
            this.listBox1.TabIndex = 2;
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbServer);
            this.groupBox1.Controls.Add(this.rbClient);
            this.groupBox1.Location = new System.Drawing.Point(655, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(137, 75);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de conexão";
            // 
            // rbServer
            // 
            this.rbServer.AutoSize = true;
            this.rbServer.Checked = true;
            this.rbServer.Location = new System.Drawing.Point(5, 40);
            this.rbServer.Name = "rbServer";
            this.rbServer.Size = new System.Drawing.Size(56, 17);
            this.rbServer.TabIndex = 1;
            this.rbServer.TabStop = true;
            this.rbServer.Text = "Server";
            this.rbServer.UseVisualStyleBackColor = true;
            // 
            // rbClient
            // 
            this.rbClient.AutoSize = true;
            this.rbClient.Location = new System.Drawing.Point(5, 20);
            this.rbClient.Name = "rbClient";
            this.rbClient.Size = new System.Drawing.Size(51, 17);
            this.rbClient.TabIndex = 0;
            this.rbClient.Text = "Client";
            this.rbClient.UseVisualStyleBackColor = true;
            // 
            // bGo
            // 
            this.bGo.Location = new System.Drawing.Point(798, 12);
            this.bGo.Name = "bGo";
            this.bGo.Size = new System.Drawing.Size(88, 68);
            this.bGo.TabIndex = 4;
            this.bGo.Text = "INICIAR";
            this.bGo.UseVisualStyleBackColor = true;
            this.bGo.Click += new System.EventHandler(this.bGo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 327);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Mensagem para ser enviada, digite e clique enter:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(655, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Lista de dispositivos:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Informações:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 378);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bGo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.tbText);
            this.Controls.Add(this.tbOutput);
            this.Name = "Form1";
            this.Text = "Servicor \\ Cliente Bluetooth";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.TextBox tbText;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbServer;
        private System.Windows.Forms.RadioButton rbClient;
        private System.Windows.Forms.Button bGo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

