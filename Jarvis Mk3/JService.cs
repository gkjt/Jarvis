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
        private long _id;
        public long Id
        {
            get { return _id; }
            set { this._id = Id; }
        }
        private bool _running;
        public bool Running
        {
            get { return _running; }
            private set { this._running = Running; }
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
            _running = true;
            onStart();
            run();
            onStop();
            _running = false;
        }

        public void stop()
        {
            onStop();
            _running = false;
            handler.removeService(this);
        }
    }
}
