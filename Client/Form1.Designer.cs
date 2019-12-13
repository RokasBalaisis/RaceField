namespace WebsocketClient
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
            this.components = new System.ComponentModel.Container();
            this.ConnectBTN = new System.Windows.Forms.Button();
            this.DisconnectBTN = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.IPinput = new System.Windows.Forms.TextBox();
            this.PortInput = new System.Windows.Forms.TextBox();
            this.playerCounter = new System.Windows.Forms.Label();
            this.usernameInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.GameRate = new System.Windows.Forms.Timer(this.components);
            this.MainMenuPanel = new System.Windows.Forms.Panel();
            this.DBPanel = new System.Windows.Forms.Panel();
            this.DBPanelCnnectBTN = new System.Windows.Forms.Button();
            this.DBPanelPassLabel = new System.Windows.Forms.Label();
            this.DBPanelUNameLabel = new System.Windows.Forms.Label();
            this.DBPanelPassField = new System.Windows.Forms.TextBox();
            this.DBPanelUNameField = new System.Windows.Forms.TextBox();
            this.DBPanelName = new System.Windows.Forms.Label();
            this.MainMenuTitle = new System.Windows.Forms.Label();
            this.DebugLogField = new WebsocketClient.TransparentTextLog();
            this.InputMessageField = new WebsocketClient.TransparentTextLog();
            this.TextingField = new WebsocketClient.TransparentTextLog();
            this.MainMenuPanel.SuspendLayout();
            this.DBPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConnectBTN
            // 
            this.ConnectBTN.Location = new System.Drawing.Point(84, 240);
            this.ConnectBTN.Margin = new System.Windows.Forms.Padding(2);
            this.ConnectBTN.Name = "ConnectBTN";
            this.ConnectBTN.Size = new System.Drawing.Size(56, 19);
            this.ConnectBTN.TabIndex = 3;
            this.ConnectBTN.Text = "Connect";
            this.ConnectBTN.UseVisualStyleBackColor = true;
            this.ConnectBTN.Click += new System.EventHandler(this.ConnectBTN_Click);
            // 
            // DisconnectBTN
            // 
            this.DisconnectBTN.Location = new System.Drawing.Point(215, 240);
            this.DisconnectBTN.Margin = new System.Windows.Forms.Padding(2);
            this.DisconnectBTN.Name = "DisconnectBTN";
            this.DisconnectBTN.Size = new System.Drawing.Size(72, 19);
            this.DisconnectBTN.TabIndex = 4;
            this.DisconnectBTN.Text = "Disconnect";
            this.DisconnectBTN.UseVisualStyleBackColor = true;
            this.DisconnectBTN.Click += new System.EventHandler(this.DisconnectBTN_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Server IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Port";
            // 
            // IPinput
            // 
            this.IPinput.Location = new System.Drawing.Point(139, 127);
            this.IPinput.Name = "IPinput";
            this.IPinput.Size = new System.Drawing.Size(100, 20);
            this.IPinput.TabIndex = 5;
            this.IPinput.Text = "127.0.0.1";
            // 
            // PortInput
            // 
            this.PortInput.Location = new System.Drawing.Point(139, 165);
            this.PortInput.Name = "PortInput";
            this.PortInput.Size = new System.Drawing.Size(55, 20);
            this.PortInput.TabIndex = 8;
            this.PortInput.Text = "8080";
            // 
            // playerCounter
            // 
            this.playerCounter.AutoSize = true;
            this.playerCounter.ForeColor = System.Drawing.Color.Black;
            this.playerCounter.Location = new System.Drawing.Point(1180, 9);
            this.playerCounter.Name = "playerCounter";
            this.playerCounter.Size = new System.Drawing.Size(62, 13);
            this.playerCounter.TabIndex = 10;
            this.playerCounter.Text = "playercount";
            // 
            // usernameInput
            // 
            this.usernameInput.Location = new System.Drawing.Point(139, 88);
            this.usernameInput.Margin = new System.Windows.Forms.Padding(2);
            this.usernameInput.Name = "usernameInput";
            this.usernameInput.Size = new System.Drawing.Size(105, 20);
            this.usernameInput.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 91);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Username";
            // 
            // GameRate
            // 
            this.GameRate.Tick += new System.EventHandler(this.GameRate_Tick);
            // 
            // MainMenuPanel
            // 
            this.MainMenuPanel.Controls.Add(this.DBPanel);
            this.MainMenuPanel.Controls.Add(this.MainMenuTitle);
            this.MainMenuPanel.Controls.Add(this.usernameInput);
            this.MainMenuPanel.Controls.Add(this.label3);
            this.MainMenuPanel.Controls.Add(this.label1);
            this.MainMenuPanel.Controls.Add(this.IPinput);
            this.MainMenuPanel.Controls.Add(this.PortInput);
            this.MainMenuPanel.Controls.Add(this.DisconnectBTN);
            this.MainMenuPanel.Controls.Add(this.label2);
            this.MainMenuPanel.Controls.Add(this.ConnectBTN);
            this.MainMenuPanel.Location = new System.Drawing.Point(150, 70);
            this.MainMenuPanel.Name = "MainMenuPanel";
            this.MainMenuPanel.Size = new System.Drawing.Size(960, 540);
            this.MainMenuPanel.TabIndex = 25;
            this.MainMenuPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.MainMenuPanel_Paint);
            // 
            // DBPanel
            // 
            this.DBPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.DBPanel.Controls.Add(this.DBPanelCnnectBTN);
            this.DBPanel.Controls.Add(this.DBPanelPassLabel);
            this.DBPanel.Controls.Add(this.DBPanelUNameLabel);
            this.DBPanel.Controls.Add(this.DBPanelPassField);
            this.DBPanel.Controls.Add(this.DBPanelUNameField);
            this.DBPanel.Controls.Add(this.DBPanelName);
            this.DBPanel.Location = new System.Drawing.Point(292, 165);
            this.DBPanel.Name = "DBPanel";
            this.DBPanel.Size = new System.Drawing.Size(383, 238);
            this.DBPanel.TabIndex = 21;
            // 
            // DBPanelCnnectBTN
            // 
            this.DBPanelCnnectBTN.Location = new System.Drawing.Point(130, 188);
            this.DBPanelCnnectBTN.Name = "DBPanelCnnectBTN";
            this.DBPanelCnnectBTN.Size = new System.Drawing.Size(131, 23);
            this.DBPanelCnnectBTN.TabIndex = 5;
            this.DBPanelCnnectBTN.Text = "Login / Register";
            this.DBPanelCnnectBTN.UseVisualStyleBackColor = true;
            this.DBPanelCnnectBTN.Click += new System.EventHandler(this.DBPanelCnnectBTN_Click);
            // 
            // DBPanelPassLabel
            // 
            this.DBPanelPassLabel.AutoSize = true;
            this.DBPanelPassLabel.Location = new System.Drawing.Point(128, 140);
            this.DBPanelPassLabel.Name = "DBPanelPassLabel";
            this.DBPanelPassLabel.Size = new System.Drawing.Size(52, 13);
            this.DBPanelPassLabel.TabIndex = 4;
            this.DBPanelPassLabel.Text = "password";
            // 
            // DBPanelUNameLabel
            // 
            this.DBPanelUNameLabel.AutoSize = true;
            this.DBPanelUNameLabel.Location = new System.Drawing.Point(127, 97);
            this.DBPanelUNameLabel.Name = "DBPanelUNameLabel";
            this.DBPanelUNameLabel.Size = new System.Drawing.Size(53, 13);
            this.DBPanelUNameLabel.TabIndex = 3;
            this.DBPanelUNameLabel.Text = "username";
            // 
            // DBPanelPassField
            // 
            this.DBPanelPassField.Location = new System.Drawing.Point(197, 140);
            this.DBPanelPassField.Name = "DBPanelPassField";
            this.DBPanelPassField.Size = new System.Drawing.Size(100, 20);
            this.DBPanelPassField.TabIndex = 2;
            // 
            // DBPanelUNameField
            // 
            this.DBPanelUNameField.Location = new System.Drawing.Point(197, 94);
            this.DBPanelUNameField.Name = "DBPanelUNameField";
            this.DBPanelUNameField.Size = new System.Drawing.Size(100, 20);
            this.DBPanelUNameField.TabIndex = 1;
            // 
            // DBPanelName
            // 
            this.DBPanelName.AutoSize = true;
            this.DBPanelName.Location = new System.Drawing.Point(158, 28);
            this.DBPanelName.Name = "DBPanelName";
            this.DBPanelName.Size = new System.Drawing.Size(83, 13);
            this.DBPanelName.TabIndex = 0;
            this.DBPanelName.Text = "Login / Register";
            // 
            // MainMenuTitle
            // 
            this.MainMenuTitle.AutoSize = true;
            this.MainMenuTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuTitle.Location = new System.Drawing.Point(432, 33);
            this.MainMenuTitle.Name = "MainMenuTitle";
            this.MainMenuTitle.Size = new System.Drawing.Size(125, 25);
            this.MainMenuTitle.TabIndex = 0;
            this.MainMenuTitle.Text = "MAIN MENU";
            // 
            // DebugLogField
            // 
            this.DebugLogField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DebugLogField.Enabled = false;
            this.DebugLogField.Location = new System.Drawing.Point(12, -1);
            this.DebugLogField.Name = "DebugLogField";
            this.DebugLogField.ReadOnly = true;
            this.DebugLogField.Size = new System.Drawing.Size(988, 192);
            this.DebugLogField.TabIndex = 1;
            this.DebugLogField.Text = "";
            // 
            // InputMessageField
            // 
            this.InputMessageField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InputMessageField.Location = new System.Drawing.Point(2, 656);
            this.InputMessageField.Multiline = false;
            this.InputMessageField.Name = "InputMessageField";
            this.InputMessageField.Size = new System.Drawing.Size(1263, 25);
            this.InputMessageField.TabIndex = 24;
            this.InputMessageField.Text = "";
            this.InputMessageField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MessageInput_KeyDown);
            // 
            // TextingField
            // 
            this.TextingField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextingField.Location = new System.Drawing.Point(2, 462);
            this.TextingField.Name = "TextingField";
            this.TextingField.ReadOnly = true;
            this.TextingField.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.TextingField.Size = new System.Drawing.Size(1250, 196);
            this.TextingField.TabIndex = 22;
            this.TextingField.Text = "";
            this.TextingField.TextChanged += new System.EventHandler(this.TextingField_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::WebsocketClient.Properties.Resources.background1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.DebugLogField);
            this.Controls.Add(this.MainMenuPanel);
            this.Controls.Add(this.InputMessageField);
            this.Controls.Add(this.TextingField);
            this.Controls.Add(this.playerCounter);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.MainMenuPanel.ResumeLayout(false);
            this.MainMenuPanel.PerformLayout();
            this.DBPanel.ResumeLayout(false);
            this.DBPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ConnectBTN;
        private System.Windows.Forms.Button DisconnectBTN;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox IPinput;
        private System.Windows.Forms.TextBox PortInput;
        private System.Windows.Forms.Label playerCounter;
        private System.Windows.Forms.TextBox usernameInput;
        private System.Windows.Forms.Label label3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private TransparentTextLog TextingField;
        private System.Windows.Forms.Timer GameRate;
        private TransparentTextLog InputMessageField;
        private System.Windows.Forms.Panel MainMenuPanel;
        private System.Windows.Forms.Label MainMenuTitle;
        private System.Windows.Forms.Panel DBPanel;
        private System.Windows.Forms.Button DBPanelCnnectBTN;
        private System.Windows.Forms.Label DBPanelPassLabel;
        private System.Windows.Forms.Label DBPanelUNameLabel;
        private System.Windows.Forms.TextBox DBPanelPassField;
        private System.Windows.Forms.TextBox DBPanelUNameField;
        private System.Windows.Forms.Label DBPanelName;
        private TransparentTextLog DebugLogField;
    }
}

