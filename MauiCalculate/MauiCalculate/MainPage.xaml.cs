namespace MauiCalculate
{
    public partial class MainPage : ContentPage
    {
        Calc calc = new();
    
        public MainPage()
        {
            InitializeComponent();


            calc.Changed += (s, e) => laDisplay.Text = calc.CurText;
            calc.Changed += (s, e) => laHistory.Text = calc.CurHistory;

            buNumCE.Clicked += (s, e) => calc.Clear();
            buNumC.Clicked += (s, e) => calc.ClearC(); 
            buNum0.Clicked += (s, e) => calc.PressNum(0);
            buNum1.Clicked += (s, e) => calc.PressNum(1);
            buNum2.Clicked += (s, e) => calc.PressNum(2);
            buNum3.Clicked += (s, e) => calc.PressNum(3);
            buNum4.Clicked += (s, e) => calc.PressNum(4);
            buNum5.Clicked += (s, e) => calc.PressNum(5);
            buNum6.Clicked += (s, e) => calc.PressNum(6);
            buNum7.Clicked += (s, e) => calc.PressNum(7);
            buNum8.Clicked += (s, e) => calc.PressNum(8);
            buNum9.Clicked += (s, e) => calc.PressNum(9);
            
            //buDiv.Clicked += (s, e) => calc.PressOperator("div");
            //buMul.Clicked += (s, e) => calc.PressOperator("mul");
            //buSub.Clicked += (s, e) => calc.PressOperator("sub");
            //buSum.Clicked += (s, e) => calc.PressOperator("sum");

            buDiv.Clicked += (s, e) => calc.PressOperator("/");
            buSqrt.Clicked += (s, e) => calc.PressOperator("//");
            ChangePlus.Clicked += (s, e) => calc.ChangePlus();
            buDrob.Clicked += (s, e) => calc.PressOperator("1/x");
            buProcent.Clicked += (s, e) => calc.PressOperator("%");
            buDot.Clicked += (s, e) => calc.ConvertToDot();
            buMul.Clicked += (s, e) => calc.PressOperator("*");
            buSub.Clicked += (s, e) => calc.PressOperator("-");
            buSum.Clicked += (s, e) => calc.PressOperator("+");
            buBackSp.Clicked += (s, e) => calc.RemoveLastSymb();
            buEq.Clicked += (s, e) => calc.PressEqual("=");
            buPow.Clicked += (s, e) => calc.PressOperator("^");
        }

       
    }
}