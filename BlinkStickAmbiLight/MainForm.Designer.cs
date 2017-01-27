/*
 * Created by SharpDevelop.
 * User: p0ke
 * Date: 24.10.2016
 * Time: 19:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace BlinkStickAmbiLight
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.grpBlinkStickSettings = new System.Windows.Forms.GroupBox();
			this.nud_brightness = new System.Windows.Forms.NumericUpDown();
			this.label8 = new System.Windows.Forms.Label();
			this.btnBasicColor = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.cb_ConnectFirst = new System.Windows.Forms.CheckBox();
			this.btnRefreshBS = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.grpRegions = new System.Windows.Forms.GroupBox();
			this.cbTransparent = new System.Windows.Forms.CheckBox();
			this.btnWhiteout = new System.Windows.Forms.Button();
			this.nud_shift = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.cbPreview = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.nud_size = new System.Windows.Forms.NumericUpDown();
			this.nud_right = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.nud_left = new System.Windows.Forms.NumericUpDown();
			this.nud_bottom = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.nud_top = new System.Windows.Forms.NumericUpDown();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.cms_NotifyIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mi_ShowSettings = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.mi_Exit = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tsAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.tsExit = new System.Windows.Forms.ToolStripMenuItem();
			this.grpScreenPreview = new System.Windows.Forms.GroupBox();
			this.lb_FPS = new System.Windows.Forms.Label();
			this.pbPreview = new System.Windows.Forms.PictureBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rbStaticColor = new System.Windows.Forms.RadioButton();
			this.rbAmbilightScreen = new System.Windows.Forms.RadioButton();
			this.rbAmbilightRegion = new System.Windows.Forms.RadioButton();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.grpBlinkStickSettings.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nud_brightness)).BeginInit();
			this.grpRegions.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nud_shift)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_size)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_right)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_left)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_bottom)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_top)).BeginInit();
			this.cms_NotifyIcon.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.grpScreenPreview.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpBlinkStickSettings
			// 
			this.grpBlinkStickSettings.Controls.Add(this.nud_brightness);
			this.grpBlinkStickSettings.Controls.Add(this.label8);
			this.grpBlinkStickSettings.Controls.Add(this.btnBasicColor);
			this.grpBlinkStickSettings.Controls.Add(this.label7);
			this.grpBlinkStickSettings.Controls.Add(this.cb_ConnectFirst);
			this.grpBlinkStickSettings.Controls.Add(this.btnRefreshBS);
			this.grpBlinkStickSettings.Controls.Add(this.comboBox1);
			this.grpBlinkStickSettings.Location = new System.Drawing.Point(12, 27);
			this.grpBlinkStickSettings.Name = "grpBlinkStickSettings";
			this.grpBlinkStickSettings.Size = new System.Drawing.Size(200, 129);
			this.grpBlinkStickSettings.TabIndex = 2;
			this.grpBlinkStickSettings.TabStop = false;
			this.grpBlinkStickSettings.Text = "Blinkstick Settings";
			// 
			// nud_brightness
			// 
			this.nud_brightness.Location = new System.Drawing.Point(147, 99);
			this.nud_brightness.Name = "nud_brightness";
			this.nud_brightness.Size = new System.Drawing.Size(43, 20);
			this.nud_brightness.TabIndex = 7;
			this.toolTip1.SetToolTip(this.nud_brightness, "LEDs at the bottom");
			this.nud_brightness.Value = new decimal(new int[] {
									100,
									0,
									0,
									0});
			this.nud_brightness.ValueChanged += new System.EventHandler(this.Nud_brightnessValueChanged);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(6, 101);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(73, 17);
			this.label8.TabIndex = 6;
			this.label8.Text = "Brightness:";
			// 
			// btnBasicColor
			// 
			this.btnBasicColor.BackColor = System.Drawing.Color.Red;
			this.btnBasicColor.Location = new System.Drawing.Point(131, 69);
			this.btnBasicColor.Name = "btnBasicColor";
			this.btnBasicColor.Size = new System.Drawing.Size(63, 21);
			this.btnBasicColor.TabIndex = 5;
			this.toolTip1.SetToolTip(this.btnBasicColor, "Refresh the device list");
			this.btnBasicColor.UseVisualStyleBackColor = false;
			this.btnBasicColor.Click += new System.EventHandler(this.BtnBasicColorClick);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(6, 73);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(73, 17);
			this.label7.TabIndex = 4;
			this.label7.Text = "Basic Color:";
			// 
			// cb_ConnectFirst
			// 
			this.cb_ConnectFirst.Checked = true;
			this.cb_ConnectFirst.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cb_ConnectFirst.Location = new System.Drawing.Point(7, 46);
			this.cb_ConnectFirst.Name = "cb_ConnectFirst";
			this.cb_ConnectFirst.Size = new System.Drawing.Size(149, 24);
			this.cb_ConnectFirst.TabIndex = 2;
			this.cb_ConnectFirst.Text = "Connect first device";
			this.toolTip1.SetToolTip(this.cb_ConnectFirst, "Connect the first found BlinkStick device");
			this.cb_ConnectFirst.UseVisualStyleBackColor = true;
			// 
			// btnRefreshBS
			// 
			this.btnRefreshBS.Location = new System.Drawing.Point(131, 19);
			this.btnRefreshBS.Name = "btnRefreshBS";
			this.btnRefreshBS.Size = new System.Drawing.Size(63, 21);
			this.btnRefreshBS.TabIndex = 1;
			this.btnRefreshBS.Text = "Refresh";
			this.toolTip1.SetToolTip(this.btnRefreshBS, "Refresh the device list");
			this.btnRefreshBS.UseVisualStyleBackColor = true;
			this.btnRefreshBS.Click += new System.EventHandler(this.BtnRefreshBSClick);
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(6, 19);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(101, 21);
			this.comboBox1.TabIndex = 0;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1SelectedIndexChanged);
			// 
			// grpRegions
			// 
			this.grpRegions.Controls.Add(this.cbTransparent);
			this.grpRegions.Controls.Add(this.btnWhiteout);
			this.grpRegions.Controls.Add(this.nud_shift);
			this.grpRegions.Controls.Add(this.label6);
			this.grpRegions.Controls.Add(this.cbPreview);
			this.grpRegions.Controls.Add(this.label5);
			this.grpRegions.Controls.Add(this.nud_size);
			this.grpRegions.Controls.Add(this.nud_right);
			this.grpRegions.Controls.Add(this.label3);
			this.grpRegions.Controls.Add(this.label4);
			this.grpRegions.Controls.Add(this.nud_left);
			this.grpRegions.Controls.Add(this.nud_bottom);
			this.grpRegions.Controls.Add(this.label2);
			this.grpRegions.Controls.Add(this.label1);
			this.grpRegions.Controls.Add(this.nud_top);
			this.grpRegions.Location = new System.Drawing.Point(12, 260);
			this.grpRegions.Name = "grpRegions";
			this.grpRegions.Size = new System.Drawing.Size(200, 181);
			this.grpRegions.TabIndex = 3;
			this.grpRegions.TabStop = false;
			this.grpRegions.Text = "Regions";
			// 
			// cbTransparent
			// 
			this.cbTransparent.Location = new System.Drawing.Point(7, 144);
			this.cbTransparent.Name = "cbTransparent";
			this.cbTransparent.Size = new System.Drawing.Size(144, 24);
			this.cbTransparent.TabIndex = 12;
			this.cbTransparent.Text = "Transparent Regions";
			this.cbTransparent.UseVisualStyleBackColor = true;
			// 
			// btnWhiteout
			// 
			this.btnWhiteout.Location = new System.Drawing.Point(131, 97);
			this.btnWhiteout.Name = "btnWhiteout";
			this.btnWhiteout.Size = new System.Drawing.Size(63, 21);
			this.btnWhiteout.TabIndex = 11;
			this.btnWhiteout.Text = "Whiteout";
			this.toolTip1.SetToolTip(this.btnWhiteout, "Turn the region colors to white for a better view");
			this.btnWhiteout.UseVisualStyleBackColor = true;
			this.btnWhiteout.Click += new System.EventHandler(this.Button1Click);
			// 
			// nud_shift
			// 
			this.nud_shift.Location = new System.Drawing.Point(147, 71);
			this.nud_shift.Maximum = new decimal(new int[] {
									200,
									0,
									0,
									0});
			this.nud_shift.Minimum = new decimal(new int[] {
									200,
									0,
									0,
									-2147483648});
			this.nud_shift.Name = "nud_shift";
			this.nud_shift.Size = new System.Drawing.Size(43, 20);
			this.nud_shift.TabIndex = 5;
			this.toolTip1.SetToolTip(this.nud_shift, "Shift the position of the first LED (USB connection)");
			this.nud_shift.ValueChanged += new System.EventHandler(this.Nud_shiftValueChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(95, 73);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(33, 20);
			this.label6.TabIndex = 10;
			this.label6.Text = "Shift:";
			// 
			// cbPreview
			// 
			this.cbPreview.Checked = true;
			this.cbPreview.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbPreview.Location = new System.Drawing.Point(7, 124);
			this.cbPreview.Name = "cbPreview";
			this.cbPreview.Size = new System.Drawing.Size(144, 24);
			this.cbPreview.TabIndex = 7;
			this.cbPreview.Text = "Show Realtime Preview";
			this.cbPreview.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(7, 75);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(33, 20);
			this.label5.TabIndex = 8;
			this.label5.Text = "Size:";
			// 
			// nud_size
			// 
			this.nud_size.Location = new System.Drawing.Point(46, 71);
			this.nud_size.Maximum = new decimal(new int[] {
									60,
									0,
									0,
									0});
			this.nud_size.Minimum = new decimal(new int[] {
									10,
									0,
									0,
									0});
			this.nud_size.Name = "nud_size";
			this.nud_size.Size = new System.Drawing.Size(43, 20);
			this.nud_size.TabIndex = 4;
			this.toolTip1.SetToolTip(this.nud_size, "Width for left and right regions, height for top and bottom regions");
			this.nud_size.Value = new decimal(new int[] {
									30,
									0,
									0,
									0});
			this.nud_size.ValueChanged += new System.EventHandler(this.Nud_sizeValueChanged);
			// 
			// nud_right
			// 
			this.nud_right.Location = new System.Drawing.Point(147, 45);
			this.nud_right.Name = "nud_right";
			this.nud_right.Size = new System.Drawing.Size(43, 20);
			this.nud_right.TabIndex = 3;
			this.toolTip1.SetToolTip(this.nud_right, "LEDs on the left");
			this.nud_right.Value = new decimal(new int[] {
									6,
									0,
									0,
									0});
			this.nud_right.ValueChanged += new System.EventHandler(this.Nud_rightValueChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(95, 47);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(46, 20);
			this.label3.TabIndex = 6;
			this.label3.Text = "Right:";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(7, 47);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(33, 20);
			this.label4.TabIndex = 5;
			this.label4.Text = "Left:";
			// 
			// nud_left
			// 
			this.nud_left.Location = new System.Drawing.Point(46, 45);
			this.nud_left.Name = "nud_left";
			this.nud_left.Size = new System.Drawing.Size(43, 20);
			this.nud_left.TabIndex = 2;
			this.toolTip1.SetToolTip(this.nud_left, "LEDs on the right");
			this.nud_left.Value = new decimal(new int[] {
									6,
									0,
									0,
									0});
			this.nud_left.ValueChanged += new System.EventHandler(this.Nud_leftValueChanged);
			// 
			// nud_bottom
			// 
			this.nud_bottom.Location = new System.Drawing.Point(147, 19);
			this.nud_bottom.Name = "nud_bottom";
			this.nud_bottom.Size = new System.Drawing.Size(43, 20);
			this.nud_bottom.TabIndex = 1;
			this.toolTip1.SetToolTip(this.nud_bottom, "LEDs at the bottom");
			this.nud_bottom.Value = new decimal(new int[] {
									10,
									0,
									0,
									0});
			this.nud_bottom.ValueChanged += new System.EventHandler(this.Nud_bottomValueChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(95, 21);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 20);
			this.label2.TabIndex = 2;
			this.label2.Text = "Bottom:";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(7, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(33, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "Top:";
			// 
			// nud_top
			// 
			this.nud_top.Location = new System.Drawing.Point(46, 19);
			this.nud_top.Name = "nud_top";
			this.nud_top.Size = new System.Drawing.Size(43, 20);
			this.nud_top.TabIndex = 0;
			this.toolTip1.SetToolTip(this.nud_top, "LEDs on top");
			this.nud_top.Value = new decimal(new int[] {
									10,
									0,
									0,
									0});
			this.nud_top.ValueChanged += new System.EventHandler(this.Nud_topValueChanged);
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.ContextMenuStrip = this.cms_NotifyIcon;
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "BlinkStick Ambilight";
			this.notifyIcon1.Visible = true;
			this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1MouseDoubleClick);
			// 
			// cms_NotifyIcon
			// 
			this.cms_NotifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.mi_ShowSettings,
									this.toolStripSeparator1,
									this.mi_Exit});
			this.cms_NotifyIcon.Name = "cms_NotifyIcon";
			this.cms_NotifyIcon.Size = new System.Drawing.Size(149, 54);
			// 
			// mi_ShowSettings
			// 
			this.mi_ShowSettings.Name = "mi_ShowSettings";
			this.mi_ShowSettings.Size = new System.Drawing.Size(148, 22);
			this.mi_ShowSettings.Text = "Show Settings";
			this.mi_ShowSettings.Click += new System.EventHandler(this.Mi_ShowSettingsClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
			// 
			// mi_Exit
			// 
			this.mi_Exit.Name = "mi_Exit";
			this.mi_Exit.Size = new System.Drawing.Size(148, 22);
			this.mi_Exit.Text = "Exit";
			this.mi_Exit.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(785, 24);
			this.menuStrip1.TabIndex = 4;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.tsAbout,
									this.tsExit});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// tsAbout
			// 
			this.tsAbout.Name = "tsAbout";
			this.tsAbout.Size = new System.Drawing.Size(107, 22);
			this.tsAbout.Text = "About";
			this.tsAbout.Click += new System.EventHandler(this.TsAboutClick);
			// 
			// tsExit
			// 
			this.tsExit.Name = "tsExit";
			this.tsExit.Size = new System.Drawing.Size(107, 22);
			this.tsExit.Text = "Exit";
			this.tsExit.Click += new System.EventHandler(this.TsExitClick);
			// 
			// grpScreenPreview
			// 
			this.grpScreenPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.grpScreenPreview.BackColor = System.Drawing.SystemColors.Control;
			this.grpScreenPreview.Controls.Add(this.lb_FPS);
			this.grpScreenPreview.Controls.Add(this.pbPreview);
			this.grpScreenPreview.Location = new System.Drawing.Point(218, 27);
			this.grpScreenPreview.Name = "grpScreenPreview";
			this.grpScreenPreview.Size = new System.Drawing.Size(559, 414);
			this.grpScreenPreview.TabIndex = 5;
			this.grpScreenPreview.TabStop = false;
			this.grpScreenPreview.Text = "Screen Preview";
			// 
			// lb_FPS
			// 
			this.lb_FPS.Location = new System.Drawing.Point(20, 357);
			this.lb_FPS.Name = "lb_FPS";
			this.lb_FPS.Size = new System.Drawing.Size(100, 23);
			this.lb_FPS.TabIndex = 2;
			this.lb_FPS.Text = "FPS";
			this.lb_FPS.Visible = false;
			// 
			// pbPreview
			// 
			this.pbPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pbPreview.Location = new System.Drawing.Point(6, 19);
			this.pbPreview.Name = "pbPreview";
			this.pbPreview.Size = new System.Drawing.Size(402, 270);
			this.pbPreview.TabIndex = 1;
			this.pbPreview.TabStop = false;
			this.pbPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.PbPreviewPaint);
			this.pbPreview.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PbPreviewMouseClick);
			// 
			// toolTip1
			// 
			this.toolTip1.UseAnimation = false;
			this.toolTip1.UseFading = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rbStaticColor);
			this.groupBox1.Controls.Add(this.rbAmbilightScreen);
			this.groupBox1.Controls.Add(this.rbAmbilightRegion);
			this.groupBox1.Location = new System.Drawing.Point(12, 162);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(200, 91);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Lighttype";
			// 
			// rbStaticColor
			// 
			this.rbStaticColor.Location = new System.Drawing.Point(7, 58);
			this.rbStaticColor.Name = "rbStaticColor";
			this.rbStaticColor.Size = new System.Drawing.Size(187, 24);
			this.rbStaticColor.TabIndex = 2;
			this.rbStaticColor.Text = "Static Color";
			this.rbStaticColor.UseVisualStyleBackColor = true;
			this.rbStaticColor.Click += new System.EventHandler(this.RbStaticColorClick);
			// 
			// rbAmbilightScreen
			// 
			this.rbAmbilightScreen.Location = new System.Drawing.Point(7, 39);
			this.rbAmbilightScreen.Name = "rbAmbilightScreen";
			this.rbAmbilightScreen.Size = new System.Drawing.Size(183, 24);
			this.rbAmbilightScreen.TabIndex = 1;
			this.rbAmbilightScreen.Text = "Ambilight Screen";
			this.rbAmbilightScreen.UseVisualStyleBackColor = true;
			this.rbAmbilightScreen.Click += new System.EventHandler(this.RbAmbilightScreenClick);
			// 
			// rbAmbilightRegion
			// 
			this.rbAmbilightRegion.Checked = true;
			this.rbAmbilightRegion.Location = new System.Drawing.Point(7, 19);
			this.rbAmbilightRegion.Name = "rbAmbilightRegion";
			this.rbAmbilightRegion.Size = new System.Drawing.Size(183, 24);
			this.rbAmbilightRegion.TabIndex = 0;
			this.rbAmbilightRegion.TabStop = true;
			this.rbAmbilightRegion.Text = "Ambilight Region";
			this.rbAmbilightRegion.UseVisualStyleBackColor = true;
			this.rbAmbilightRegion.Click += new System.EventHandler(this.RbAmbilightClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(785, 445);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.grpScreenPreview);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.grpRegions);
			this.Controls.Add(this.grpBlinkStickSettings);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "BlinkStick AmbiLight";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.Shown += new System.EventHandler(this.MainFormShown);
			this.grpBlinkStickSettings.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nud_brightness)).EndInit();
			this.grpRegions.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nud_shift)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_size)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_right)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_left)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_bottom)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_top)).EndInit();
			this.cms_NotifyIcon.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.grpScreenPreview.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label lb_FPS;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.NumericUpDown nud_brightness;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button btnBasicColor;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.RadioButton rbAmbilightRegion;
		private System.Windows.Forms.RadioButton rbAmbilightScreen;
		private System.Windows.Forms.RadioButton rbStaticColor;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.CheckBox cbTransparent;
		private System.Windows.Forms.GroupBox grpScreenPreview;
		private System.Windows.Forms.ToolStripMenuItem tsExit;
		private System.Windows.Forms.ToolStripMenuItem tsAbout;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.Button btnWhiteout;
		private System.Windows.Forms.CheckBox cb_ConnectFirst;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem mi_ShowSettings;
		private System.Windows.Forms.ToolStripMenuItem mi_Exit;
		private System.Windows.Forms.ContextMenuStrip cms_NotifyIcon;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown nud_shift;
		private System.Windows.Forms.CheckBox cbPreview;
		private System.Windows.Forms.NumericUpDown nud_size;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown nud_top;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown nud_bottom;
		private System.Windows.Forms.NumericUpDown nud_left;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown nud_right;
		private System.Windows.Forms.GroupBox grpRegions;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button btnRefreshBS;
		private System.Windows.Forms.GroupBox grpBlinkStickSettings;
		private System.Windows.Forms.PictureBox pbPreview;
	}
}
