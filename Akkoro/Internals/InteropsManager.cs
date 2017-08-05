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
    }
}
