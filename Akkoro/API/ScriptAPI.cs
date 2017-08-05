using System.Drawing;
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

        public void SetScriptName(string name)
        {
            _control.SetScriptName(name);
        }

        public void Hook(string id, LuaFunction chunk)
        {
            _env.AddHook(id, chunk);
        }

        public void GetCursorPosition(out int x, out int y)
        {
            Point point = InteropsManager.CursorPosition;
            x = point.X;
            y = point.Y;
        }

        public void SetCursorPosition(int x, int y)
        {
            InteropsManager.SetCursorPos(x, y);
        }

        public void MoveCursor(int x, int y, int speed = 1, LuaFunction callback = null)
        {
            new CursorJourney(_env, x, y, speed, callback).Start();
        }

        public void StopMovingCursor()
        {
            CursorJourney.StopActiveJourney();
        }

        public void Stop()
        {
            _env.Stop();
        }

        public void Click(int scriptID = 1, int delay = 0)
        {
            MouseClickType clickType = MouseClickType.GetByScriptID(scriptID);
            if (clickType != null)
                clickType.SendClick(delay);
        }

        public void MouseDown(int scriptID = 1)
        {
            MouseClickType clickType = MouseClickType.GetByScriptID(scriptID);
            if (clickType != null)
                clickType.SendDown();
        }

        public void MouseUp(int scriptID = 1)
        {
            MouseClickType clickType = MouseClickType.GetByScriptID(scriptID);
            if (clickType != null)
                clickType.SendUp();
        }
    }
}
