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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.IPinput = new System.Windows.Forms.TextBox();
            this.PortInput = new System.Windows.Forms.TextBox();
            this.playerCounter = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.InputMessageField = new System.Windows.Forms.TextBox();
            this.usernameInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.GameRate = new System.Windows.Forms.Timer(this.components);
            this.transparentCar1 = new WebsocketClient.TransparentCar();
            this.TextingField = new WebsocketClient.TransparentTextLog();
            this.transparentTextBoxField1 = new WebsocketClient.TransparentTextBoxField();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 50);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(800, 69);
            this.listBox1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(679, 26);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 19);
            this.button2.TabIndex = 3;
            this.button2.Text = "Connect";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(739, 26);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(72, 19);
            this.button3.TabIndex = 4;
            this.button3.Text = "Disconnect";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(410, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Server IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(573, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Port";
            // 
            // IPinput
            // 
            this.IPinput.Location = new System.Drawing.Point(467, 25);
            this.IPinput.Name = "IPinput";
            this.IPinput.Size = new System.Drawing.Size(100, 20);
            this.IPinput.TabIndex = 5;
            this.IPinput.Text = "127.0.0.1";
            // 
            // PortInput
            // 
            this.PortInput.Location = new System.Drawing.Point(605, 25);
            this.PortInput.Name = "PortInput";
            this.PortInput.Size = new System.Drawing.Size(55, 20);
            this.PortInput.TabIndex = 8;
            this.PortInput.Text = "8080";
            // 
            // playerCounter
            // 
            this.playerCounter.AutoSize = true;
            this.playerCounter.ForeColor = System.Drawing.Color.Black;
            this.playerCounter.Location = new System.Drawing.Point(640, 9);
            this.playerCounter.Name = "playerCounter";
            this.playerCounter.Size = new System.Drawing.Size(0, 13);
            this.playerCounter.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(12, 132);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(799, 174);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // InputMessageField
            // 
            this.InputMessageField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InputMessageField.Location = new System.Drawing.Point(1, 659);
            this.InputMessageField.Margin = new System.Windows.Forms.Padding(2);
            this.InputMessageField.Name = "InputMessageField";
            this.InputMessageField.Size = new System.Drawing.Size(1252, 13);
            this.InputMessageField.TabIndex = 17;
            this.InputMessageField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MessageInput_KeyDown);
            // 
            // usernameInput
            // 
            this.usernameInput.Location = new System.Drawing.Point(71, 24);
            this.usernameInput.Margin = new System.Windows.Forms.Padding(2);
            this.usernameInput.Name = "usernameInput";
            this.usernameInput.Size = new System.Drawing.Size(105, 20);
            this.usernameInput.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 26);
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
            // transparentCar1
            // 
            this.transparentCar1.Location = new System.Drawing.Point(261, 391);
            this.transparentCar1.Name = "transparentCar1";
            this.transparentCar1.Size = new System.Drawing.Size(100, 51);
            this.transparentCar1.TabIndex = 23;
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
            // transparentTextBoxField1
            // 
            this.transparentTextBoxField1.Location = new System.Drawing.Point(308, 529);
            this.transparentTextBoxField1.Name = "transparentTextBoxField1";
            this.transparentTextBoxField1.Size = new System.Drawing.Size(100, 20);
            this.transparentTextBoxField1.TabIndex = 24;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.transparentTextBoxField1);
            this.Controls.Add(this.transparentCar1);
            this.Controls.Add(this.TextingField);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.usernameInput);
            this.Controls.Add(this.InputMessageField);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.PortInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.playerCounter);
            this.Controls.Add(this.IPinput);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBox1);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox IPinput;
        private System.Windows.Forms.TextBox PortInput;
        private System.Windows.Forms.Label playerCounter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox InputMessageField;
        private System.Windows.Forms.TextBox usernameInput;
        private System.Windows.Forms.Label label3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private TransparentTextLog TextingField;
        private System.Windows.Forms.Timer GameRate;
        private TransparentCar transparentCar1;
        private TransparentTextBoxField transparentTextBoxField1;
    }
}

