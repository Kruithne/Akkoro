using System;
using System.Drawing;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections.Generic;

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

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private static IntPtr _hookID = IntPtr.Zero;
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        private static List<ScriptEnvironment> _environments = new List<ScriptEnvironment>();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                foreach (ScriptEnvironment env in _environments)
                    env.QueueKey(vkCode);
            }

            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        public static void RegisterHookEnvironment(ScriptEnvironment env)
        {
            _environments.Add(env);
        }

        public static void RemoveHookEnrivonment(ScriptEnvironment env)
        {
            _environments.Remove(env);
        }

        public static void ApplyHooking()
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
                _hookID = SetWindowsHookEx(WH_KEYBOARD_LL, HookCallback, GetModuleHandle(curModule.ModuleName), 0);
        }

        public static void DisbandHooking()
        {
            UnhookWindowsHookEx(_hookID);
            _hookID = IntPtr.Zero;
            _environments.Clear();
        }

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
