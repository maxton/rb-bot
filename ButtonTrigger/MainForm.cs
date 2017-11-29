using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing;
using DtxCS.DataTypes;

namespace ButtonTrigger
{
  public partial class MainForm : Form
  {
    private string openFile = null;



    private Midi.Devices.IOutputDevice device;
    private Timer _timer;
    private List<PointController> points;


    private struct DragState
    {
      public bool Dragging;
      public PointController point;
    };
    private DragState dragState = new DragState();


    public MainForm()
    {
      InitializeComponent();
    }

    private void Serialize(string filename)
    {
      var data = new DataArray();
      data.AddNode(DataSymbol.Symbol("points"));
      foreach(var p in points)
      {
        data.AddNode(p.p.Serialize());
      }
      using (var writer = new System.IO.StreamWriter(filename))
      {
        writer.Write(data.ToString());
      }
    }

    private void Deserialize(string filename)
    {
      string data;
      using (var reader = new System.IO.StreamReader(filename))
        data = reader.ReadToEnd();
      var dta = DtxCS.DTX.FromDtaString(data);
      var array = dta.Array("points");
      for (int i = 1; i < array.Count; i++)
      {
        var p = new DetectorPoint();
        p.Deserialize(array.Array(i));
        AddPoint(p);
      }
    }

    public void OpenFile(string filename)
    {
      CloseFile();
      openFile = filename;
      Deserialize(filename);
      closeToolStripMenuItem.Enabled = true;
      saveToolStripMenuItem.Enabled = true;
    }

    public void SaveFile(string filename)
    {
      openFile = filename;
      Serialize(filename);
      closeToolStripMenuItem.Enabled = true;
      saveToolStripMenuItem.Enabled = true;
    }

    public void CloseFile()
    {
      while(points.Count > 0)
      {
        pointControllerPanel.Controls.Remove(points[points.Count - 1]);
        points.RemoveAt(points.Count - 1);
      }
      closeToolStripMenuItem.Enabled = false;
      saveToolStripMenuItem.Enabled = false;
    }

    public void AddPoint(DetectorPoint p)
    {
      var pt = points.Count;
      p.OnValueChange += (v) => { if (v) PointTrigger(pt); };
      points.Add(new PointController(p));
      pointControllerPanel.Controls.Add(points[points.Count - 1]);
    }

    public void RemoveLastPoint()
    {
      pointControllerPanel.Controls.Remove(points[points.Count - 1]);
      points.RemoveAt(points.Count - 1);
    }


    private void PointTrigger(int p)
    {
      if (device?.IsOpen == true)
      {
        device.SendNoteOn(Midi.Enums.Channel.Channel1, (Midi.Enums.Pitch)points[p].p.midiNote, 100);
        device.SendNoteOff(Midi.Enums.Channel.Channel1, (Midi.Enums.Pitch)points[p].p.midiNote, 100);
      }
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
      var winEnum = new WindowEnumerator();
      winEnum.LoadWindows();
      foreach (var i in winEnum.windows)
      {

        var win = new Window(i);
        if (win.name == "") continue;
        if (win.Rec.right - win.Rec.left > 0 && win.Rec.bottom - win.Rec.top > 0)
          windowSelector.Items.Add(win);
      }
      windowSelector.SelectedIndex = 0;
      windowSelector.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
      points = new List<PointController>();

      foreach(var d in Midi.Devices.DeviceManager.OutputDevices)
      {
        deviceSelector.Items.Add(d.Name);
      }
      deviceSelector.SelectedIndexChanged += DeviceSelector_SelectedIndexChanged;

      windowBox.MouseDown += PictureBox1_MouseDown;
      windowBox.MouseMove += PictureBox1_MouseMove;
      windowBox.MouseUp += PictureBox1_MouseUp;
    }

    private void DeviceSelector_SelectedIndexChanged(object sender, EventArgs e)
    {
      if(device?.IsOpen == true)
      {
        device.Close();
      }
      device = null;
      device = Midi.Devices.DeviceManager.OutputDevices.Where((d) => d.Name.Equals(deviceSelector.SelectedItem)).First();
      device.Open();
    }

    private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
      dragState.Dragging = false;
    }

    private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
      if (dragState.Dragging)
      {
        var xP = e.X / (float)windowBox.Width;
        var yP = e.Y / (float)windowBox.Height;
        dragState.point.p.xP = xP;
        dragState.point.p.yP = yP;
        dragState.point.Update();
      }
    }

    private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
      var xP = e.X / (float)windowBox.Width;
      var yP = e.Y / (float)windowBox.Height;
      foreach (var p in points)
      {
        if (Math.Sqrt(Math.Pow((xP - p.p.xP), 2) + Math.Pow((yP - p.p.yP), 2)) < 0.04)
        {
          dragState.point = p;
          dragState.Dragging = true;
          break;
        }
      }
    }


    private void PaintDetectorPoints(Bitmap b)
    {
      foreach (var p in points)
        p.p.NotifyColorChange(b.GetPixel((int)(p.p.xP * b.Width), (int)(p.p.yP * b.Height)));
      using (Graphics g = Graphics.FromImage(b))
        foreach (var p in points)
        {
          var pen = p.p.triggered ? Pens.White : Pens.Black;
          var left = p.p.xP * b.Width - b.Width * 0.03f;
          var right = p.p.xP * b.Width + b.Width * 0.03f;
          var top = p.p.yP * b.Height - b.Height * 0.03f;
          var bottom = p.p.yP * b.Height + b.Height * 0.03f;
          var center_x = p.p.xP * b.Width;
          var center_y = p.p.yP * b.Height;
          g.DrawLine(pen, left, top, right, bottom);
          g.DrawLine(pen, left, bottom, right, top);
          g.DrawEllipse(new Pen(p.p.target), center_x - 5, center_y - 5, 10, 10);
        }
    }

    private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (_timer != null)
      {
        _timer.Stop();
        _timer.Dispose();
        _timer = null;
      }
      _timer = new Timer();
      _timer.Interval = 10;
      var window = (Window)windowSelector.SelectedItem;
      _timer.Tick += (o, ev) =>
      {
        var bitmap = window.LoadBitmap();
        if (windowBox.Image != null && bitmap != null)
        {
          windowBox.Image.Dispose();
          windowBox.Image = null;
          PaintDetectorPoints(bitmap);
        }
        windowBox.Image = bitmap;
      };
      _timer.Start();
    }



    private void addButton_Click(object sender, EventArgs e)
    {
      var point = new DetectorPoint
      {
        xP = 0.5f,
        yP = 0.5f
      };
      AddPoint(point);
    }

    private void button2_Click(object sender, EventArgs e)
    {
      RemoveLastPoint();
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void closeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      CloseFile();
    }

    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
      {
        OpenFile(openFileDialog1.FileName);
      }
    }

    private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
      {
        SaveFile(saveFileDialog1.FileName);
      }
    }

    private void saveToolStripMenuItem_Click(object sender, EventArgs e)
    {
      SaveFile(openFile);
    }

    private void button1_Click(object sender, EventArgs e)
    {
      _timer.Stop();
    }

    private void button2_Click_1(object sender, EventArgs e)
    {
      _timer.Start();
    }
  }
}
