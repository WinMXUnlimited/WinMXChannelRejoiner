namespace WinMXChannelRejoiner
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.IconStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Button_Start = new System.Windows.Forms.Button();
            this.Button_Stop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.List_ChatRooms = new System.Windows.Forms.CheckedListBox();
            this.Timer_ChannelUpdater = new System.Windows.Forms.Timer(this.components);
            this.Combo_RejoinDuration = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Combo_MaximumAttempts = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.check_AutoStartOnStartup = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.IconStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainIcon
            // 
            this.MainIcon.ContextMenuStrip = this.IconStrip;
            this.MainIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("MainIcon.Icon")));
            this.MainIcon.Text = "WinMX Channel Rejoiner";
            this.MainIcon.Visible = true;
            this.MainIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MainIcon_MouseDoubleClick);
            // 
            // IconStrip
            // 
            this.IconStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.IconStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.hideToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.IconStrip.Name = "IconStrip";
            this.IconStrip.ShowImageMargin = false;
            this.IconStrip.Size = new System.Drawing.Size(124, 118);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(123, 36);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // hideToolStripMenuItem
            // 
            this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
            this.hideToolStripMenuItem.Size = new System.Drawing.Size(123, 36);
            this.hideToolStripMenuItem.Text = "Hide";
            this.hideToolStripMenuItem.Click += new System.EventHandler(this.hideToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(120, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(123, 36);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Button_Start
            // 
            this.Button_Start.Location = new System.Drawing.Point(24, 23);
            this.Button_Start.Margin = new System.Windows.Forms.Padding(6);
            this.Button_Start.Name = "Button_Start";
            this.Button_Start.Size = new System.Drawing.Size(362, 73);
            this.Button_Start.TabIndex = 1;
            this.Button_Start.Text = "Start";
            this.Button_Start.UseVisualStyleBackColor = true;
            this.Button_Start.Click += new System.EventHandler(this.Button_Start_Click);
            // 
            // Button_Stop
            // 
            this.Button_Stop.Enabled = false;
            this.Button_Stop.Location = new System.Drawing.Point(398, 23);
            this.Button_Stop.Margin = new System.Windows.Forms.Padding(6);
            this.Button_Stop.Name = "Button_Stop";
            this.Button_Stop.Size = new System.Drawing.Size(362, 73);
            this.Button_Stop.TabIndex = 2;
            this.Button_Stop.Text = "Stop";
            this.Button_Stop.UseVisualStyleBackColor = true;
            this.Button_Stop.Click += new System.EventHandler(this.Button_Stop_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(19, 583);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(741, 104);
            this.label1.TabIndex = 3;
            this.label1.Text = "Please make sure WinMX is set to hold windows open after parting. This can be fou" +
    "nd under the commands button.\r\n\r\nNote: Minimize this window to hide this app in " +
    "your system tray.\r\n";
            // 
            // List_ChatRooms
            // 
            this.List_ChatRooms.FormattingEnabled = true;
            this.List_ChatRooms.Location = new System.Drawing.Point(24, 105);
            this.List_ChatRooms.Name = "List_ChatRooms";
            this.List_ChatRooms.Size = new System.Drawing.Size(727, 264);
            this.List_ChatRooms.Sorted = true;
            this.List_ChatRooms.TabIndex = 4;
            this.List_ChatRooms.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.List_ChatRooms_ItemCheck);
            // 
            // Timer_ChannelUpdater
            // 
            this.Timer_ChannelUpdater.Enabled = true;
            this.Timer_ChannelUpdater.Interval = 2000;
            this.Timer_ChannelUpdater.Tick += new System.EventHandler(this.Timer_ChannelUpdater_Tick);
            // 
            // Combo_RejoinDuration
            // 
            this.Combo_RejoinDuration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo_RejoinDuration.FormattingEnabled = true;
            this.Combo_RejoinDuration.Items.AddRange(new object[] {
            "one",
            "two",
            "five",
            "ten"});
            this.Combo_RejoinDuration.Location = new System.Drawing.Point(302, 30);
            this.Combo_RejoinDuration.Name = "Combo_RejoinDuration";
            this.Combo_RejoinDuration.Size = new System.Drawing.Size(148, 33);
            this.Combo_RejoinDuration.TabIndex = 5;
            this.Combo_RejoinDuration.SelectedValueChanged += new System.EventHandler(this.Combo_RejoinDuration_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Attempt rejoining every";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(145, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "a maximum of ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(473, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "time(s) per hour.";
            // 
            // Combo_MaximumAttempts
            // 
            this.Combo_MaximumAttempts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo_MaximumAttempts.FormattingEnabled = true;
            this.Combo_MaximumAttempts.Items.AddRange(new object[] {
            "one",
            "five",
            "ten",
            "twenty",
            "unlimited"});
            this.Combo_MaximumAttempts.Location = new System.Drawing.Point(302, 78);
            this.Combo_MaximumAttempts.Name = "Combo_MaximumAttempts";
            this.Combo_MaximumAttempts.Size = new System.Drawing.Size(148, 33);
            this.Combo_MaximumAttempts.TabIndex = 9;
            this.Combo_MaximumAttempts.SelectedValueChanged += new System.EventHandler(this.Combo_MaximumAttempts_SelectedValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.check_AutoStartOnStartup);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.Combo_MaximumAttempts);
            this.groupBox1.Controls.Add(this.Combo_RejoinDuration);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(24, 385);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(727, 177);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // check_AutoStartOnStartup
            // 
            this.check_AutoStartOnStartup.AutoSize = true;
            this.check_AutoStartOnStartup.Location = new System.Drawing.Point(21, 133);
            this.check_AutoStartOnStartup.Name = "check_AutoStartOnStartup";
            this.check_AutoStartOnStartup.Size = new System.Drawing.Size(670, 29);
            this.check_AutoStartOnStartup.TabIndex = 11;
            this.check_AutoStartOnStartup.Text = "Automatically open and start the rejoiner when windows boots up.";
            this.check_AutoStartOnStartup.UseVisualStyleBackColor = true;
            this.check_AutoStartOnStartup.CheckStateChanged += new System.EventHandler(this.check_AutoStartOnStartup_CheckStateChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(473, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "minute(s)";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 696);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.List_ChatRooms);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Button_Stop);
            this.Controls.Add(this.Button_Start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "WinMX Channel Rejoiner v1.1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.IconStrip.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon MainIcon;
        private System.Windows.Forms.ContextMenuStrip IconStrip;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button Button_Start;
        private System.Windows.Forms.Button Button_Stop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox List_ChatRooms;
        private System.Windows.Forms.Timer Timer_ChannelUpdater;
        private System.Windows.Forms.ComboBox Combo_RejoinDuration;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox Combo_MaximumAttempts;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox check_AutoStartOnStartup;
    }
}

