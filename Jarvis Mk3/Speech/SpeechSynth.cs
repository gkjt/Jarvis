using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Speech.Synthesis;

namespace Jarvis_Mk3.Speech
{
    class JarvisSpeechSynth
    {
        SpeechSynthesizer jarvisSpeech;
        public static bool speechRun = true;
        Queue<String> speechItems = new Queue<string>();

        public JarvisSpeechSynth()
        {
            jarvisSpeech = new SpeechSynthesizer();
            jarvisSpeech.SelectVoice("Microsoft Zira Desktop");
            speakItem("Speech Synthesiser up and ready.");

        }

        public void start(){
            while (speechRun)
            {
                if (speechItems.Count > 0)
                {
                    jarvisSpeech.Speak((string)speechItems.Dequeue());
                }
                Thread.Sleep(1000);
            }
        }

        public void speakItem(string item)
        {
            speechItems.Enqueue(item);
        }

    }
}
