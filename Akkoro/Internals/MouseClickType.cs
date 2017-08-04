using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Akkoro
{
    public class MouseClickType
    {
        private static Dictionary<int, MouseClickType> _index = new Dictionary<int, MouseClickType>();

        public static MouseClickType LEFT = new MouseClickType(1) { EventDown = 0x02, EventUp = 0x04 };
        public static MouseClickType RIGHT = new MouseClickType(2) { EventDown = 0x08, EventUp = 0x10 };
        public static MouseClickType MIDDLE = new MouseClickType(3) { EventDown = 0x20, EventUp = 0x40 };

        public int ScriptID { get; private set; }
        public uint EventDown { get; private set; }
        public uint EventUp { get; private set; }

        private MouseClickType(int scriptID)
        {
            ScriptID = scriptID;
            _index.Add(scriptID, this);
        }

        public void SendClick(int delay = 0)
        {
            if (delay > 0)
            {
                SendDown();
                Thread.Sleep(delay);
                SendUp();
            }
            else
            {
                InteropsManager.SendMouseEvent(EventDown | EventUp);
            }
        }

        public void SendDown()
        {
            InteropsManager.SendMouseEvent(EventDown);
        }

        public void SendUp()
        {
            InteropsManager.SendMouseEvent(EventUp);
        }

        public static MouseClickType GetByScriptID(int scriptID)
        {
            return _index[scriptID] ?? null;
        }
    }
}
