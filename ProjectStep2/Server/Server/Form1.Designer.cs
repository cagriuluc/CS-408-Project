﻿namespace CS408_Servre
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
            this.port_text_box = new System.Windows.Forms.TextBox();
            this.listen_button = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // port_text_box
            // 
            this.port_text_box.Location = new System.Drawing.Point(44, 15);
            this.port_text_box.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.port_text_box.Name = "port_text_box";
            this.port_text_box.Size = new System.Drawing.Size(109, 22);
            this.port_text_box.TabIndex = 0;
            // 
            // listen_button
            // 
            this.listen_button.Location = new System.Drawing.Point(203, 15);
            this.listen_button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listen_button.Name = "listen_button";
            this.listen_button.Size = new System.Drawing.Size(100, 28);
            this.listen_button.TabIndex = 1;
            this.listen_button.Text = "Listen";
            this.listen_button.UseVisualStyleBackColor = true;
            this.listen_button.Click += new System.EventHandler(this.listen_button_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(44, 102);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(455, 294);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-3, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Activities";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 464);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.listen_button);
            this.Controls.Add(this.port_text_box);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox port_text_box;
        private System.Windows.Forms.Button listen_button;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

