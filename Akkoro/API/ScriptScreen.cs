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

        public void GetBounds(out int x, out int y, out int width, out int height)
        {
            x = _screen.Bounds.X;
            y = _screen.Bounds.Y;
            width = _screen.Bounds.Width;
            height = _screen.Bounds.Height;
        }
    }
}
