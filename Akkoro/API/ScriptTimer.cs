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
        private LuaTimer _timer;

        public ScriptTimer(ScriptEnvironment env, int delay, LuaFunction chunk)
        {
            _timer = new LuaTimer(delay, chunk);
            _timer.Elapsed += env.ScriptTimer_Elapsed;
        }

        public void SetDelay(int delay)
        {
            _timer.Interval = delay;
        }

        public void SetFunction(LuaFunction chunk)
        {
            _timer.Chunk = chunk;
        }

        public void Start()
        {
            _timer.IsRepeating = false;
            _timer.Start();
        }

        public void StartRepeating()
        {
            _timer.IsRepeating = true;
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }
    }
}
