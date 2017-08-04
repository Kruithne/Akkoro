using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NLua;

namespace Akkoro
{
    public class CursorJourney
    {
        private int _destX;
        private int _destY;

        private int _startX;
        private int _startY;

        private int _speed;

        private Thread _thread;
        private LuaFunction _callback;
        private ScriptEnvironment _env;

        public CursorJourney(ScriptEnvironment env, int destX, int destY, int speed = 1, LuaFunction callback = null)
        {
            _destX = destX;
            _destY = destY;
            _speed = speed;
            _callback = callback;
            _env = env;
        }

        public void Start()
        {
            Point startPos = InteropsManager.CursorPosition;
            _startX = startPos.X;
            _startY = startPos.Y;

            _thread = new Thread(Run);
            _thread.Start();
        }

        public void Terminate()
        {
            if (_thread != null)
                _thread.Abort();
        }

        private void Run()
        {
            double distX = Math.Abs(_destX - _startX);
            double distY = Math.Abs(_destY - _startY);

            double stepDistX = 5 * _speed;
            double stepDistY = 5 * _speed;

            if (distX > distY)
                stepDistY *= distY / distX;
            else if (distY < distX)
                stepDistX *= distX / distY;

            double stepX = stepDistX * (_destX > _startX ? 1 : -1);
            double stepY = stepDistY * (_destY > _startY ? 1 : -1);

            double currX = _startX;
            double currY = _startY;

            while (distX > 0 || distY > 0)
            {
                if (distX > 0)
                {
                    distX -= stepDistX;
                    currX += stepX;
                }
                else
                {
                    // Assurance that once the journey is over, we'll be in the place we want.
                    currX = _destX;
                }

                if (distY > 0)
                {
                    distY -= stepDistY;
                    currY += stepY;
                }
                else
                {
                    // Assurance that once the journey is over, we'll be in the place we want.
                    currY = _destY;
                }

                InteropsManager.SetCursorPos((int) currX, (int) currY);
                Thread.Sleep(10);
            }

            // Invoke callback
            if (_callback != null)
                _env.SafeCall(_callback);
        }
    }
}
