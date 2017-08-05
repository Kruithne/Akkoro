using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Reflection;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using NLua;
using NLua.Exceptions;

namespace Akkoro
{
    public class ScriptEnvironment
    {
        private Lua _state;
        private Thread _thread;
        private Control_FlowListing _control;
        private ConcurrentQueue<LuaCallback> _callbackPipe;

        public bool IsActive { get; private set; }

        public ScriptEnvironment(Control_FlowListing control)
        {
            _control = control;
            _callbackPipe = new ConcurrentQueue<LuaCallback>();
        }

        public void Start()
        {
            // Prepare new Lua environment.
            _state = new Lua();
            IsActive = true;

            // Inject environment set-up script.
            Assembly asm = Assembly.GetExecutingAssembly();
            using (StreamReader reader = new StreamReader(asm.GetManifestResourceStream("Akkoro.environment.lua")))
                _state.DoString(reader.ReadToEnd());

            // Inject API functions.
            foreach (MethodInfo method in typeof(ScriptAPI).GetMethods())
            {
                // Skip base .NET functions we don't want to pass in.
                if (method.Name == "ToString" || method.Name == "Equals" || method.Name == "GetHashCode" || method.Name == "GetType")
                    continue;

                _state.RegisterFunction(method.Name, new ScriptAPI(this, _control), method);
            }

            _control.DisplayScriptEnabled();

            _thread = new Thread(Run);
            _thread.Start();
        }

        public void Stop(bool safe = false)
        {
            IsActive = false;

            if (!safe)
            {
                _control.SetStatusText("Stopping...");
                _callbackPipe = new ConcurrentQueue<LuaCallback>();
                new Thread(Terminate).Start();
            }
        }

        private void Run()
        {
            try
            {
                // Execute the initial file.
                _state.DoFile(_control.FilePath);

                // Process callbacks while the environment is active.
                while (IsActive)
                {
                    LuaCallback callback;
                    while (IsActive && _callbackPipe.TryDequeue(out callback))
                        callback.Chunk.Call(callback.Parameters);

                    Thread.Sleep(1);
                }
            }
            catch (LuaScriptException e)
            {
                OnScriptError(e);
            }
        }

        private void Terminate()
        {
            if (_thread != null)
            {
                while (_thread.IsAlive)
                    Thread.Sleep(100);

                _thread = null; // Drop reference.
            }

            _control.DisplayScriptDisabled();
        }

        public void QueueCallback(LuaFunction chunk, params object[] param)
        {
            // Prevent callbacks if this environment is inactive.
            if (!IsActive)
                return;

            _callbackPipe.Enqueue(new LuaCallback { Chunk = chunk, Parameters = param });
        }

        private void OnScriptError(LuaScriptException e)
        {
            Stop();
            _control.SetStatusText("Error");
            MessageBox.Show(e.Message, "Akkoro Script Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
