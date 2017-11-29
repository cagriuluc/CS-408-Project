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
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.textBox_Username = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.button_Connect = new System.Windows.Forms.Button();
            this.button_Disconnect = new System.Windows.Forms.Button();
            this.button_List = new System.Windows.Forms.Button();
            this.textBox_Message = new System.Windows.Forms.TextBox();
            this.textBox_Invite = new System.Windows.Forms.TextBox();
            this.button_Send = new System.Windows.Forms.Button();
            this.button_Invite = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.player_list = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button_Surrender = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_IP
            // 
            this.textBox_IP.Location = new System.Drawing.Point(63, 12);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(100, 20);
            this.textBox_IP.TabIndex = 0;
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(63, 47);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(100, 20);
            this.textBox_Port.TabIndex = 1;
            // 
            // textBox_Username
            // 
            this.textBox_Username.Location = new System.Drawing.Point(63, 84);
            this.textBox_Username.Name = "textBox_Username";
            this.textBox_Username.Size = new System.Drawing.Size(100, 20);
            this.textBox_Username.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Activities";
            // 
            // richTextBox
            // 
            this.richTextBox.Location = new System.Drawing.Point(18, 154);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(337, 184);
            this.richTextBox.TabIndex = 7;
            this.richTextBox.Text = "";
            // 
            // button_Connect
            // 
            this.button_Connect.Location = new System.Drawing.Point(212, 10);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(75, 23);
            this.button_Connect.TabIndex = 8;
            this.button_Connect.Text = "Connect";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // button_Disconnect
            // 
            this.button_Disconnect.Location = new System.Drawing.Point(212, 45);
            this.button_Disconnect.Name = "button_Disconnect";
            this.button_Disconnect.Size = new System.Drawing.Size(75, 23);
            this.button_Disconnect.TabIndex = 9;
            this.button_Disconnect.Text = "Disconnect";
            this.button_Disconnect.UseVisualStyleBackColor = true;
            this.button_Disconnect.Click += new System.EventHandler(this.button_Disconnect_Click);
            // 
            // button_List
            // 
            this.button_List.Location = new System.Drawing.Point(212, 81);
            this.button_List.Name = "button_List";
            this.button_List.Size = new System.Drawing.Size(75, 23);
            this.button_List.TabIndex = 10;
            this.button_List.Text = "List Players";
            this.button_List.UseVisualStyleBackColor = true;
            this.button_List.Click += new System.EventHandler(this.button_List_Click);
            // 
            // textBox_Message
            // 
            this.textBox_Message.Location = new System.Drawing.Point(63, 354);
            this.textBox_Message.Name = "textBox_Message";
            this.textBox_Message.Size = new System.Drawing.Size(214, 20);
            this.textBox_Message.TabIndex = 11;
            this.textBox_Message.TextChanged += new System.EventHandler(this.textBox_Message_TextChanged);
            // 
            // textBox_Invite
            // 
            this.textBox_Invite.Location = new System.Drawing.Point(63, 390);
            this.textBox_Invite.Name = "textBox_Invite";
            this.textBox_Invite.Size = new System.Drawing.Size(214, 20);
            this.textBox_Invite.TabIndex = 12;
            // 
            // button_Send
            // 
            this.button_Send.Location = new System.Drawing.Point(283, 352);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(75, 23);
            this.button_Send.TabIndex = 13;
            this.button_Send.Text = "Send";
            this.button_Send.UseVisualStyleBackColor = true;
            this.button_Send.Click += new System.EventHandler(this.button_Send_Click);
            // 
            // button_Invite
            // 
            this.button_Invite.Location = new System.Drawing.Point(283, 390);
            this.button_Invite.Name = "button_Invite";
            this.button_Invite.Size = new System.Drawing.Size(75, 23);
            this.button_Invite.TabIndex = 14;
            this.button_Invite.Text = "Send";
            this.button_Invite.UseVisualStyleBackColor = true;
            this.button_Invite.Click += new System.EventHandler(this.button_Invite_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 357);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Message:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 395);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Invite";
            // 
            // player_list
            // 
            this.player_list.Location = new System.Drawing.Point(371, 87);
            this.player_list.Name = "player_list";
            this.player_list.Size = new System.Drawing.Size(139, 251);
            this.player_list.TabIndex = 17;
            this.player_list.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(368, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "List";
            // 
            // button_Surrender
            // 
            this.button_Surrender.Location = new System.Drawing.Point(403, 371);
            this.button_Surrender.Name = "button_Surrender";
            this.button_Surrender.Size = new System.Drawing.Size(75, 23);
            this.button_Surrender.TabIndex = 19;
            this.button_Surrender.Text = "Surrender";
            this.button_Surrender.UseVisualStyleBackColor = true;
            this.button_Surrender.Click += new System.EventHandler(this.button_Surrender_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 440);
            this.Controls.Add(this.button_Surrender);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.player_list);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button_Invite);
            this.Controls.Add(this.button_Send);
            this.Controls.Add(this.textBox_Invite);
            this.Controls.Add(this.textBox_Message);
            this.Controls.Add(this.button_List);
            this.Controls.Add(this.button_Disconnect);
            this.Controls.Add(this.button_Connect);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Username);
            this.Controls.Add(this.textBox_Port);
            this.Controls.Add(this.textBox_IP);
            this.Name = "Client";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.TextBox textBox_Username;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.Button button_Disconnect;
        private System.Windows.Forms.Button button_List;
        private System.Windows.Forms.TextBox textBox_Message;
        private System.Windows.Forms.TextBox textBox_Invite;
        private System.Windows.Forms.Button button_Send;
        private System.Windows.Forms.Button button_Invite;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox player_list;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_Surrender;
    }
}

