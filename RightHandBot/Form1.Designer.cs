namespace RightHandBot
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            cmxToken = new ComboBox();
            btnStart = new Button();
            btnStop = new Button();
            toolStrip1 = new ToolStrip();
            lblStatus = new ToolStripLabel();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // cmxToken
            // 
            cmxToken.FormattingEnabled = true;
            cmxToken.Location = new Point(12, 12);
            cmxToken.Name = "cmxToken";
            cmxToken.Size = new Size(563, 28);
            cmxToken.TabIndex = 1;
            // 
            // btnStart
            // 
            btnStart.ForeColor = Color.ForestGreen;
            btnStart.Location = new Point(581, 11);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(94, 29);
            btnStart.TabIndex = 2;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.ForeColor = Color.DarkRed;
            btnStop.Location = new Point(681, 11);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(94, 29);
            btnStop.TabIndex = 2;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.Bottom;
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { lblStatus });
            toolStrip1.Location = new Point(0, 339);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(785, 25);
            toolStrip1.TabIndex = 3;
            toolStrip1.Text = "toolStrip1";
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Proxima Soft", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            lblStatus.ForeColor = Color.DarkRed;
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(58, 22);
            lblStatus.Text = "Offline";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(785, 364);
            Controls.Add(toolStrip1);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(cmxToken);
            Font = new Font("Proxima Soft", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Right Hand";
            Load += Form1_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmxToken;
        private Button btnStart;
        private Button btnStop;
        private ToolStrip toolStrip1;
        private ToolStripLabel lblStatus;
    }
}