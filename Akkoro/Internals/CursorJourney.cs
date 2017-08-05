using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
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

        private bool _active;
        private static CursorJourney _activeJourney;

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
            // Ensure we interrupt another CursorJourney if there is one.
            StopActiveJourney();

            // Register this as the active journey.
            _activeJourney = this;
            _active = true;

            // Cache the current cursor position.
            Point startPos = InteropsManager.CursorPosition;
            _startX = startPos.X;
            _startY = startPos.Y;

            // Begin the movement thread.
            _thread = new Thread(Run);
            _thread.Start();
        }

        private void Run()
        {
            // Distance between the start point, and destination point.
            double distX = Math.Abs(_destX - _startX);
            double distY = Math.Abs(_destY - _startY);

            // How much distance we'll cover per tick.
            double stepDistX = 5 * _speed;
            double stepDistY = 5 * _speed;

            // Process both axis at the same speed by slowing down the shorter distance.
            if (distX > distY)
                stepDistY *= distY / distX;
            else if (distY > distX)
                stepDistX *= distX / distY;

            // Calculate which direction each axis will go in.
            double stepX = stepDistX * (_destX > _startX ? 1 : -1);
            double stepY = stepDistY * (_destY > _startY ? 1 : -1);

            double currX = _startX;
            double currY = _startY;

            while (_active && (distX > 0 || distY > 0))
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

            // Only invoke the callback if we're still active.
            if (_active && _callback != null)
                _env.QueueCallback(_callback);

            _active = false;
        }

        public static void StopActiveJourney()
        {
            if (_activeJourney != null && _activeJourney._active)
                _activeJourney._active = false;
        }
    }
}
