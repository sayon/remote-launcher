namespace remote_launcher
{
    partial class Launcher
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
            this.input_ip = new System.Windows.Forms.TextBox();
            this.label_input = new System.Windows.Forms.Label();
            this.button_listen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // input_ip
            // 
            this.input_ip.Location = new System.Drawing.Point(144, 9);
            this.input_ip.Name = "input_ip";
            this.input_ip.Size = new System.Drawing.Size(144, 20);
            this.input_ip.TabIndex = 0;
            this.input_ip.KeyDown += new System.Windows.Forms.KeyEventHandler(this.input_ip_KeyDown);
            // 
            // label_input
            // 
            this.label_input.AutoSize = true;
            this.label_input.Location = new System.Drawing.Point(13, 12);
            this.label_input.Name = "label_input";
            this.label_input.Size = new System.Drawing.Size(125, 13);
            this.label_input.TabIndex = 1;
            this.label_input.Text = "Input address to listen to:";
            // 
            // button_listen
            // 
            this.button_listen.Location = new System.Drawing.Point(312, 6);
            this.button_listen.Name = "button_listen";
            this.button_listen.Size = new System.Drawing.Size(89, 23);
            this.button_listen.TabIndex = 2;
            this.button_listen.Text = "Listen";
            this.button_listen.UseVisualStyleBackColor = true;
            this.button_listen.Click += new System.EventHandler(this.button_listen_Click);
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 38);
            this.Controls.Add(this.button_listen);
            this.Controls.Add(this.label_input);
            this.Controls.Add(this.input_ip);
            this.Name = "Launcher";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "RemoteLauncher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox input_ip;
        private System.Windows.Forms.Label label_input;
        private System.Windows.Forms.Button button_listen;
    }
}

