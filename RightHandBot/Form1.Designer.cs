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
            ltxChatMemberShip = new ListBox();
            groupBox1 = new GroupBox();
            txtChat = new TextBox();
            btnDeleteChat = new Button();
            btnAddChat = new Button();
            toolStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
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
            btnStop.Click += btnStop_Click;
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
            // ltxChatMemberShip
            // 
            ltxChatMemberShip.FormattingEnabled = true;
            ltxChatMemberShip.ItemHeight = 20;
            ltxChatMemberShip.Location = new Point(6, 26);
            ltxChatMemberShip.Name = "ltxChatMemberShip";
            ltxChatMemberShip.Size = new Size(194, 104);
            ltxChatMemberShip.TabIndex = 4;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtChat);
            groupBox1.Controls.Add(ltxChatMemberShip);
            groupBox1.Controls.Add(btnDeleteChat);
            groupBox1.Controls.Add(btnAddChat);
            groupBox1.Location = new Point(12, 46);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(212, 210);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Chat Memberships";
            // 
            // txtChat
            // 
            txtChat.Location = new Point(6, 136);
            txtChat.Name = "txtChat";
            txtChat.Size = new Size(194, 27);
            txtChat.TabIndex = 6;
            txtChat.Text = "@";
            // 
            // btnDeleteChat
            // 
            btnDeleteChat.ForeColor = Color.DarkRed;
            btnDeleteChat.Location = new Point(106, 169);
            btnDeleteChat.Name = "btnDeleteChat";
            btnDeleteChat.Size = new Size(94, 29);
            btnDeleteChat.TabIndex = 2;
            btnDeleteChat.Text = "Delete";
            btnDeleteChat.UseVisualStyleBackColor = true;
            btnDeleteChat.Click += btnDeleteChat_Click;
            // 
            // btnAddChat
            // 
            btnAddChat.ForeColor = Color.ForestGreen;
            btnAddChat.Location = new Point(6, 169);
            btnAddChat.Name = "btnAddChat";
            btnAddChat.Size = new Size(94, 29);
            btnAddChat.TabIndex = 2;
            btnAddChat.Text = "Add";
            btnAddChat.UseVisualStyleBackColor = true;
            btnAddChat.Click += btnAddChat_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(785, 364);
            Controls.Add(groupBox1);
            Controls.Add(toolStrip1);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(cmxToken);
            Font = new Font("Proxima Soft", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Right Hand";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmxToken;
        private Button btnStart;
        private Button btnStop;
        private ToolStrip toolStrip1;
        private ToolStripLabel lblStatus;
        private ListBox ltxChatMemberShip;
        private GroupBox groupBox1;
        private TextBox txtChat;
        private Button btnDeleteChat;
        private Button btnAddChat;
    }
}