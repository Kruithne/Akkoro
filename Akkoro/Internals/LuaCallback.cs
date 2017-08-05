using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLua;

namespace Akkoro
{
    public struct LuaCallback
    {
        public LuaFunction Chunk;
        public object[] Parameters;
    }
}
