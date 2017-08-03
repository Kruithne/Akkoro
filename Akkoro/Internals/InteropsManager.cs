using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;
using NLua;

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
    }
}
