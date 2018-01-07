namespace ButtonTrigger
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
      this.windowSelector = new System.Windows.Forms.ComboBox();
      this.windowBox = new System.Windows.Forms.PictureBox();
      this.pointControllerPanel = new System.Windows.Forms.FlowLayoutPanel();
      this.addButton = new System.Windows.Forms.Button();
      this.removeButton = new System.Windows.Forms.Button();
      this.deviceSelector = new System.Windows.Forms.ComboBox();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
      this.button1 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.label5 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.disconnectBtn = new System.Windows.Forms.Button();
      this.downPosInput = new System.Windows.Forms.NumericUpDown();
      this.upPosInput = new System.Windows.Forms.NumericUpDown();
      this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
      this.button3 = new System.Windows.Forms.Button();
      this.stopTestBtn = new System.Windows.Forms.Button();
      this.startTestBtn = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.portSelector = new System.Windows.Forms.ComboBox();
      ((System.ComponentModel.ISupportInitialize)(this.windowBox)).BeginInit();
      this.menuStrip1.SuspendLayout();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.downPosInput)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.upPosInput)).BeginInit();
      this.SuspendLayout();
      // 
      // windowSelector
      // 
      this.windowSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.windowSelector.FormattingEnabled = true;
      this.windowSelector.Location = new System.Drawing.Point(65, 27);
      this.windowSelector.Name = "windowSelector";
      this.windowSelector.Size = new System.Drawing.Size(193, 21);
      this.windowSelector.TabIndex = 0;
      // 
      // windowBox
      // 
      this.windowBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.windowBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.windowBox.Location = new System.Drawing.Point(12, 54);
      this.windowBox.Name = "windowBox";
      this.windowBox.Size = new System.Drawing.Size(825, 357);
      this.windowBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.windowBox.TabIndex = 1;
      this.windowBox.TabStop = false;
      // 
      // pointControllerPanel
      // 
      this.pointControllerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.pointControllerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pointControllerPanel.Location = new System.Drawing.Point(155, 3);
      this.pointControllerPanel.Name = "pointControllerPanel";
      this.pointControllerPanel.Size = new System.Drawing.Size(664, 198);
      this.pointControllerPanel.TabIndex = 2;
      // 
      // addButton
      // 
      this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.addButton.Location = new System.Drawing.Point(3, 3);
      this.addButton.Name = "addButton";
      this.addButton.Size = new System.Drawing.Size(70, 23);
      this.addButton.TabIndex = 3;
      this.addButton.Text = "Add";
      this.addButton.UseVisualStyleBackColor = true;
      this.addButton.Click += new System.EventHandler(this.addButton_Click);
      // 
      // removeButton
      // 
      this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.removeButton.Location = new System.Drawing.Point(79, 3);
      this.removeButton.Name = "removeButton";
      this.removeButton.Size = new System.Drawing.Size(70, 23);
      this.removeButton.TabIndex = 4;
      this.removeButton.Text = "Remove";
      this.removeButton.UseVisualStyleBackColor = true;
      this.removeButton.Click += new System.EventHandler(this.button2_Click);
      // 
      // deviceSelector
      // 
      this.deviceSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.deviceSelector.FormattingEnabled = true;
      this.deviceSelector.Location = new System.Drawing.Point(3, 45);
      this.deviceSelector.Name = "deviceSelector";
      this.deviceSelector.Size = new System.Drawing.Size(146, 21);
      this.deviceSelector.TabIndex = 5;
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(856, 24);
      this.menuStrip1.TabIndex = 6;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem.Text = "File";
      // 
      // openToolStripMenuItem
      // 
      this.openToolStripMenuItem.Name = "openToolStripMenuItem";
      this.openToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
      this.openToolStripMenuItem.Text = "&Open...";
      this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
      // 
      // saveToolStripMenuItem
      // 
      this.saveToolStripMenuItem.Enabled = false;
      this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
      this.saveToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
      this.saveToolStripMenuItem.Text = "&Save";
      this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
      // 
      // saveAsToolStripMenuItem
      // 
      this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
      this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
      this.saveAsToolStripMenuItem.Text = "Save &As...";
      this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
      // 
      // closeToolStripMenuItem
      // 
      this.closeToolStripMenuItem.Enabled = false;
      this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
      this.closeToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
      this.closeToolStripMenuItem.Text = "&Close";
      this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(120, 6);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
      this.exitToolStripMenuItem.Text = "E&xit";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(10, 30);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(49, 13);
      this.label1.TabIndex = 7;
      this.label1.Text = "Window:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(3, 29);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(66, 13);
      this.label2.TabIndex = 8;
      this.label2.Text = "Midi Device:";
      // 
      // openFileDialog1
      // 
      this.openFileDialog1.DefaultExt = "*.dta";
      this.openFileDialog1.FileName = "openFileDialog1";
      this.openFileDialog1.Filter = "Data File|*.dta";
      // 
      // saveFileDialog1
      // 
      this.saveFileDialog1.DefaultExt = "*.dta";
      this.saveFileDialog1.Filter = "Data File|*.dta";
      // 
      // button1
      // 
      this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.button1.Location = new System.Drawing.Point(340, 25);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(70, 23);
      this.button1.TabIndex = 9;
      this.button1.Text = "Stop";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // button2
      // 
      this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.button2.Location = new System.Drawing.Point(264, 25);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(70, 23);
      this.button2.TabIndex = 10;
      this.button2.Text = "Start";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click_1);
      // 
      // tabControl1
      // 
      this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tabControl1.Controls.Add(this.tabPage1);
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Location = new System.Drawing.Point(12, 417);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(832, 230);
      this.tabControl1.TabIndex = 0;
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.addButton);
      this.tabPage1.Controls.Add(this.pointControllerPanel);
      this.tabPage1.Controls.Add(this.removeButton);
      this.tabPage1.Controls.Add(this.label2);
      this.tabPage1.Controls.Add(this.deviceSelector);
      this.tabPage1.Location = new System.Drawing.Point(4, 22);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Size = new System.Drawing.Size(824, 204);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Drums";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // tabPage2
      // 
      this.tabPage2.Controls.Add(this.label5);
      this.tabPage2.Controls.Add(this.label4);
      this.tabPage2.Controls.Add(this.disconnectBtn);
      this.tabPage2.Controls.Add(this.downPosInput);
      this.tabPage2.Controls.Add(this.upPosInput);
      this.tabPage2.Controls.Add(this.flowLayoutPanel1);
      this.tabPage2.Controls.Add(this.button3);
      this.tabPage2.Controls.Add(this.stopTestBtn);
      this.tabPage2.Controls.Add(this.startTestBtn);
      this.tabPage2.Controls.Add(this.label3);
      this.tabPage2.Controls.Add(this.portSelector);
      this.tabPage2.Location = new System.Drawing.Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Size = new System.Drawing.Size(824, 204);
      this.tabPage2.TabIndex = 0;
      this.tabPage2.Text = "Guitar";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(-1, 118);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(78, 13);
      this.label5.TabIndex = 31;
      this.label5.Text = "Down Position:";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(0, 92);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(64, 13);
      this.label4.TabIndex = 30;
      this.label4.Text = "Up Position:";
      // 
      // disconnectBtn
      // 
      this.disconnectBtn.Location = new System.Drawing.Point(3, 178);
      this.disconnectBtn.Name = "disconnectBtn";
      this.disconnectBtn.Size = new System.Drawing.Size(126, 23);
      this.disconnectBtn.TabIndex = 29;
      this.disconnectBtn.Text = "Disconnect";
      this.disconnectBtn.UseVisualStyleBackColor = true;
      this.disconnectBtn.Click += new System.EventHandler(this.disconnectBtn_Click);
      // 
      // downPosInput
      // 
      this.downPosInput.Location = new System.Drawing.Point(83, 116);
      this.downPosInput.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.downPosInput.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
      this.downPosInput.Name = "downPosInput";
      this.downPosInput.Size = new System.Drawing.Size(46, 20);
      this.downPosInput.TabIndex = 28;
      this.downPosInput.ValueChanged += new System.EventHandler(this.downPos_ValueChanged);
      // 
      // upPosInput
      // 
      this.upPosInput.Location = new System.Drawing.Point(83, 90);
      this.upPosInput.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.upPosInput.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
      this.upPosInput.Name = "upPosInput";
      this.upPosInput.Size = new System.Drawing.Size(46, 20);
      this.upPosInput.TabIndex = 27;
      this.upPosInput.ValueChanged += new System.EventHandler(this.upPos_ValueChanged);
      // 
      // flowLayoutPanel1
      // 
      this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.flowLayoutPanel1.Location = new System.Drawing.Point(135, 3);
      this.flowLayoutPanel1.Name = "flowLayoutPanel1";
      this.flowLayoutPanel1.Size = new System.Drawing.Size(686, 198);
      this.flowLayoutPanel1.TabIndex = 26;
      // 
      // button3
      // 
      this.button3.Location = new System.Drawing.Point(3, 32);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(126, 23);
      this.button3.TabIndex = 24;
      this.button3.Text = "Save to EEPROM";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new System.EventHandler(this.button3_Click);
      // 
      // stopTestBtn
      // 
      this.stopTestBtn.Location = new System.Drawing.Point(69, 61);
      this.stopTestBtn.Name = "stopTestBtn";
      this.stopTestBtn.Size = new System.Drawing.Size(60, 23);
      this.stopTestBtn.TabIndex = 21;
      this.stopTestBtn.Text = "Stop test";
      this.stopTestBtn.UseVisualStyleBackColor = true;
      this.stopTestBtn.Click += new System.EventHandler(this.stopTest_Click);
      // 
      // startTestBtn
      // 
      this.startTestBtn.Location = new System.Drawing.Point(3, 61);
      this.startTestBtn.Name = "startTestBtn";
      this.startTestBtn.Size = new System.Drawing.Size(60, 23);
      this.startTestBtn.TabIndex = 20;
      this.startTestBtn.Text = "Start test";
      this.startTestBtn.UseVisualStyleBackColor = true;
      this.startTestBtn.Click += new System.EventHandler(this.startTest_Click);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(5, 8);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(29, 13);
      this.label3.TabIndex = 19;
      this.label3.Text = "Port:";
      // 
      // portSelector
      // 
      this.portSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.portSelector.FormattingEnabled = true;
      this.portSelector.Location = new System.Drawing.Point(38, 5);
      this.portSelector.Name = "portSelector";
      this.portSelector.Size = new System.Drawing.Size(91, 21);
      this.portSelector.TabIndex = 18;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(856, 659);
      this.Controls.Add(this.tabControl1);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.windowBox);
      this.Controls.Add(this.windowSelector);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.menuStrip1);
      this.Controls.Add(this.button2);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "MainForm";
      this.ShowIcon = false;
      this.Text = "RB Bot";
      this.Load += new System.EventHandler(this.MainForm_Load);
      ((System.ComponentModel.ISupportInitialize)(this.windowBox)).EndInit();
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabPage1.PerformLayout();
      this.tabPage2.ResumeLayout(false);
      this.tabPage2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.downPosInput)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.upPosInput)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ComboBox windowSelector;
    private System.Windows.Forms.PictureBox windowBox;
    private System.Windows.Forms.FlowLayoutPanel pointControllerPanel;
    private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
    private System.Windows.Forms.ComboBox deviceSelector;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.Button stopTestBtn;
    private System.Windows.Forms.Button startTestBtn;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ComboBox portSelector;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button disconnectBtn;
    private System.Windows.Forms.NumericUpDown downPosInput;
    private System.Windows.Forms.NumericUpDown upPosInput;
  }
}

