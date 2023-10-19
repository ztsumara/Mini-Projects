using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfaFormTransparency
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Click += (s, e) => this.Close();
            this.FormBorderStyle = FormBorderStyle.None;
            this.TransparencyKey = this.BackColor;
            
        }

        }


}
