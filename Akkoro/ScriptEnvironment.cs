using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using NLua;
using NLua.Exceptions;

namespace Akkoro
{
    public class ScriptEnvironment
    {
        private static string[] Blacklist = { "luanet", "os", "package" };

        private Lua _state;
        private ScriptAPI _api;
        private Control_FlowListing _control;

        public ScriptEnvironment(Control_FlowListing control)
        {
            _control = control;
            _api = new ScriptAPI(this, control);
        }

        public void Activate()
        {
            _state = GetNewEnvironment();

            try
            {
                _control.SetActive();
                _state.DoFile(_control.FilePath);
            }
            catch (LuaScriptException e)
            {
                _control.SetInactive();
                _control.SetStatusText("Error");
                _api.ShowError(e.Message);
            }
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
    }
}
