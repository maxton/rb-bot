namespace ButtonTrigger
{
    partial class PointController
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.removeButton = new System.Windows.Forms.Button();
            this.red = new System.Windows.Forms.NumericUpDown();
            this.posX = new System.Windows.Forms.NumericUpDown();
            this.posY = new System.Windows.Forms.NumericUpDown();
            this.green = new System.Windows.Forms.NumericUpDown();
            this.blue = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.colorPicker = new System.Windows.Forms.ColorDialog();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tolerance = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.red)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.green)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tolerance)).BeginInit();
            this.SuspendLayout();
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(3, 114);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(114, 23);
            this.removeButton.TabIndex = 0;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // red
            // 
            this.red.Location = new System.Drawing.Point(3, 88);
            this.red.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.red.Name = "red";
            this.red.Size = new System.Drawing.Size(37, 20);
            this.red.TabIndex = 2;
            this.red.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // posX
            // 
            this.posX.DecimalPlaces = 2;
            this.posX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.posX.Location = new System.Drawing.Point(3, 3);
            this.posX.Name = "posX";
            this.posX.Size = new System.Drawing.Size(54, 20);
            this.posX.TabIndex = 3;
            this.posX.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // posY
            // 
            this.posY.DecimalPlaces = 2;
            this.posY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.posY.Location = new System.Drawing.Point(63, 3);
            this.posY.Name = "posY";
            this.posY.Size = new System.Drawing.Size(54, 20);
            this.posY.TabIndex = 4;
            this.posY.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // green
            // 
            this.green.Location = new System.Drawing.Point(41, 88);
            this.green.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.green.Name = "green";
            this.green.Size = new System.Drawing.Size(37, 20);
            this.green.TabIndex = 6;
            this.green.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // blue
            // 
            this.blue.Location = new System.Drawing.Point(80, 88);
            this.blue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.blue.Name = "blue";
            this.blue.Size = new System.Drawing.Size(37, 20);
            this.blue.TabIndex = 7;
            this.blue.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(80, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(35, 27);
            this.panel1.TabIndex = 8;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Red",
            "Yellow",
            "Blue",
            "Green"});
            this.comboBox1.Location = new System.Drawing.Point(45, 28);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(72, 21);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tolerance
            // 
            this.tolerance.DecimalPlaces = 2;
            this.tolerance.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.tolerance.Location = new System.Drawing.Point(3, 62);
            this.tolerance.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tolerance.Name = "tolerance";
            this.tolerance.Size = new System.Drawing.Size(54, 20);
            this.tolerance.TabIndex = 10;
            this.tolerance.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // PointController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tolerance);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.blue);
            this.Controls.Add(this.green);
            this.Controls.Add(this.posY);
            this.Controls.Add(this.posX);
            this.Controls.Add(this.red);
            this.Controls.Add(this.removeButton);
            this.Name = "PointController";
            this.Size = new System.Drawing.Size(120, 140);
            ((System.ComponentModel.ISupportInitialize)(this.red)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.green)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tolerance)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.NumericUpDown red;
        private System.Windows.Forms.NumericUpDown posX;
        private System.Windows.Forms.NumericUpDown posY;
    private System.Windows.Forms.NumericUpDown green;
    private System.Windows.Forms.NumericUpDown blue;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.ColorDialog colorPicker;
    private System.Windows.Forms.ComboBox comboBox1;
    private System.Windows.Forms.NumericUpDown tolerance;
  }
}
