using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Jarvis_Mk3
{
    class Program
    {
        static ServiceHandler serviceHandler;
        static void Main(string[] args)
        {
            serviceHandler = new ServiceHandler();
            Thread t_SpeechRec = new Thread((new Speech.JarvisSpeechRec()).start);
            Thread t_SpeechSynth = new Thread((new Speech.JarvisSpeechSynth(serviceHandler)).start);
            t_SpeechRec.Start();
            t_SpeechSynth.Start();
            

            
            //Speech.SpeechSynth.speechRun = false;
        }
    }
}
