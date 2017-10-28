namespace Server
{
    partial class Server
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
            this.messages = new System.Windows.Forms.ListBox();
            this.tbServerPort = new System.Windows.Forms.TextBox();
            this.tbListen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // messages
            // 
            this.messages.FormattingEnabled = true;
            this.messages.Location = new System.Drawing.Point(12, 27);
            this.messages.Name = "messages";
            this.messages.Size = new System.Drawing.Size(321, 212);
            this.messages.TabIndex = 0;
            // 
            // tbServerPort
            // 
            this.tbServerPort.Location = new System.Drawing.Point(12, 262);
            this.tbServerPort.Name = "tbServerPort";
            this.tbServerPort.Size = new System.Drawing.Size(148, 20);
            this.tbServerPort.TabIndex = 1;
            this.tbServerPort.TextChanged += new System.EventHandler(this.tbServerPort_TextChanged);
            // 
            // tbListen
            // 
            this.tbListen.Location = new System.Drawing.Point(217, 259);
            this.tbListen.Name = "tbListen";
            this.tbListen.Size = new System.Drawing.Size(116, 23);
            this.tbListen.TabIndex = 2;
            this.tbListen.Text = "Listen";
            this.tbListen.UseVisualStyleBackColor = true;
            this.tbListen.Click += new System.EventHandler(this.tbListen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Port";
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 317);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbListen);
            this.Controls.Add(this.tbServerPort);
            this.Controls.Add(this.messages);
            this.Name = "Server";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox messages;
        private System.Windows.Forms.TextBox tbServerPort;
        private System.Windows.Forms.Button tbListen;
        private System.Windows.Forms.Label label1;
    }
}

