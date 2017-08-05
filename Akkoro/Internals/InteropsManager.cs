using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Akkoro
{
    public class InteropsManager
    {
        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(ref Point lpPoint);
        private static Point _cursorRef = new Point();
        public static Point CursorPosition { get { GetCursorPos(ref _cursorRef); return _cursorRef; } }

        [DllImport("User32.dll")]
        public static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        public static void SendMouseEvent(uint mouseEvent) { mouse_event(mouseEvent, 0, 0, 0, 0); }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
        public static void SendKeyEvent(Keys key, uint keyEvent) { keybd_event((byte)key, 0x45, keyEvent, (UIntPtr)0); }

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        private static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);
        private static Bitmap pixelBuffer = new Bitmap(1, 1);
        public static Color GetColorAt(int x, int y)
        {
            using (Graphics gfx = Graphics.FromImage(pixelBuffer))
            {
                using (Graphics src = Graphics.FromHwnd(IntPtr.Zero))
                {
                    IntPtr srcHdc = src.GetHdc();
                    IntPtr gfxHdc = gfx.GetHdc();

                    BitBlt(gfxHdc, 0, 0, 1, 1, srcHdc, x, y, (int)CopyPixelOperation.SourceCopy);

                    src.ReleaseHdc();
                    gfx.ReleaseHdc();
                }
            }

            return pixelBuffer.GetPixel(0, 0);
        }
    }
}
