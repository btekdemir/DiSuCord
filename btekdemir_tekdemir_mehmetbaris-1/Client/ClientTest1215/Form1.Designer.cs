namespace ClientTest1215
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
            this.actions = new System.Windows.Forms.RichTextBox();
            this.if_channel = new System.Windows.Forms.RichTextBox();
            this.sps_channel = new System.Windows.Forms.RichTextBox();
            this.ip = new System.Windows.Forms.TextBox();
            this.port = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.messagebox = new System.Windows.Forms.TextBox();
            this.sps_send = new System.Windows.Forms.Button();
            this.if_subscribe = new System.Windows.Forms.Button();
            this.sps_subscribe = new System.Windows.Forms.Button();
            this.if_send = new System.Windows.Forms.Button();
            this.connect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Disconnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // actions
            // 
            this.actions.Location = new System.Drawing.Point(342, 38);
            this.actions.Name = "actions";
            this.actions.Size = new System.Drawing.Size(252, 110);
            this.actions.TabIndex = 0;
            this.actions.Text = "";
            // 
            // if_channel
            // 
            this.if_channel.Location = new System.Drawing.Point(342, 182);
            this.if_channel.Name = "if_channel";
            this.if_channel.Size = new System.Drawing.Size(252, 119);
            this.if_channel.TabIndex = 1;
            this.if_channel.Text = "";
            // 
            // sps_channel
            // 
            this.sps_channel.Location = new System.Drawing.Point(342, 356);
            this.sps_channel.Name = "sps_channel";
            this.sps_channel.Size = new System.Drawing.Size(252, 126);
            this.sps_channel.TabIndex = 2;
            this.sps_channel.Text = "";
            // 
            // ip
            // 
            this.ip.Location = new System.Drawing.Point(144, 94);
            this.ip.Name = "ip";
            this.ip.Size = new System.Drawing.Size(100, 20);
            this.ip.TabIndex = 3;
            // 
            // port
            // 
            this.port.Location = new System.Drawing.Point(144, 179);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(100, 20);
            this.port.TabIndex = 4;
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(144, 266);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(100, 20);
            this.username.TabIndex = 5;
            // 
            // messagebox
            // 
            this.messagebox.Enabled = false;
            this.messagebox.Location = new System.Drawing.Point(68, 438);
            this.messagebox.Name = "messagebox";
            this.messagebox.Size = new System.Drawing.Size(232, 20);
            this.messagebox.TabIndex = 6;
            // 
            // sps_send
            // 
            this.sps_send.Enabled = false;
            this.sps_send.Location = new System.Drawing.Point(342, 488);
            this.sps_send.Name = "sps_send";
            this.sps_send.Size = new System.Drawing.Size(75, 23);
            this.sps_send.TabIndex = 7;
            this.sps_send.Text = "send";
            this.sps_send.UseVisualStyleBackColor = true;
            this.sps_send.Click += new System.EventHandler(this.sps_send_Click);
            // 
            // if_subscribe
            // 
            this.if_subscribe.Enabled = false;
            this.if_subscribe.Location = new System.Drawing.Point(519, 307);
            this.if_subscribe.Name = "if_subscribe";
            this.if_subscribe.Size = new System.Drawing.Size(75, 23);
            this.if_subscribe.TabIndex = 8;
            this.if_subscribe.Text = "subscribe";
            this.if_subscribe.UseVisualStyleBackColor = true;
            this.if_subscribe.Click += new System.EventHandler(this.if_subscribe_Click);
            // 
            // sps_subscribe
            // 
            this.sps_subscribe.Enabled = false;
            this.sps_subscribe.Location = new System.Drawing.Point(519, 488);
            this.sps_subscribe.Name = "sps_subscribe";
            this.sps_subscribe.Size = new System.Drawing.Size(75, 23);
            this.sps_subscribe.TabIndex = 9;
            this.sps_subscribe.Text = "subscribe";
            this.sps_subscribe.UseVisualStyleBackColor = true;
            this.sps_subscribe.Click += new System.EventHandler(this.sps_subscribe_Click);
            // 
            // if_send
            // 
            this.if_send.Enabled = false;
            this.if_send.Location = new System.Drawing.Point(342, 307);
            this.if_send.Name = "if_send";
            this.if_send.Size = new System.Drawing.Size(75, 23);
            this.if_send.TabIndex = 10;
            this.if_send.Text = "send";
            this.if_send.UseVisualStyleBackColor = true;
            this.if_send.Click += new System.EventHandler(this.if_send_Click);
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(85, 329);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(75, 23);
            this.connect.TabIndex = 11;
            this.connect.Text = "Connect";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(459, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Actions";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(459, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "IF100";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(459, 340);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "SPS101";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(65, 269);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Username:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(103, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "IP:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(54, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Port Number:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(167, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "DiSuCord";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(128, 404);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Write your message here!";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // Disconnect
            // 
            this.Disconnect.Enabled = false;
            this.Disconnect.Location = new System.Drawing.Point(169, 329);
            this.Disconnect.Name = "Disconnect";
            this.Disconnect.Size = new System.Drawing.Size(75, 23);
            this.Disconnect.TabIndex = 20;
            this.Disconnect.Text = "Disconnect";
            this.Disconnect.UseVisualStyleBackColor = true;
            this.Disconnect.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 514);
            this.Controls.Add(this.Disconnect);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.connect);
            this.Controls.Add(this.if_send);
            this.Controls.Add(this.sps_subscribe);
            this.Controls.Add(this.if_subscribe);
            this.Controls.Add(this.sps_send);
            this.Controls.Add(this.messagebox);
            this.Controls.Add(this.username);
            this.Controls.Add(this.port);
            this.Controls.Add(this.ip);
            this.Controls.Add(this.sps_channel);
            this.Controls.Add(this.if_channel);
            this.Controls.Add(this.actions);
            this.Name = "Form1";
            this.Text = "Port Number:";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox actions;
        private System.Windows.Forms.RichTextBox if_channel;
        private System.Windows.Forms.RichTextBox sps_channel;
        private System.Windows.Forms.TextBox ip;
        private System.Windows.Forms.TextBox port;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox messagebox;
        private System.Windows.Forms.Button sps_send;
        private System.Windows.Forms.Button if_subscribe;
        private System.Windows.Forms.Button sps_subscribe;
        private System.Windows.Forms.Button if_send;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button Disconnect;
    }
}

