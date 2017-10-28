namespace Client
{
    partial class Client
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
            this.tbServerIP = new System.Windows.Forms.TextBox();
            this.tbPortID = new System.Windows.Forms.TextBox();
            this.tbConnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.tbSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbServerIP
            // 
            this.tbServerIP.Location = new System.Drawing.Point(12, 30);
            this.tbServerIP.Name = "tbServerIP";
            this.tbServerIP.Size = new System.Drawing.Size(100, 20);
            this.tbServerIP.TabIndex = 0;
            // 
            // tbPortID
            // 
            this.tbPortID.Location = new System.Drawing.Point(118, 30);
            this.tbPortID.Name = "tbPortID";
            this.tbPortID.Size = new System.Drawing.Size(100, 20);
            this.tbPortID.TabIndex = 1;
            // 
            // tbConnect
            // 
            this.tbConnect.Location = new System.Drawing.Point(257, 30);
            this.tbConnect.Name = "tbConnect";
            this.tbConnect.Size = new System.Drawing.Size(75, 23);
            this.tbConnect.TabIndex = 2;
            this.tbConnect.Text = "Connect";
            this.tbConnect.UseVisualStyleBackColor = true;
            this.tbConnect.Click += new System.EventHandler(this.tbConnect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Server IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // tbMessage
            // 
            this.tbMessage.Location = new System.Drawing.Point(16, 266);
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(230, 20);
            this.tbMessage.TabIndex = 5;
            this.tbMessage.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // tbSend
            // 
            this.tbSend.Location = new System.Drawing.Point(252, 263);
            this.tbSend.Name = "tbSend";
            this.tbSend.Size = new System.Drawing.Size(75, 23);
            this.tbSend.TabIndex = 6;
            this.tbSend.Text = "Send";
            this.tbSend.UseVisualStyleBackColor = true;
            this.tbSend.Click += new System.EventHandler(this.tbSend_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 309);
            this.Controls.Add(this.tbSend);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbConnect);
            this.Controls.Add(this.tbPortID);
            this.Controls.Add(this.tbServerIP);
            this.Name = "Client";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbServerIP;
        private System.Windows.Forms.TextBox tbPortID;
        private System.Windows.Forms.Button tbConnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.Button tbSend;
    }
}

