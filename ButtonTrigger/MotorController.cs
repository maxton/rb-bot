using System;
using System.IO.Ports;

namespace ButtonTrigger
{
  class MotorController : IDisposable
  {
    struct Opcodes
    {
      public const byte SetState          = 0x00;
      public const byte SetOffset         = 0x10;
      public const byte SetDownPosition   = 0x20;
      public const byte SetUpPosition     = 0x30; 
      public const byte QueryState        = 0x40; 
      public const byte QueryDownPosition = 0x50; 
      public const byte QueryUpPosition   = 0x60; 
      public const byte QueryMotorOffset  = 0x70; 
      public const byte CommitConfig      = 0x80; 
      public const byte ReloadConfig      = 0x90; 
    }
    byte[] Command(byte opcode, ushort data = 0, byte imm = 0) => new byte[]
      {
        (byte)(opcode | (imm & 0xF)),
        (byte)(data & 0xFF),
        (byte)(data >> 8)
      };

    void Issue(params byte[][] commands)
    {
      foreach(var b in commands)
      {
        port_.Write(b, 0, 3);
        Console.WriteLine($"Wrote: 0x{b[0]:X2} 0x{b[1]:X2} 0x{b[2]:X2}");
      }
    }
    SerialPort port_;

    public short[] Offsets = new short[6];
    public bool[] State = new bool[6];
    public ushort DownPos;
    public ushort UpPos;

    public MotorController(string port = "COM3")
    {
      port_ = new SerialPort(port, 57600);
      port_.ReadTimeout = 1000;
      port_.Open();
      Issue(
        Command(Opcodes.ReloadConfig),
        Command(Opcodes.SetState, 0)
      );
      port_.DiscardInBuffer();
      for (byte i = 0; i < Offsets.Length; i++)
      {
        Issue(Command(Opcodes.QueryMotorOffset, imm: i));
        Offsets[i] = read_short();
      }

      Issue(Command(Opcodes.QueryDownPosition));
      unchecked { DownPos = (ushort)read_short(); }

      Issue(Command(Opcodes.QueryUpPosition));
      unchecked { UpPos = (ushort)read_short(); }
    }

    private short read_short()
    {
      byte[] b = new byte[2];
      System.Threading.Thread.Sleep(100);
      port_.Read(b, 0, 2);
      Console.WriteLine($"Read two bytes: 0x{b[0]:X2} 0x{b[1]:X2}");
      return (short)((b[1] << 8) | (b[0] & 0xFF));
    }

    public static string[] GetPorts() => SerialPort.GetPortNames();

    public void Save() => Issue(Command(Opcodes.CommitConfig));

    public void Reload() => Issue(Command(Opcodes.CommitConfig));

    public void SetOffset(byte motor, short pos)
    {
      Issue(Command(Opcodes.SetOffset, (ushort)pos, motor));
      Offsets[motor] = pos;
    }

    public void SendState()
    {
      byte state = 0;
      for (int i = 0; i < State.Length; i++)
      {
        if (State[i]) state |= (byte)(1 << i);
      }
      Issue(Command(Opcodes.SetState, state));
    }

    public void SetUpPos(ushort value)
    {
      Issue(Command(Opcodes.SetUpPosition, value));
      UpPos = value;
    }

    public void SetDownPos(ushort value)
    {
      Issue(Command(Opcodes.SetDownPosition, value));
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
