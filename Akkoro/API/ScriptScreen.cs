using System.Drawing;
using System.Windows.Forms;

namespace Akkoro
{
    public class ScriptScreen
    {
        private Screen _screen;

        public ScriptScreen(Screen screen)
        {
            _screen = screen;
        }

        public string GetDeviceName()
        {
            return _screen.DeviceName;
        }

        public bool IsPrimary()
        {
            return _screen.Primary;
        }

        public ScriptImage Capture()
        {
            Rectangle bound = _screen.Bounds;
            Bitmap bitmap = new Bitmap(bound.Width, bound.Height);

            using (Graphics gfx = Graphics.FromImage(bitmap))
                gfx.CopyFromScreen(bound.X, bound.Y, 0, 0, bitmap.Size, CopyPixelOperation.SourceCopy);

            return new ScriptImage(bitmap);
        }

        public void GetBounds(out int x, out int y, out int width, out int height)
        {
            x = _screen.Bounds.X;
            y = _screen.Bounds.Y;
            width = _screen.Bounds.Width;
            height = _screen.Bounds.Height;
        }
    }
}
