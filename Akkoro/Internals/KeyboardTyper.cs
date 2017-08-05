using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Akkoro
{
    struct KeyAction
    {
        public Keys Key;
        public bool Up;
        public bool Down;
    }

    class KeyboardInput
    {
        private const int KEY_EVENT_DOWN = 0x0001 | 0;
        private const int KEY_EVENT_UP = 0x0001 | 0x0002;

        private static KeyboardInput _activeTyper;

        private int _holdTime;
        private int _spacingTime;

        private bool _active;
        private Queue<KeyAction> _keyQueue;

        public void Run()
        {
            // Iterate all keys in the queue (while active).
            while (_keyQueue.Count > 0 && _active)
            {
                KeyAction action = _keyQueue.Dequeue();

                if (action.Down)
                    InteropsManager.SendKeyEvent(action.Key, KEY_EVENT_DOWN);

                if (action.Up)
                {
                    // Only do the _holdTime delay if we're holding and releasing.
                    if (action.Down)
                        Thread.Sleep(_holdTime);

                    InteropsManager.SendKeyEvent(action.Key, KEY_EVENT_UP);

                    // Only do the _spacingTime delay if there's more in the queue.
                    if (_keyQueue.Count > 0)
                        Thread.Sleep(_spacingTime);
                }
            }

            // Set as no longer active.
            _active = false;
        }

        public void TypeKeys(string input, int holdTime = 50, int spacingTime = 100)
        {
            PrepareTyping(holdTime, spacingTime);

            // Push all valid keys into the queue.
            string[] keys = input.Split(' ', ',');
            foreach (string keyStr in keys)
            {
                bool justUp = false;
                bool justDown = false;

                char firstChar = keyStr[0];
                if (firstChar == '!')
                    justUp = true;
                else if (firstChar == '^')
                    justDown = true;
               
                Keys key = StringToKey((justUp || justDown) ? keyStr.Substring(1) : keyStr);
                if (key != Keys.None)
                    _keyQueue.Enqueue(new KeyAction() { Key = key, Up = !justDown, Down = !justUp });
            }

            // Execute the processing on another thread.
            new Thread(Run).Start();
        }

        public void TypeString(string input, int holdTime = 50, int spacingTime = 100)
        {
            PrepareTyping(holdTime, spacingTime);

            bool isHoldingShift = false;

            // Process all characters in the string and push to queue.
            for (int i = 0; i < input.Length; i++)
            {
                KeyMap map = KeyMap.GetKey(input[i]);
                if (map != null)
                {
                    // Toggle shift-state accordingly.
                    if (map.IsUpper && !isHoldingShift)
                    {
                        _keyQueue.Enqueue(new KeyAction() { Key = Keys.LShiftKey, Up = false, Down = true });
                        isHoldingShift = true;
                    }
                    else if (!map.IsUpper && isHoldingShift)
                    {
                        _keyQueue.Enqueue(new KeyAction() { Key = Keys.LShiftKey, Up = true, Down = false });
                        isHoldingShift = false;
                    }

                    _keyQueue.Enqueue(new KeyAction() { Key = map.Key, Up = true, Down = true });
                }
            }

            // Execute the processing on another thread.
            new Thread(Run).Start();
        }

        private void PrepareTyping(int holdTime, int spacingTime)
        {
            // Cancel any active typing.
            StopTyping();

            _keyQueue = new Queue<KeyAction>(); // New queue for input.
            _activeTyper = this; // Set this instance as the active typer.
            _active = true; // Set this instance as active.

            // Store interval timings.
            _holdTime = holdTime;
            _spacingTime = spacingTime;
        }

        public static void KeyDown(params string[] keys)
        {
            foreach (string keyStr in keys)
            {
                Keys key = StringToKey(keyStr);
                if (key != Keys.None)
                    InteropsManager.SendKeyEvent(key, KEY_EVENT_DOWN);
            }    
        }

        public static void KeyUp(params string[] keys)
        {
            foreach (string keyStr in keys)
            {
                Keys key = StringToKey(keyStr);
                if (key != Keys.None)
                    InteropsManager.SendKeyEvent(key, KEY_EVENT_UP);
            }
        }

        private static Keys StringToKey(string id)
        {
            Keys key;
            if (Enum.TryParse(id, true, out key))
                return key;

            return Keys.None;
        }

        public static void StopTyping()
        {
            if (_activeTyper != null && _activeTyper._active)
                _activeTyper._active = false;
        }
    }
}
