using Jarvis_Mk3.Util.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Jarvis_Mk3
{
    public class ServiceHandler
    {
        public SortedList<long, JService> ServiceList;
        public SortedList<long, Thread> ThreadList;

        long idCounter = 0;

        public ServiceHandler()
        {
            ServiceList = new SortedList<long, JService>();
            ThreadList = new SortedList<long, Thread>();
        }

        public void registerService(JService service){
            service.setId(idCounter++);
            ServiceList.Add(service.getId(), service);
        }

        public void setStarted(JService service)
        {


        }

        public void forceStopService(JService service)
        {
            Thread threadToEnd;
            ThreadList.TryGetValue(service.getId(), out threadToEnd);

        }
    }
}
