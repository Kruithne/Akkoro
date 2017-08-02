using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Akkoro Script Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void Status(string message)
        {
            _control.SetStatusText(message);
        }
    }
}
