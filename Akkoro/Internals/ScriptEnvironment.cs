﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Timers;
using System.Windows.Forms;
using NLua;
using NLua.Exceptions;

namespace Akkoro
{
    public class ScriptEnvironment
    {
        private static string[] Blacklist = { "luanet", "os", "package", "print", "import" };

        private Lua _state;
        private ScriptAPI _api;
        private Control_FlowListing _control;
        private bool _disposed;

        private CursorJourney _activeCursorJourney;
        private Dictionary<string, List<LuaFunction>> _hooks;

        public ScriptEnvironment(Control_FlowListing control)
        {
            _control = control;
            _api = new ScriptAPI(this, control);
        }

        public void Activate()
        {
            _hooks = new Dictionary<string, List<LuaFunction>>();
            _state = GetNewEnvironment();

            try
            {
                _control.EnableScript();
                _state.DoFile(_control.FilePath);
            }
            catch (LuaScriptException e)
            {
                OnScriptError(e);
            }
        }

        public void TriggerEvent(string id, params object[] param)
        {
            if (_hooks.ContainsKey(id))
                foreach (LuaFunction chunk in _hooks[id])
                    if (!SafeCall(chunk, param))
                        return;
        }

        public bool SafeCall(LuaFunction chunk, params object[] param)
        {
            try
            {
                chunk.Call(param);
                return true;
            }
            catch (LuaScriptException e)
            {
                OnScriptError(e);
            }
            return false;
        }

        private void OnScriptError(LuaScriptException e)
        {
            _hooks.Clear();
            _control.DisableScript();
            _control.SetStatusText("Error");
            MessageBox.Show(e.Message, "Akkoro Script Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void AddHook(string id, LuaFunction chunk)
        {
            if (!_hooks.ContainsKey(id))
                _hooks[id] = new List<LuaFunction>();

            _hooks[id].Add(chunk);
        }

        public void StartCursorJourney(CursorJourney journey)
        {
            TerminateCursorJourney();
            _activeCursorJourney = journey;
            _activeCursorJourney.Start();
        }

        public void TerminateCursorJourney()
        {
            if (_activeCursorJourney == null)
                return;

            _activeCursorJourney.Terminate();
            _activeCursorJourney = null;
        }

        public void Flush()
        {
            TriggerEvent("SCRIPT_STOPPED");
            TerminateCursorJourney();
            _hooks.Clear(); // Clear event hooks.
            _disposed = true;
        }

        private Lua GetNewEnvironment()
        {
            Lua state = new Lua();

            // Remove unwanted things from global environment.
            foreach (string badFunction in Blacklist)
                state.DoString(badFunction + " = nil;");

            // Inject API functions.
            foreach (MethodInfo method in typeof(ScriptAPI).GetMethods())
            {
                // Skip base .NET functions we don't want to pass in.
                if (method.Name == "ToString" || method.Name == "Equals" || method.Name == "GetHashCode" || method.Name == "GetType")
                    continue;

                state.RegisterFunction(method.Name, _api, method);
            }

            return state;
        }

        public void ScriptTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            LuaTimer timer = (LuaTimer)sender;

            if (_disposed)
            {
                // Environment is disposed, don't process timer tickks.
                timer.Stop();
                return;
            }

            if (!SafeCall(timer.Chunk))
                timer.Stop();

            if (!timer.IsRepeating)
                timer.Stop();
        }
    }
}
