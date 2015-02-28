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
            this.rtbMessages.Location = new System.Drawing.Point(13, 43);
            this.rtbMessages.Name = "rtbMessages";
            this.rtbMessages.Size = new System.Drawing.Size(692, 381);
            this.rtbMessages.TabIndex = 1;
            this.rtbMessages.Text = "";
            // 
            // agwpeAPRS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 436);
            this.Controls.Add(this.rtbMessages);
            this.Controls.Add(this.btnMonitor);
            this.Name = "agwpeAPRS";
            this.Text = "AGWPE - APRS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.agwpeAPRS_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private AgwpePort.AgwpePort agwpePort1;
        private System.Windows.Forms.Button btnMonitor;
        private System.Windows.Forms.RichTextBox rtbMessages;
    }
}

