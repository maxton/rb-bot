using System;
using System.Collections.Generic;
using PInvoke;
using static PInvoke.User32;
using System.Runtime.InteropServices;

namespace ButtonTrigger
{

  public class WindowEnumerator
  {
    public List<IntPtr> windows;
    public WindowEnumerator()
    {
      windows = new List<IntPtr>();
    }

    public void LoadWindows()
    {
      EnumWindows(Callback, IntPtr.Zero);
    }

    public bool Callback(IntPtr hwnd, IntPtr lParam)
    {
      windows.Add(hwnd);
      return true;
    }
  }
}
