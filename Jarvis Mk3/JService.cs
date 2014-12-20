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
        ServiceHandler handler;
        String name;

        public abstract void onStart();
        public abstract void onStop();
        public abstract void pause();
        public abstract void onPause();

        public JService(String name, ServiceHandler handler)
        {
            this.name = name;
            this.handler = handler;
        }

        public void setId(long id)
        {
            this.id = id;
        }
        
        public long getId()
        {
            return id;
        }

        public void start()
        {


        }

        public void stop()
        {

        }

    }
}
