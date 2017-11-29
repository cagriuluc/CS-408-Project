namespace CS408_Client
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
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.textBox_Username = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox_Message = new System.Windows.Forms.TextBox();
            this.textBox_Invite = new System.Windows.Forms.TextBox();
            this.button_Send = new System.Windows.Forms.Button();
            this.button_Invite = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.player_list = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_IP
            // 
            this.textBox_IP.Location = new System.Drawing.Point(72, 15);
            this.textBox_IP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(132, 22);
            this.textBox_IP.TabIndex = 0;
            this.textBox_IP.TextChanged += new System.EventHandler(this.textBox_IP_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP:";
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(72, 65);
            this.textBox_Port.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(132, 22);
            this.textBox_Port.TabIndex = 2;
            // 
            // textBox_Username
            // 
            this.textBox_Username.Location = new System.Drawing.Point(72, 116);
            this.textBox_Username.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_Username.Name = "textBox_Username";
            this.textBox_Username.Size = new System.Drawing.Size(132, 22);
            this.textBox_Username.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port #:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 119);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Name:";
            // 
            // richTextBox
            // 
            this.richTextBox.Location = new System.Drawing.Point(20, 170);
            this.richTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(437, 214);
            this.richTextBox.TabIndex = 6;
            this.richTextBox.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(359, 15);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 7;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(359, 68);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 8;
            this.button2.Text = "Disconnect";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(359, 116);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 28);
            this.button3.TabIndex = 9;
            this.button3.Text = "List Players";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // textBox_Message
            // 
            this.textBox_Message.Location = new System.Drawing.Point(72, 393);
            this.textBox_Message.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_Message.Name = "textBox_Message";
            this.textBox_Message.Size = new System.Drawing.Size(273, 22);
            this.textBox_Message.TabIndex = 10;
            // 
            // textBox_Invite
            // 
            this.textBox_Invite.Location = new System.Drawing.Point(72, 442);
            this.textBox_Invite.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_Invite.Name = "textBox_Invite";
            this.textBox_Invite.Size = new System.Drawing.Size(273, 22);
            this.textBox_Invite.TabIndex = 11;
            // 
            // button_Send
            // 
            this.button_Send.Location = new System.Drawing.Point(359, 389);
            this.button_Send.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(100, 28);
            this.button_Send.TabIndex = 12;
            this.button_Send.Text = "Send";
            this.button_Send.UseVisualStyleBackColor = true;
            // 
            // button_Invite
            // 
            this.button_Invite.Location = new System.Drawing.Point(359, 442);
            this.button_Invite.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Invite.Name = "button_Invite";
            this.button_Invite.Size = new System.Drawing.Size(100, 28);
            this.button_Invite.TabIndex = 13;
            this.button_Invite.Text = "Send";
            this.button_Invite.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-3, 399);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Message:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 444);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Invite:";
            // 
            // player_list
            // 
            this.player_list.Location = new System.Drawing.Point(467, 87);
            this.player_list.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.player_list.Name = "player_list";
            this.player_list.Size = new System.Drawing.Size(181, 329);
            this.player_list.TabIndex = 16;
            this.player_list.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(467, 65);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "List of Players";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 150);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 17);
            this.label7.TabIndex = 18;
            this.label7.Text = "Activities";
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 535);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.player_list);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button_Invite);
            this.Controls.Add(this.button_Send);
            this.Controls.Add(this.textBox_Invite);
            this.Controls.Add(this.textBox_Message);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_Username);
            this.Controls.Add(this.textBox_Port);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_IP);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Client";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Client_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.TextBox textBox_Username;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox_Message;
        private System.Windows.Forms.TextBox textBox_Invite;
        private System.Windows.Forms.Button button_Send;
        private System.Windows.Forms.Button button_Invite;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox player_list;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

