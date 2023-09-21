using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WfaEventKey
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.KeyDown += Form1_KeyDown;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("Нажата клавиша Enter");
            }
            switch (e.KeyCode)
            {
                case Keys.Left:
                    MyText.Text = "Left";
                    break;
                case Keys.Right:
                    MyText.Text = "Right";
                    break;
                case Keys.Up:
                    MyText.Text = "Up";
                    break;
                case Keys.Down:
                    MyText.Text = "Down";
                    break;
                case Keys.Space:
                    if (e.Shift)
                    {
                        MyText.Text = "Shift + space";
                    }
                    else
                    {
                        MyText.Text = "Space";
                    }
                    break;
                case Keys.Z:
                    MyText.Text = e.Shift? "Shift + z": "z";
                    break;
                default:
                    MyText.Text = $"Другая клавиша {e.KeyCode}";
                    break;

            }
        }
    }
}
