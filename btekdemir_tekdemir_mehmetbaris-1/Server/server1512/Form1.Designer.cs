namespace server1512
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
            this.server_actions = new System.Windows.Forms.RichTextBox();
            this.IF100 = new System.Windows.Forms.RichTextBox();
            this.SPS101 = new System.Windows.Forms.RichTextBox();
            this.connected_clients = new System.Windows.Forms.RichTextBox();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.label_port = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_IF100 = new System.Windows.Forms.Label();
            this.label_SPS101 = new System.Windows.Forms.Label();
            this.label_server_actions = new System.Windows.Forms.Label();
            this.Listen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // server_actions
            // 
            this.server_actions.Location = new System.Drawing.Point(288, 43);
            this.server_actions.Name = "server_actions";
            this.server_actions.Size = new System.Drawing.Size(219, 96);
            this.server_actions.TabIndex = 0;
            this.server_actions.Text = "";
            this.server_actions.TextChanged += new System.EventHandler(this.server_actions_TextChanged);
            // 
            // IF100
            // 
            this.IF100.Location = new System.Drawing.Point(288, 181);
            this.IF100.Name = "IF100";
            this.IF100.Size = new System.Drawing.Size(100, 136);
            this.IF100.TabIndex = 1;
            this.IF100.Text = "";
            // 
            // SPS101
            // 
            this.SPS101.Location = new System.Drawing.Point(407, 181);
            this.SPS101.Name = "SPS101";
            this.SPS101.Size = new System.Drawing.Size(100, 136);
            this.SPS101.TabIndex = 2;
            this.SPS101.Text = "";
            // 
            // connected_clients
            // 
            this.connected_clients.Location = new System.Drawing.Point(27, 117);
            this.connected_clients.Name = "connected_clients";
            this.connected_clients.Size = new System.Drawing.Size(220, 200);
            this.connected_clients.TabIndex = 3;
            this.connected_clients.Text = "";
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(60, 43);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(128, 20);
            this.textBox_port.TabIndex = 4;
            // 
            // label_port
            // 
            this.label_port.AutoSize = true;
            this.label_port.Location = new System.Drawing.Point(24, 46);
            this.label_port.Name = "label_port";
            this.label_port.Size = new System.Drawing.Size(32, 13);
            this.label_port.TabIndex = 5;
            this.label_port.Text = "Port: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Connected_clients";
            // 
            // label_IF100
            // 
            this.label_IF100.AutoSize = true;
            this.label_IF100.Location = new System.Drawing.Point(317, 165);
            this.label_IF100.Name = "label_IF100";
            this.label_IF100.Size = new System.Drawing.Size(34, 13);
            this.label_IF100.TabIndex = 7;
            this.label_IF100.Text = "IF100";
            // 
            // label_SPS101
            // 
            this.label_SPS101.AutoSize = true;
            this.label_SPS101.Location = new System.Drawing.Point(446, 165);
            this.label_SPS101.Name = "label_SPS101";
            this.label_SPS101.Size = new System.Drawing.Size(46, 13);
            this.label_SPS101.TabIndex = 8;
            this.label_SPS101.Text = "SPS101";
            // 
            // label_server_actions
            // 
            this.label_server_actions.AutoSize = true;
            this.label_server_actions.Location = new System.Drawing.Point(362, 27);
            this.label_server_actions.Name = "label_server_actions";
            this.label_server_actions.Size = new System.Drawing.Size(76, 13);
            this.label_server_actions.TabIndex = 9;
            this.label_server_actions.Text = "Server Actions";
            // 
            // Listen
            // 
            this.Listen.Location = new System.Drawing.Point(194, 43);
            this.Listen.Name = "Listen";
            this.Listen.Size = new System.Drawing.Size(75, 23);
            this.Listen.TabIndex = 10;
            this.Listen.Text = "Listen";
            this.Listen.UseVisualStyleBackColor = true;
            this.Listen.Click += new System.EventHandler(this.Listen_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 350);
            this.Controls.Add(this.Listen);
            this.Controls.Add(this.label_server_actions);
            this.Controls.Add(this.label_SPS101);
            this.Controls.Add(this.label_IF100);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_port);
            this.Controls.Add(this.textBox_port);
            this.Controls.Add(this.connected_clients);
            this.Controls.Add(this.SPS101);
            this.Controls.Add(this.IF100);
            this.Controls.Add(this.server_actions);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox server_actions;
        private System.Windows.Forms.RichTextBox IF100;
        private System.Windows.Forms.RichTextBox SPS101;
        private System.Windows.Forms.RichTextBox connected_clients;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.Label label_port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_IF100;
        private System.Windows.Forms.Label label_SPS101;
        private System.Windows.Forms.Label label_server_actions;
        private System.Windows.Forms.Button Listen;
    }
}

