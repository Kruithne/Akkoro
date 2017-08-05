using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using NLua;

namespace Akkoro
{
    public class ScriptTimer
    {
        private Timer _timer;
        private LuaFunction _chunk;
        private ScriptEnvironment _env;
        private bool _repeating;

        public ScriptTimer(ScriptEnvironment env, int delay, LuaFunction chunk)
        {
            _timer = new Timer(delay);
            _timer.Elapsed += OnScriptTimerElapsed;

            _chunk = chunk;
            _env = env;
        }

        private void OnScriptTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (!_env.IsActive)
            {
                // Environment is disposed, stop the timer.
                _timer.Stop();
                return;
            }

            // Invoke the callback in the environment.
            _env.QueueCallback(_chunk);

            // If we're not repeating, stop the timer.
            if (!_repeating)
                _timer.Stop();
        }

        public void SetDelay(int delay)
        {
            _timer.Interval = delay;
        }

        public void SetFunction(LuaFunction chunk)
        {
            _chunk = chunk;
        }

        public void Start()
        {
            _repeating = false;
            _timer.Start();
        }

        public void StartRepeating()
        {
            _repeating = true;
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }
    }
}
