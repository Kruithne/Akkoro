using System.Drawing;
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

        public void SetScriptName(string name)
        {
            _control.SetScriptName(name);
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

        public void KeyDown(params string[] keys)
        {
            KeyboardInput.KeyDown(keys);
        }

        public void KeyUp(params string[] keys)
        {
            KeyboardInput.KeyUp(keys);
        }

        public void TypeKeys(string input, int holdTime = 50, int spacingTime = 100)
        {
            new KeyboardInput().TypeKeys(input, holdTime, spacingTime);
        }

        public void TypeString(string input, int holdTime = 50, int spacingTime = 100)
        {
            new KeyboardInput().TypeString(input, holdTime, spacingTime);
        }

        public LuaTable GetScreens()
        {
            Screen[] screens = Screen.AllScreens;
            LuaTable table = _env.CreateTable();

            for (int i = 0; i < screens.Length; i++)
                table[i + 1] = new ScriptScreen(screens[i]);

            return table;
        }

        public ScriptScreen GetPrimaryScreen()
        {
            return new ScriptScreen(Screen.PrimaryScreen);
        }

        public ScriptScreen GetScreenAtPoint(int x, int y)
        {
            return new ScriptScreen(Screen.FromPoint(new Point(x, y)));
        }
    }
}
