namespace OnAirController
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onBtn = new System.Windows.Forms.Button();
            this.offBtn = new System.Windows.Forms.Button();
            this.brightness = new System.Windows.Forms.TrackBar();
            this.linkRecordingCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.serialNumberBox = new System.Windows.Forms.TextBox();
            this.productIdBox = new System.Windows.Forms.TextBox();
            this.vendorIdBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.brightness)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "ON AIR Controller";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(104, 48);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // onBtn
            // 
            this.onBtn.Location = new System.Drawing.Point(9, 20);
            this.onBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.onBtn.Name = "onBtn";
            this.onBtn.Size = new System.Drawing.Size(76, 20);
            this.onBtn.TabIndex = 2;
            this.onBtn.Text = "ON";
            this.onBtn.UseVisualStyleBackColor = true;
            this.onBtn.Click += new System.EventHandler(this.onBtn_Click);
            // 
            // offBtn
            // 
            this.offBtn.Location = new System.Drawing.Point(92, 20);
            this.offBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.offBtn.Name = "offBtn";
            this.offBtn.Size = new System.Drawing.Size(76, 20);
            this.offBtn.TabIndex = 3;
            this.offBtn.Text = "OFF";
            this.offBtn.UseVisualStyleBackColor = true;
            this.offBtn.Click += new System.EventHandler(this.offBtn_Click);
            // 
            // brightness
            // 
            this.brightness.LargeChange = 1;
            this.brightness.Location = new System.Drawing.Point(4, 44);
            this.brightness.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.brightness.Maximum = 255;
            this.brightness.Name = "brightness";
            this.brightness.Size = new System.Drawing.Size(445, 45);
            this.brightness.TabIndex = 4;
            this.brightness.Scroll += new System.EventHandler(this.brightness_Scroll);
            // 
            // linkRecordingCheckBox
            // 
            this.linkRecordingCheckBox.AutoSize = true;
            this.linkRecordingCheckBox.Checked = true;
            this.linkRecordingCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.linkRecordingCheckBox.Location = new System.Drawing.Point(4, 95);
            this.linkRecordingCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.linkRecordingCheckBox.Name = "linkRecordingCheckBox";
            this.linkRecordingCheckBox.Size = new System.Drawing.Size(131, 19);
            this.linkRecordingCheckBox.TabIndex = 6;
            this.linkRecordingCheckBox.Text = "Link with Recording";
            this.linkRecordingCheckBox.UseVisualStyleBackColor = true;
            this.linkRecordingCheckBox.CheckedChanged += new System.EventHandler(this.linkRecordingCheckBox_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.saveBtn);
            this.groupBox1.Controls.Add(this.serialNumberBox);
            this.groupBox1.Controls.Add(this.linkRecordingCheckBox);
            this.groupBox1.Controls.Add(this.productIdBox);
            this.groupBox1.Controls.Add(this.vendorIdBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 105);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(317, 122);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Config";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(232, 95);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(76, 20);
            this.saveBtn.TabIndex = 6;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // serialNumberBox
            // 
            this.serialNumberBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.serialNumberBox.Location = new System.Drawing.Point(92, 68);
            this.serialNumberBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.serialNumberBox.MaxLength = 32;
            this.serialNumberBox.Name = "serialNumberBox";
            this.serialNumberBox.ShortcutsEnabled = false;
            this.serialNumberBox.Size = new System.Drawing.Size(216, 23);
            this.serialNumberBox.TabIndex = 5;
            // 
            // productIdBox
            // 
            this.productIdBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.productIdBox.Location = new System.Drawing.Point(92, 41);
            this.productIdBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.productIdBox.MaxLength = 8;
            this.productIdBox.Name = "productIdBox";
            this.productIdBox.ShortcutsEnabled = false;
            this.productIdBox.Size = new System.Drawing.Size(104, 23);
            this.productIdBox.TabIndex = 4;
            // 
            // vendorIdBox
            // 
            this.vendorIdBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.vendorIdBox.Location = new System.Drawing.Point(92, 14);
            this.vendorIdBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.vendorIdBox.MaxLength = 8;
            this.vendorIdBox.Name = "vendorIdBox";
            this.vendorIdBox.ShortcutsEnabled = false;
            this.vendorIdBox.Size = new System.Drawing.Size(104, 23);
            this.vendorIdBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 71);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Serial Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Vendor ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product ID";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.onBtn);
            this.groupBox2.Controls.Add(this.offBtn);
            this.groupBox2.Controls.Add(this.brightness);
            this.groupBox2.Location = new System.Drawing.Point(7, 6);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(453, 95);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Manual";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 232);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "ON AIR Controller";
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.brightness)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private NotifyIcon notifyIcon;
        private ContextMenuStrip contextMenuStrip;
        private Button onBtn;
        private Button offBtn;
        private TrackBar brightness;
        private CheckBox linkRecordingCheckBox;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TextBox serialNumberBox;
        private TextBox productIdBox;
        private TextBox vendorIdBox;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button saveBtn;
    }
}