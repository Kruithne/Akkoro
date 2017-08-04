using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLua;

namespace Akkoro
{
    class ScriptAPI
    {
        private ScriptEnvironment _env;
        private Control_FlowListing _control;

        public ScriptAPI(ScriptEnvironment env, Control_FlowListing control)
        {
            _env = env;
            _control = control;
        }

        public ScriptTimer After(int delay, LuaFunction chunk)
        {
            ScriptTimer timer = Timer(delay, chunk);
            timer.Start();

            return timer;
        }

        public ScriptTimer Every(int delay, LuaFunction chunk)
        {
            ScriptTimer timer = Timer(delay, chunk);
            timer.StartRepeating();

            return timer;
        }

        public ScriptTimer Timer(int delay, LuaFunction chunk)
        {
            return new ScriptTimer(_env, delay, chunk);
        }

        public void Status(string message)
        {
            _control.SetStatusText(message);
        }

        public void Hook(string id, LuaFunction chunk)
        {
            _env.AddHook(id, chunk);
        }

        public int GetCursorPosition(out int y)
        {
            Point point = InteropsManager.CursorPosition;
            y = point.Y;
            return point.X;
        }

        public void SetCursorPosition(int x, int y)
        {
            InteropsManager.SetCursorPos(x, y);
        }

        public void MoveCursor(int x, int y, int speed = 1, LuaFunction callback = null)
        {
            _env.StartCursorJourney(new CursorJourney(_env, x, y, speed));
        }

        public void StopMovingCursor()
        {
            _env.TerminateCursorJourney();
        }
    }
}
