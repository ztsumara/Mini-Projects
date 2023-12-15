using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace Translate_rus_to_num
{
    public partial class Form1 : Form
    {
        enum NumberType {Ones, Uniq, Tens, Hundred, Zero};

        private NumberType Typeof(string word)
        {
            if (word == "ноль" || word == "нуль")
                return NumberType.Zero;
            if (hundreds.ContainsKey(word))
                return NumberType.Hundred;
            if (ones.ContainsKey(word))
                return NumberType.Ones;
            if (tens.ContainsKey(word))
                return NumberType.Tens;
            
            return NumberType.Uniq;
        }

      
        readonly Dictionary<string, int> ones = new Dictionary<string, int>(9)
        {
            ["один"] = 1,
            ["два"] = 2,
            ["три"] = 3,
            ["четыре"] = 4,
            ["пять"] = 5,
            ["шесть"] = 6,
            ["семь"] = 7,
            ["восемь"] = 8,
            ["девять"] = 9
        };

        readonly Dictionary<string, int> uniq = new Dictionary<string, int>(10)
        {
            ["десять"] = 10,
            ["одиннадцать"] = 11,
            ["двенадцать"] = 12,
            ["тринадцать"] = 13,
            ["четырнадцать"] = 14,
            ["пятнадцать"] = 15,
            ["шестнадцать"] = 16,
            ["семнадцать"] = 17,
            ["восемнадцать"] = 18,
            ["девятнадцать"] = 19
        };

        readonly Dictionary<string, int> tens = new Dictionary<string, int>(8)
        {
            ["двадцать"] = 20,
            ["тридцать"] = 30,
            ["сорок"] = 40,
            ["пятьдесят"] = 50,
            ["шестьдесят"] = 60,
            ["семьдесят"] = 70,
            ["восемьдесят"] = 80,
            ["девяносто"] = 90
        };

        readonly Dictionary<string, int> hundreds = new Dictionary<string, int>(9)
        {
            ["сто"] = 100,
            ["двести"] = 200,
            ["триста"] = 300,
            ["четыреста"] = 400,
            ["пятьсот"] = 500,
            ["шестьсот"] = 600,
            ["семьсот"] = 700,
            ["восемьсот"] = 800,
            ["девятьсот"] = 900
        };
        public Form1()
        {
            InitializeComponent();
            textBoxAnswer.ForeColor = Color.Silver;
            textBoxAnswer.Text = "ответ";
            textBoxError.ForeColor = Color.Silver;
            textBoxError.Text = "ошибки";
            this.BackColor = Color.FromArgb(180, 230, 250);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            textBoxAnswer.ForeColor = Color.Silver;
            textBoxAnswer.Text = "ответ";
            
            textBoxError.Text = string.Empty;
            string s = textBox1.Text.Trim().ToLower();
            if (s == string.Empty)
            {
                textBoxError.Text = string.Empty;
                textBoxError.ForeColor = Color.Black;
                textBoxError.AppendText($"Введена пустая строка. \r\n");
                return;
            }
            while (s.Contains("  "))
                s = s.Replace("  ", " ");
            string[] words = s.Split();

            foreach (string word in words)
            {
                if (!(word == "hundred" || word == "ноль" || word == "нуль" || ones.ContainsKey(word)
                    || tens.ContainsKey(word) || uniq.ContainsKey(word) || hundreds.ContainsKey(word)))
                {
                    //MessageBox.Show($"Ошибка в слове {word}", "Error!");
                    textBoxError.ForeColor = Color.Black;
                    textBoxError.AppendText($"Орфографическая ошибка в слове '{word}'. \r\n");
                }
            }

            int cnt = 0;
            NumberType curr = Typeof(words[0]);
            for (int i = 0; i < words.Length - 1; i++)
            {
                NumberType next = Typeof(words[i + 1]);
                textBoxError.ForeColor = Color.Black;
                switch (curr)
                {
                    case NumberType.Zero:
                        textBoxError.AppendText($"Синтаксическая ошибка: после нуля не может ничего стоять. \r\n");
                        break;

                    case NumberType.Hundred:
                        cnt++;
                        if (next == NumberType.Zero)
                        {
                            textBoxError.AppendText($"Синтаксическая ошибка: ноль не может стоять после сотен. \r\n");
                        }
                        else if (next == NumberType.Hundred)
                        {
                            textBoxError.AppendText($"Синтаксическая ошибка: повторение сотен. \r\n");
                        }
                        break;

                    case NumberType.Ones:
                        if (next == NumberType.Zero)
                        {
                            textBoxError.AppendText($"Синтаксическая ошибка: ноль не может стоять после числа единичного формата. \r\n");
                        }
                        else if (next == NumberType.Ones)
                        {
                            textBoxError.AppendText($"Синтаксическая ошибка: числа единичного формата не могут стоять рядом. \r\n");
                        }
                        else if (next == NumberType.Uniq)
                        {
                            textBoxError.AppendText($"Синтаксическая ошибка: после числа единичного формата не может стоять никакое другое число. \r\n");
                        }
                        else if (next == NumberType.Tens)
                        {
                            textBoxError.AppendText($"Синтаксическая ошибка: после числа единичного формата не может стоять число десятичного формата. \r\n");
                        }
                        else if (next == NumberType.Hundred)
                        {
                            textBoxError.AppendText($"Синтаксическая ошибка: после числа единичного формата не могут стоять сотни \r\n");
                        }
                        break;
                    
                    case NumberType.Uniq:
                        if (next == NumberType.Zero)
                        {
                            textBoxError.AppendText($"Синтаксическая ошибка: ноль не может стоять после числа формата 10-19. \r\n");
                        }
                        else if (next == NumberType.Uniq)
                        {
                            textBoxError.AppendText($"Синтаксическая ошибка: числа формата 10-19 не могут стоять рядом. \r\n");
                        }
                        else if (next == NumberType.Ones)
                        {
                            textBoxError.AppendText($"Синтаксическая ошибка: после числа формата 10-19 не может стоять число единичного формата. \r\n");
                        }
                        else if (next == NumberType.Tens)
                        {
                            textBoxError.AppendText($"Синтаксическая ошибка: после числа формата 10-19 не может стоять число десятичного формата. \r\n");
                        }
                        else if (next == NumberType.Hundred)
                        {
                            textBoxError.AppendText($"Синтаксическая ошибка: после числа формата 10-19 не моут стоять сотни. \r\n");
                        }
                        break;

                    case NumberType.Tens:
                        if (next == NumberType.Zero)
                        {
                            textBoxError.AppendText($"Синтаксическая ошибка: ноль не может стоять после числа десятичного формата. \r\n");
                        }
                        else if (next == NumberType.Tens)
                        {
                            textBoxError.AppendText($"Синтаксическая ошибка: числа десятичного формата не могут стоять рядом. \r\n");
                        }
                        else if (next == NumberType.Uniq)
                        {
                            textBoxError.AppendText($"Синтаксическая ошибка: после числа десятичного формата не может стоять число формата 10-19. \r\n");
                        }
                        else if (next == NumberType.Hundred)
                        {
                            textBoxError.AppendText($"Синтаксическая ошибка: после числа десятичного формата не могут стоять сотни. \r\n");
                        }
                        break;
                    default:
                        textBoxError.ForeColor = Color.Silver;
                        break;
                }
                if(textBoxError.Text != string.Empty)
                {
                    break;
                }
                curr = next;
                
            }
            

            if (textBoxError.Text != string.Empty)
            {
                textBoxError.Visible = true;
                return;
            }

            int ans = 0;
            foreach (string word in words)
            {
                switch (Typeof(word))
                {
                    case NumberType.Zero:
                        ans = 0;
                        break;

                    case NumberType.Ones:
                        ans += ones[word];
                        break;

                    case NumberType.Uniq:
                        ans += uniq[word];
                        break;

                    case NumberType.Tens:
                        ans += tens[word];
                        break;

                    case NumberType.Hundred:
                        ans += hundreds[word];
                        break;

                }
            }

            if (ans.ToString() != string.Empty)
            {
                textBoxAnswer.ForeColor = Color.Black;
                textBoxAnswer.Text = ans.ToString();
                textBoxAnswer.Visible = true;
            }
            if (textBoxError.Text == string.Empty)
            {
                textBoxError.ForeColor = Color.Silver;
                textBoxError.Text = "ошибки";
            }
            
        }

        private void textBoxError_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxAnswer_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = textBox1.Text.Trim().Length != 0;
        }

    }
}
