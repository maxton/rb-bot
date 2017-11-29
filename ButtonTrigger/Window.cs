using System;
using PInvoke;
using static Win32Interop.Methods.Gdi32;
using System.Drawing;
using System.Drawing.Imaging;

namespace ButtonTrigger
{
  class Window
  {
    public IntPtr Hwnd;
    public RECT Rec;
    public string name = "";
    public Window(IntPtr p)
    {
      Hwnd = p;
      Rec = new RECT();
      User32.GetWindowRect(Hwnd, out Rec);
      var windowText = new char[User32.GetWindowTextLength(Hwnd)];
      User32.GetWindowText(Hwnd, windowText, windowText.Length);
      name = new string(windowText);
    }

    public Bitmap LoadBitmap()
    {
      User32.GetWindowRect(Hwnd, out Rec);
      var width = Rec.right - Rec.left;
      var height = Rec.bottom - Rec.top;
      if (width == 0 || height == 0) return null;
      Bitmap bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);
      Graphics gfxBmp = Graphics.FromImage(bmp);
      IntPtr hdcBitmap;
      try
      {
        hdcBitmap = gfxBmp.GetHdc();
      }
      catch
      {
        return null;
      }
      bool succeeded = User32.PrintWindow(Hwnd, hdcBitmap, 0);
      gfxBmp.ReleaseHdc(hdcBitmap);
      if (!succeeded)
      {
        gfxBmp.FillRectangle(new SolidBrush(Color.Gray), new Rectangle(Point.Empty, bmp.Size));
      }
      IntPtr hRgn = CreateRectRgn(0, 0, 0, 0);
      Win32Interop.Methods.User32.GetWindowRgn(Hwnd, hRgn);
      Region region = Region.FromHrgn(hRgn);//err here once
      if (!region.IsEmpty(gfxBmp))
      {
        gfxBmp.ExcludeClip(region);
        gfxBmp.Clear(Color.Transparent);
      }
      DeleteObject(hRgn);
      gfxBmp.Dispose();
      return bmp;
    }

    public override string ToString()
    {
      return string.Format("{0} [{1:X}] ({2}x{3})", name, Hwnd.ToInt64(),
          Rec.right - Rec.left, Rec.bottom - Rec.top);
    }
  }
}
