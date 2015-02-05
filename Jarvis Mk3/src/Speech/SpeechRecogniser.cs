using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Speech.Recognition;


namespace Jarvis_Mk3.Speech
{
    public class JarvisSpeechRec 
    {
        static SpeechRecognitionEngine jarvisRecogniser;

        static Grammar grammar_default;
        static Grammar grammar_maingui;
        
        const int GRAMMAR_DEFAULT = 0;
        const int GRAMMAR_MAINGUI = 1;
        bool stop = false;

        List<SpeechListener> mListeners = new List<SpeechListener>();


        public JarvisSpeechRec()
        {
            jarvisRecogniser = new SpeechRecognitionEngine();

            jarvisRecogniser.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(speechRecognised);

            /*
            GrammarBuilder build = new GrammarBuilder();
            
            build.Append(new Choices("hello", "stop"));
            //build.Append("stop");

              */

            GrammarBuilder defaultBuild = new GrammarBuilder();

            jarvisRecogniser.LoadGrammar(new Grammar(".\\Speech\\grammar.xml"));
            //Grammar defaultGrammar = new Grammar();
            //jarvisRecogniser.LoadGrammar(defaultGrammar);

            jarvisRecogniser.SetInputToDefaultAudioDevice();


        }

        public void start()
        {
            while (!stop)
            {
                jarvisRecogniser.Recognize();
            }
        }


        public static void setGrammar(int grammarSetId)
        {
            //Swap out current recogniser grammar
            switch (grammarSetId)
            {
                case (GRAMMAR_DEFAULT): { break; }
                case (GRAMMAR_MAINGUI): { break; }
            }
        }

        private void speechRecognised(object sender, SpeechRecognizedEventArgs args)
        {
            Console.WriteLine(args.Result.Text);
            if (args.Result.Text.Contains("stop"))
                stop = true;
            else
            {
                foreach (SpeechListener listener in mListeners)
                {
                    listener.speechRecognised(args);
                }
            }
        }

        public void addListener()
        {

        }

    }
}
