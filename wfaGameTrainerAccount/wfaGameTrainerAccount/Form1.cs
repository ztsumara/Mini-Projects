using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfaGameTrainerAccount
{
    public partial class Form1 : Form
    {
        private readonly Game g;

        public Form1()
        {
            InitializeComponent();
            g = new Game();
            g.Change += G_Change;
            g.Reset();

            buYes.Click += (s, e) => g.DoAnswer(true);
            buNo.Click += (s, e) => g.DoAnswer(false);
        }

        private void G_Change(object sender, EventArgs e)
        {
            laTrue.Text = $"Верно = {g.CountCorrect}";
            laFalse.Text = $"Неверно = {g.CountIncorrect}";
            laCode.Text = g.CodeText;
            laLevel.Text = $"Уровень: {g.level}";
        }
    }
}
