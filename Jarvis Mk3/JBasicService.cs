using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jarvis_Mk3.Util.Service
{
    abstract class JBasicService : JService
    {
        public JBasicService(String name, ServiceHandler handler)
        {

        }

        public override void start()
        {
            handler.setStarted(this);
            onStart();
        }

    }
}
