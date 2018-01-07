namespace ButtonTrigger
{
    partial class PointControllerGuitar
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
            this.red = new System.Windows.Forms.NumericUpDown();
            this.posX = new System.Windows.Forms.NumericUpDown();
            this.posY = new System.Windows.Forms.NumericUpDown();
            this.green = new System.Windows.Forms.NumericUpDown();
            this.blue = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.colorPicker = new System.Windows.Forms.ColorDialog();
            this.tolerance = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.offsetUpDown = new System.Windows.Forms.NumericUpDown();
            this.toggleButton = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.red)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.green)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tolerance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.offsetUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // red
            // 
            this.red.Location = new System.Drawing.Point(3, 80);
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
            this.posX.Location = new System.Drawing.Point(3, 21);
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
            this.posY.Location = new System.Drawing.Point(63, 21);
            this.posY.Name = "posY";
            this.posY.Size = new System.Drawing.Size(54, 20);
            this.posY.TabIndex = 4;
            this.posY.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // green
            // 
            this.green.Location = new System.Drawing.Point(41, 80);
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
            this.blue.Location = new System.Drawing.Point(80, 80);
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
            this.panel1.Location = new System.Drawing.Point(80, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(35, 27);
            this.panel1.TabIndex = 8;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // tolerance
            // 
            this.tolerance.DecimalPlaces = 2;
            this.tolerance.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.tolerance.Location = new System.Drawing.Point(3, 54);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Motor 8";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Offset:";
            // 
            // offsetUpDown
            // 
            this.offsetUpDown.Location = new System.Drawing.Point(41, 101);
            this.offsetUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.offsetUpDown.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.offsetUpDown.Name = "offsetUpDown";
            this.offsetUpDown.Size = new System.Drawing.Size(37, 20);
            this.offsetUpDown.TabIndex = 13;
            // 
            // toggleButton
            // 
            this.toggleButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.toggleButton.AutoCheck = false;
            this.toggleButton.AutoSize = true;
            this.toggleButton.Location = new System.Drawing.Point(3, 127);
            this.toggleButton.Name = "toggleButton";
            this.toggleButton.Size = new System.Drawing.Size(50, 23);
            this.toggleButton.TabIndex = 15;
            this.toggleButton.Text = "Toggle";
            this.toggleButton.UseVisualStyleBackColor = true;
            // 
            // PointControllerGuitar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.toggleButton);
            this.Controls.Add(this.offsetUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tolerance);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.blue);
            this.Controls.Add(this.green);
            this.Controls.Add(this.posY);
            this.Controls.Add(this.posX);
            this.Controls.Add(this.red);
            this.Name = "PointControllerGuitar";
            this.Size = new System.Drawing.Size(120, 153);
            ((System.ComponentModel.ISupportInitialize)(this.red)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.green)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tolerance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.offsetUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown red;
        private System.Windows.Forms.NumericUpDown posX;
        private System.Windows.Forms.NumericUpDown posY;
    private System.Windows.Forms.NumericUpDown green;
    private System.Windows.Forms.NumericUpDown blue;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.ColorDialog colorPicker;
    private System.Windows.Forms.NumericUpDown tolerance;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    public System.Windows.Forms.NumericUpDown offsetUpDown;
    public System.Windows.Forms.CheckBox toggleButton;
  }
}
