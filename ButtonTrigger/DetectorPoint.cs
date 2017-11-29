using System;
using System.Drawing;
using DtxCS.DataTypes;

namespace ButtonTrigger
{
  public class DetectorPoint
  {
    public float xP;
    public float yP;
    public bool triggered;
    public float tolerance = 0.05f;
    private Color last;
    public Color target = Color.Black;
    private const float MaximumDiff = 441.67295593f;
    public int midiNote = 38;
    private int lagCount = 1;
    const int LAG_MAX = 3;
    public void NotifyColorChange(Color c)
    {
      if (lagCount >= 1) lagCount--;
      var orig = triggered;
      var diff = Math.Sqrt(Math.Pow(c.R - (float)target.R, 2) +
        Math.Pow(c.G - (float)target.G, 2) +
        Math.Pow(c.B - (float)target.B, 2)) / MaximumDiff;
      triggered = diff < tolerance;
      if (triggered != orig)
      {
        lagCount = LAG_MAX;
      }
      if(lagCount == 1)
      {
        OnValueChange(triggered);
      }
      last = c;
    }
    public delegate void PointAction(bool value);
    public event PointAction OnValueChange;

    public DataArray Serialize()
    {
      var array = new DataArray();
      array.AddNode(new DataAtom(xP));
      array.AddNode(new DataAtom(yP));
      array.AddNode(new DataAtom(tolerance));
      array.AddNode(new DataAtom(target.ToArgb()));
      array.AddNode(new DataAtom(midiNote));
      return array;
    }

    public void Deserialize(DataArray data)
    {
      xP = data.Float(0);
      yP = data.Float(1);
      tolerance = data.Float(2);
      target = Color.FromArgb(data.Int(3));
      midiNote = data.Int(4);
    }
  }
}
