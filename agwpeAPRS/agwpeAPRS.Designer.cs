namespace agwpeAPRS
{
    partial class agwpeAPRS
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
            this.agwpePort1 = new AgwpePort.AgwpePort(this.components);
            this.btnMonitor = new System.Windows.Forms.Button();
            this.rtbMessages = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.hostTextBox = new System.Windows.Forms.TextBox();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // agwpePort1
            // 
            this.agwpePort1.Host = "localhost";
            this.agwpePort1.Port = 8000;
            this.agwpePort1.RadioPort = ((byte)(0));
            this.agwpePort1.TimeOut = ((long)(3000));
            this.agwpePort1.FrameReceived += new AgwpePort.AgwpePort.AgwpeFrameReceivedEventHandler(this.agwpePort1_FrameReceived);
            // 
            // btnMonitor
            // 
            this.btnMonitor.Location = new System.Drawing.Point(13, 13);
            this.btnMonitor.Name = "btnMonitor";
            this.btnMonitor.Size = new System.Drawing.Size(75, 23);
            this.btnMonitor.TabIndex = 0;
            this.btnMonitor.Text = "Monitor";
            this.btnMonitor.UseVisualStyleBackColor = true;
            this.btnMonitor.Click += new System.EventHandler(this.btnMonitor_Click);
            // 
            // rtbMessages
            // 
            this.rtbMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbMessages.Location = new System.Drawing.Point(13, 43);
            this.rtbMessages.Name = "rtbMessages";
            this.rtbMessages.Size = new System.Drawing.Size(692, 381);
            this.rtbMessages.TabIndex = 1;
            this.rtbMessages.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "AGWPE Host:";
            // 
            // hostTextBox
            // 
            this.hostTextBox.Location = new System.Drawing.Point(190, 16);
            this.hostTextBox.Name = "hostTextBox";
            this.hostTextBox.Size = new System.Drawing.Size(198, 20);
            this.hostTextBox.TabIndex = 8;
            this.hostTextBox.Text = "localhost";
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(500, 15);
            this.portTextBox.MaxLength = 5;
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(49, 20);
            this.portTextBox.TabIndex = 11;
            this.portTextBox.Text = "8000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(422, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "AGWPE Port:";
            // 
            // agwpeAPRS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 436);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hostTextBox);
            this.Controls.Add(this.rtbMessages);
            this.Controls.Add(this.btnMonitor);
            this.Name = "agwpeAPRS";
            this.Text = "AGWPE - APRS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.agwpeAPRS_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AgwpePort.AgwpePort agwpePort1;
        private System.Windows.Forms.Button btnMonitor;
        private System.Windows.Forms.RichTextBox rtbMessages;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox hostTextBox;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Label label2;
    }
}

