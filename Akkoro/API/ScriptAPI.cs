using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
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

        public void GetColorAt(int x, int y, out int r, out int g, out int b)
        {
            Color pixel = InteropsManager.GetColorAt(x, y);
            r = pixel.R;
            g = pixel.G;
            b = pixel.B;
        }

        public bool FileExists(string path)
        {
            return File.Exists(path);
        }

        public bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        public bool CreateDirectory(string path)
        {
            try
            {
                Directory.CreateDirectory(path);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CreateFile(string file)
        {
            try
            {
                File.Create(file);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(string path)
        {
            try
            {
                if (FileExists(path))
                {
                    File.Delete(path);
                    return true;
                }
                else if (DirectoryExists(path))
                {
                    Directory.Delete(path);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public LuaTable ListDirectory(string path)
        {
            LuaTable table = _env.CreateTable();
            int index = 1;

            foreach (string entry in Directory.EnumerateFileSystemEntries(path))
                table[index++] = entry;

            return table;
        }

        public string ReadFile(string path)
        {
            return File.ReadAllText(path);
        }

        public void WriteFile(string path, string data)
        {
            File.WriteAllText(path, data);
        }

        public ScriptImage LoadImage(string path)
        {
            return new ScriptImage(new Bitmap(path));
        }

        public ScriptImage Capture(int x, int y, int width, int height)
        {
            Bitmap img = new Bitmap(width, height);
            using (Graphics gfx = Graphics.FromImage(img))
                gfx.CopyFromScreen(x, y, 0, 0, img.Size, CopyPixelOperation.SourceCopy);

            return new ScriptImage(img);
        }

        public void HookKey(int key, LuaFunction chunk)
        {
            _env.HookKey(key, chunk);
        }

        public ScriptProcess Process()
        {
            return new ScriptProcess(System.Diagnostics.Process.GetCurrentProcess());
        }

        public ScriptProcess ProcessByID(int id)
        {
            return new ScriptProcess(System.Diagnostics.Process.GetProcessById(id));
        }

        public LuaTable ProcessByName(string name)
        {
            LuaTable table = _env.CreateTable();

            int index = 1;
            foreach (Process proc in System.Diagnostics.Process.GetProcessesByName(name))
                table[index++] = new ScriptProcess(proc);

            return table;
        }

        public LuaTable ProcessList()
        {
            LuaTable table = _env.CreateTable();

            int index = 1;
            foreach (Process proc in System.Diagnostics.Process.GetProcesses())
                table[index++] = new ScriptProcess(proc);

            return table;
        }

        public void Sleep(int time)
        {
            Thread.Sleep(time);
        }

        public void CopyToClipboard(string text)
        {
            Thread thread = new Thread(() => Clipboard.SetText(text));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
        }
    }
}
