using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ButtonTrigger
{
  public partial class PointControllerDrums : UserControl, IPointController
  {
    private bool enableChanges = true;
    public DetectorPoint p { get; }
    private Dictionary<string, int> midiMap =
    new Dictionary<string, int>{
      {"Red", 38 }, {"Yellow", 48 }, {"Green", 41 }, {"Blue", 45 }
    };
    public PointControllerDrums(DetectorPoint p)
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
      var str = midiMap.Where((kv) => kv.Value == p.midiNote).First().Key;
      comboBox1.SelectedIndex = comboBox1.Items.IndexOf(str);
      enableChanges = true;
    }

    private void button1_Click(object sender, EventArgs e)
    {

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

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      p.midiNote = midiMap[comboBox1.SelectedItem.ToString()];
    }
  }
}
