using System.Drawing;
using System.Diagnostics;

namespace Akkoro
{
    class ScriptProcess
    {
        private Process _proc;

        public ScriptProcess(Process process)
        {
            _proc = process;
        }

        public bool IsAlive()
        {
            return !_proc.HasExited;
        }

        public void GetPosition(out int x, out int y, out int width, out int height)
        {
            InteropsManager.RECT region = new InteropsManager.RECT();
            InteropsManager.GetWindowRect(_proc.MainWindowHandle, ref region);

            x = region.left;
            y = region.top;
            width = region.right - region.left;
            height = region.bottom - region.top;
        }

        public ScriptImage Capture()
        {
            InteropsManager.RECT region = new InteropsManager.RECT();
            InteropsManager.GetWindowRect(_proc.MainWindowHandle, ref region);

            Bitmap bitmap = new Bitmap(region.right - region.left, region.bottom - region.top);

            using (Graphics gfx = Graphics.FromImage(bitmap))
                gfx.CopyFromScreen(region.left, region.top, 0, 0, bitmap.Size, CopyPixelOperation.SourceCopy);

            return new ScriptImage(bitmap);
        }

        public ScriptImage Capture(int x, int y, int width, int height)
        {
            InteropsManager.RECT region = new InteropsManager.RECT();
            InteropsManager.GetWindowRect(_proc.MainWindowHandle, ref region);

            Bitmap bitmap = new Bitmap(width, height);

            using (Graphics gfx = Graphics.FromImage(bitmap))
                gfx.CopyFromScreen(region.left + x, region.top + y, 0, 0, bitmap.Size, CopyPixelOperation.SourceCopy);

            return new ScriptImage(bitmap);
        }

        public void Focus()
        {
            InteropsManager.SetForegroundWindow(_proc.MainWindowHandle);
        }

        public string GetTitle()
        {
            return _proc.MainWindowTitle;
        }

        public int GetID()
        {
            return _proc.Id;
        }

        public void Kill()
        {
            _proc.Kill();
        }
    }
}
