using System;
using System.Xml.Serialization;

namespace wfaGameTrainerAccount
{
    internal class Game
    {
        public int CountCorrect { get; private set; }
        public int CountIncorrect { get; private set; }
        public string CodeText { get; private set; }

        private bool answerCorrect;

        internal void Reset()
        {
            CountCorrect = 0;
            CountIncorrect = 0;
            DoContinue();
        }

        private void DoContinue()
        {
            CodeText = "11 + 22 = 33";
            answerCorrect = true;
        }
        public void DoAnswer(bool answer)
        {
            if (answer == answerCorrect) {
                CountCorrect++;
            }
            else { 
                CountIncorrect++;
            }
            
            DoContinue();
        }
    }
}