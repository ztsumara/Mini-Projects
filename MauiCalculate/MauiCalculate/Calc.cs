using System;

namespace MauiCalculate
{
    internal class Calc
    {
        private double firstNumber;

        public string CurText { get; private set; }
        public string CurHistory { get; private set; }
        public string CurOldHistory { get; private set; }
        public string CurOper { get; private set; }

        public event EventHandler Changed;

        internal void Clear()
        {
            firstNumber = 0;
            CurText = "";
            CurOper = "";
            CurHistory = "";
            CurOldHistory = "";
            Changed?.Invoke(this, EventArgs.Empty);
        }

        internal void PressNum(int num)
        {
            Changed?.Invoke(this, EventArgs.Empty);
            CurText += num.ToString();
            CurHistory += num.ToString();
            Changed?.Invoke(this, EventArgs.Empty);

        }
        internal void ClearC()
        {
            CurText="";
            CurHistory=CurOldHistory;
            Changed?.Invoke(this, EventArgs.Empty);
        }
        internal void PressOperator(string oper)
        {
            if (firstNumber != 0)
            {
                Calculate();
                return;
            }
            
            double.TryParse(CurText, out firstNumber);
            CurOper = oper;
            CurHistory += oper.ToString();
            CurOldHistory = CurHistory;
            CurText = "";
            Changed?.Invoke(this, EventArgs.Empty);
        }
        internal void ConvertToDot()
        {
            CurText += ",";
            CurHistory += ",";
            Changed?.Invoke(this, EventArgs.Empty);
        }
        internal void PressEqual(string oper)
        {
            Changed?.Invoke(this, EventArgs.Empty);

            CurHistory += oper.ToString();
            CurOldHistory = "";
            Calculate();
            CurOper = "";
            

        }
        internal void ChangePlus()
        {
            double.TryParse(CurText, out firstNumber);
            firstNumber *= -1;
            CurText = firstNumber.ToString();
            Changed?.Invoke(this, EventArgs.Empty);
        }
        private void Calculate()
        {
            if (double.TryParse(CurText, out double secondNumber))
            {
                switch (CurOper)
                {
                    case "+":
                        firstNumber += secondNumber;
                        break;
                    case "-":
                        firstNumber -= secondNumber;
                        break;
                    case "*":
                        firstNumber *= secondNumber;
                        break;
                    case "^":
                        firstNumber=Math.Pow(firstNumber,secondNumber);
                        break;
                    case "%":
                        firstNumber =firstNumber* secondNumber/100;
                        break;
                    case "//":
                        firstNumber = Math.Pow(firstNumber, 1/secondNumber);
                        break;
                    case "1/x":
                        firstNumber = 1/firstNumber;
                        break;
                    case "/":
                        if (secondNumber != 0)
                        {
                            firstNumber /= secondNumber;
                        }
                        else
                        {
                            CurText = "errrrror";
                            Clear();
                        }
                        break;
                }

                CurText = firstNumber.ToString();
                CurHistory = "";
                CurHistory += firstNumber.ToString();
                Changed?.Invoke(this, EventArgs.Empty);
                firstNumber = 0;
                CurText = "";
                CurOper = "";
                CurHistory = "";
                CurOldHistory = "";
            }
            else
            {
                switch (CurOper)
                {
                    
                    case "1/x":
                        firstNumber = 1 / firstNumber;
                        break; 
                   
                    
                }
                CurText = firstNumber.ToString();
                CurHistory = "";
                CurHistory += firstNumber.ToString();
                Changed?.Invoke(this, EventArgs.Empty);
                firstNumber = 0;
                CurText = "";
                CurOper = "";
                CurHistory = "";
                CurOldHistory = "";
                // Clear();
            }
        }

        internal void RemoveLastSymb()
        {
            if (!string.IsNullOrEmpty(CurText))
            {
                CurText = CurText.Remove(CurText.Length - 1);
                CurHistory = CurText.Remove(CurHistory.Length - 1);
                Changed?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}