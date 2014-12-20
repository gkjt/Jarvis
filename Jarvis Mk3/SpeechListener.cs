using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;

namespace Jarvis_Mk3.Speech
{
    public abstract class SpeechListener
    {
        public abstract bool speechRecognised(SpeechRecognizedEventArgs recognisedSpeech);
        

    }
}
