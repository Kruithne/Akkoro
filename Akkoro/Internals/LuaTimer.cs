using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using NLua;

namespace Akkoro
{
    class LuaTimer : Timer
    {
        public LuaFunction Chunk { get; set; }
        public bool IsRepeating { get; set; }

        public LuaTimer(int delay, LuaFunction chunk)
        {
            Chunk = chunk;
            Interval = delay;
        }
    }
}
