using System.Drawing;

namespace Akkoro
{
    public class ScriptImage
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

        public void Save(string path)
        {
            _bitmap.Save(path);
        }

        public void GetSize(out int width, out int height)
        {
            width = _bitmap.Width;
            height = _bitmap.Height;
        }

        private bool Match(int oX, int oY, ScriptImage image, out int fX, out int fY)
        {
            fX = oX;
            fY = oY;

            if (GetWidth() - oX <= image.GetWidth())
                return false;

            if (GetHeight() - oY <= image.GetHeight())
                return false;

            for (int x = 0; x < image.GetWidth(); x++)
            {
                for (int y = 0; y < image.GetHeight(); y++)
                {
                    Color imageColor = image.GetColorAt(x, y);
                    if (imageColor.A > 0 && GetColorAt(oX + x, oY + y) != imageColor)
                        return false;
                }
            }

            return true;
        }

        public bool Locate(ScriptImage image, out int fX, out int fY)
        {
            fX = -1;
            fY = -1;

            Color firstPixel = image.GetColorAt(0, 0);
            for (int x = 0; x < GetWidth(); x++)
                for (int y = 0; y < GetHeight(); y++)
                    if (GetColorAt(x, y) == firstPixel)
                        if (Match(x, y, image, out fX, out fY))
                            return true;

            return false;
        }
    }
}
