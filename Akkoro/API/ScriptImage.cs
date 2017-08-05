using System.Drawing;

namespace Akkoro
{
    class ScriptImage
    {
        private Bitmap _bitmap;

        public ScriptImage(Bitmap image)
        {
            _bitmap = image;
        }

        public Color GetColorAt(int x, int y)
        {
            return _bitmap.GetPixel(x, y);
        }

        public int GetHeight()
        {
            return _bitmap.Height;
        }

        public int GetWidth()
        {
            return _bitmap.Width;
        }

        public void GetSize(out int width, out int height)
        {
            width = _bitmap.Width;
            height = _bitmap.Height;
        }
    }
}
