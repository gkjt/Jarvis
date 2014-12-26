using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Jarvis_Mk3.Util.Service
{
    public abstract class JService
    {
        long id
        {
            get;
            set;
        }

        bool running
        {
            get;
            set;
        }

        ServiceHandler handler;

        public abstract void onStart();
        public abstract void onStop();
        public abstract void run();

        public JService(ServiceHandler handler)
        {
            this.handler = handler;
        }

        public void start()
        {
            running = true;
            onStart();
            run();
            onStop();
            running = false;
        }

        public void stop()
        {
            onStop();
            running = false;
            handler.removeService(this);
        }
    }
}
