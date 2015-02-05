using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Speech.Synthesis;

using Jarvis_Mk3.Util.Service;

namespace Jarvis_Mk3.Speech
{
    class JarvisSpeechSynth : JService
    {
        SpeechSynthesizer jarvisSpeech;
        public static bool speechRun = true;
        Queue<String> speechItems = new Queue<string>();

        public JarvisSpeechSynth(ServiceHandler handler) : base(handler)
        {
            jarvisSpeech = new SpeechSynthesizer();
            jarvisSpeech.SelectVoice("Microsoft Zira Desktop");
        }

        public override void run(){
            while (speechRun)
            {
                if (speechItems.Count > 0)
                {
                    jarvisSpeech.Speak((string)speechItems.Dequeue());
                }
                Thread.Sleep(500);
            }
        }

        public override void onStop()
        {
            speechRun = false;


        }

        public override void onStart()
        {
            speakItem("Speech Synthesiser up and ready.");
        }

        public void speakItem(string item)
        {
            speechItems.Enqueue(item);
        }

    }
}
