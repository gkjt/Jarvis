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
            lock (this)
            {
                service.Id = idCounter++;
            }
            ServiceList.Add(service.Id, service);
        }


        public void forceStopService(JService service)
        {
            Thread threadToEnd;
            try
            {
                ThreadList.TryGetValue(service.Id, out threadToEnd);
                threadToEnd.Abort();
                removeService(service);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Force Stop Failed: " + e.ToString());
            }
        }

        public void removeService(JService service)
        {
            ThreadList.Remove(service.Id);
            ServiceList.Remove(service.Id);
        }


    }
}
