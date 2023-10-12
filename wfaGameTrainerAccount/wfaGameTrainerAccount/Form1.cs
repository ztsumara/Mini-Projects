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
            g.Reset();
        }

        
    }
}
