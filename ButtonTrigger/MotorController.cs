using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace ButtonTrigger
{
  class MotorController : IDisposable
  {
    enum MotorCommand : byte
    {
      SetState = 0,
      SetOffset = 0b0100_0000,
      SetDown = 0b1000_0001,
      SetUp = 0b1000_0000,
      QueryState = 0b1100_0000,
      QueryDown = 0b1100_0001,
      QueryUp = 0b1100_0010,
      QueryOffset = 0b1110_1000,
      SaveToNVRam = 0b1111_0000,
      LoadFromNVRam = 0b1111_1111
    }

    SerialPort port_;
    // Two reads from eeprom, set state to zero
    byte[] reset_ = {
      (byte)MotorCommand.LoadFromNVRam,
      (byte)MotorCommand.SetState
    };

    byte[] cmd_buf = new byte[3];

    public short[] Offsets = new short[6];
    public bool[] State = new bool[6];
    public ushort DownPos;
    public ushort UpPos;

    public MotorController(string port = "COM3")
    {
      port_ = new SerialPort(port, 57600);
      port_.ReadTimeout = 1000;
      port_.Open();
      port_.Write(reset_, 0, reset_.Length);
      port_.DiscardInBuffer();
      for (var i = 0; i < Offsets.Length; i++)
      {
        cmd_buf[0] = (byte)((byte)MotorCommand.QueryOffset | i);
        port_.Write(cmd_buf, 0, 1);
        Offsets[i] = read_short();
      }

      cmd_buf[0] = (byte)MotorCommand.QueryDown;
      port_.Write(cmd_buf, 0, 1);
      unchecked { DownPos = (ushort)read_short(); }

      cmd_buf[0] = (byte)MotorCommand.QueryUp;
      port_.Write(cmd_buf, 0, 1);
      unchecked { UpPos = (ushort)read_short(); }
    }

    private short read_short()
    {
      byte[] b = new byte[2];
      System.Threading.Thread.Sleep(100);
      port_.Read(b, 0, 2);
      Console.WriteLine($"Read two bytes: 0x{b[0]:X2} 0x{b[1]:X2}");
      return (short)((b[0] << 8) | (b[1] & 0xFF));
    }

    public static string[] GetPorts() => SerialPort.GetPortNames();

    public void Save()
    {
      cmd_buf[0] = (byte)MotorCommand.SaveToNVRam;
      port_.Write(cmd_buf, 0, 1);
      Console.WriteLine($"Wrote: 0x{cmd_buf[0]:X2}");
    }

    public void Reload()
    {
      cmd_buf[0] = (byte)MotorCommand.LoadFromNVRam;
      port_.Write(cmd_buf, 0, 1);
      Console.WriteLine($"Wrote: 0x{cmd_buf[0]:X2}");
    }

    public void SetOffset(byte motor, short pos)
    {
      cmd_buf[0] = (byte)((byte)MotorCommand.SetOffset | motor);
      cmd_buf[1] = (byte)(pos >> 8);
      cmd_buf[2] = (byte)(pos & 0xFF);
      port_.Write(cmd_buf, 0, 3);
      Console.WriteLine($"Wrote: 0x{cmd_buf[0]:X2} 0x{cmd_buf[1]:X2} 0x{cmd_buf[2]:X2}");
      Offsets[motor] = pos;
    }

    public void SendState()
    {
      byte state = (byte)MotorCommand.SetState;
      for (int i = 0; i < State.Length; i++)
      {
        if (State[i]) state |= (byte)(1 << i);
      }
      cmd_buf[0] = state;
      port_.Write(cmd_buf, 0, 1);
      Console.WriteLine($"Wrote: 0x{cmd_buf[0]:X2}");
    }

    public void SetUpPos(ushort value)
    {
      cmd_buf[0] = (byte)MotorCommand.SetUp;
      cmd_buf[1] = (byte)(value >> 8);
      cmd_buf[2] = (byte)(value & 0xFF);
      port_.Write(cmd_buf, 0, 3);
      Console.WriteLine($"Wrote: 0x{cmd_buf[0]:X2} 0x{cmd_buf[1]:X2} 0x{cmd_buf[2]:X2}");
      UpPos = value;
    }

    public void SetDownPos(ushort value)
    {
      cmd_buf[0] = (byte)MotorCommand.SetDown;
      cmd_buf[1] = (byte)(value >> 8);
      cmd_buf[2] = (byte)(value & 0xFF);
      port_.Write(cmd_buf, 0, 3);
      Console.WriteLine($"Wrote: 0x{cmd_buf[0]:X2} 0x{cmd_buf[1]:X2} 0x{cmd_buf[2]:X2}");
      DownPos = value;
    }
    
    public void Dispose()
    {
      try
      {
        port_.Close();
        port_.Dispose();
      }
      catch (Exception) { }
    }
   
  }
}
