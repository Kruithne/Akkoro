using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Akkoro
{
    class TerminationThread
    {
        private Thread _thread;
        private Control_FlowListing _control;

        public TerminationThread(Thread thread, Control_FlowListing control)
        {
            _thread = thread;
            _control = control;
        }

        public void Begin()
        {
            new Thread(Run).Start();
        }

        public void Run()
        {
            _thread.Abort();

            while (_thread.IsAlive)
                Thread.Sleep(500);

            _control.DisplayScriptDisabled();
        }
    }
}
