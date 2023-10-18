using System;
using System.Xml.Serialization;

namespace wfaGameTrainerAccount
{
    internal class Game
    {
        private Random rnd = new Random();
        public int CountCorrect { get; private set; }
        public int CountIncorrect { get; private set; }
        public string CodeText { get; private set; }

        private bool answerCorrect;
        public int level = 1;

        public event EventHandler Change;
        internal void Reset()
        {
            CountCorrect = 0;
            CountIncorrect = 0;
            DoContinue();
        }

        private void DoContinue()
        {
            //CodeText = "11 + 22 = 33";
            //answerCorrect = true;
            int first = rnd.Next(50*level);
            int second = rnd.Next(50*level);
            int operation = rnd.Next(2);
            int result = first + second;
            if (operation == 0)
            {
                result = first - second;
            }
            
            int resultNew = result;
            if(rnd.Next(2) == 1) {
                resultNew += rnd.Next(1,10)*(rnd.Next(2) == 1? 1: -1);

            }
            answerCorrect =(result == resultNew);
            CodeText = $"{first} + {second} = {resultNew}";
            if (operation == 0)
            {
                CodeText = $"{first} - {second} = {resultNew}";
            }
            level = CountCorrect / 10 + 1;
            Change?.Invoke(this, EventArgs.Empty);
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