using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ButtonTrigger
{
  public partial class PointControllerGuitar : UserControl, IPointController
  {
    private bool enableChanges = true;
    public DetectorPoint p { get; }
    public PointControllerGuitar(DetectorPoint p)
    {
      this.p = p;
      InitializeComponent();
      UpdateValues();
    }

    public void UpdateValues()
    {
      enableChanges = false;
      tolerance.Value = (decimal)p.tolerance;
      posX.Value = (decimal)(p.xP * 100);
      posY.Value = (decimal)(p.yP * 100);
      red.Value = p.target.R;
      green.Value = p.target.B;
      blue.Value = p.target.G;
      panel1.BackColor = p.target;
      label1.Text = string.Format("Motor {0}", p.midiNote);
      enableChanges = true;
    }

    private void ValueChanged(object sender, EventArgs e)
    {
      if (!enableChanges) return;
      p.xP = (float)posX.Value / 100f;
      p.yP = (float)posY.Value / 100f;
      p.tolerance = (float)tolerance.Value;
      p.target = System.Drawing.Color.FromArgb((int)red.Value, (int)green.Value, (int)blue.Value);
      panel1.BackColor = p.target;
    }

    private void panel1_Click(object sender, EventArgs e)
    {
      colorPicker.Color = p.target;
      colorPicker.ShowDialog();
      p.target = colorPicker.Color;
      UpdateValues();
    }

    private void stopTest_Click(object sender, EventArgs e)
    {

    }

    private void startTest_Click(object sender, EventArgs e)
    {

    }
  }
}
