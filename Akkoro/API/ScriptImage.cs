using System;
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

        public int GetPixelCount()
        {
            return GetWidth() * GetHeight();
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
                    if (firstPixel.A == 0 || GetColorAt(x, y) == firstPixel)
                        if (Match(x, y, image, out fX, out fY))
                            return true;

            return false;
        }

        public bool LocateColor(double r, double g, double b, float threshold, out int fX, out int fY)
        {
            fX = -1;
            fY = -1;

            Color match = Color.FromArgb((int)r, (int)g, (int)b);
            for (int x = 0; x < GetWidth(); x++)
            {
                for (int y = 0; y < GetHeight(); y++)
                {
                    Color pixel = GetColorAt(x, y);
                    fX = x;
                    fY = y;

                    if (threshold == 0f)
                    {
                        if (pixel == match)
                            return true;
                    }
                    else
                    {
                        double proxR = Math.Abs(r - pixel.R) / 255;
                        double proxG = Math.Abs(g - pixel.G) / 255;
                        double proxB = Math.Abs(b - pixel.B) / 255;

                        if (proxR <= threshold && proxG <= threshold && proxB <= threshold)
                            return true;
                    }
                }
            }

            return false;
        }

        public Color GetColorAverage()
        {
            int[] avg = new int[] { 0, 0, 0 };
            for (int x = 0; x < GetWidth(); x++)
            {
                for (int y = 0; y < GetHeight(); y++)
                {
                    Color pixel = GetColorAt(x, y);
                    avg[0] += pixel.R;
                    avg[1] += pixel.G;
                    avg[2] += pixel.B;
                }
            }

            int pixelCount = GetPixelCount();
            return Color.FromArgb(avg[0] / pixelCount, avg[1] / pixelCount, avg[2] / pixelCount);
        }
    }
}
