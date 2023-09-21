using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Click += ButtonAll_Click;
            button2.Click += ButtonAll_Click;
            checkBox1.Click += ButtonAll_Click;
        }

        private void ButtonAll_Click(object sender, EventArgs e)
        {
            //if(sender is Control)
            //{
            //    MessageBox.Show(((Control)sender).Text);
            //}
            if(sender is Control c)
            {
                MessageBox.Show(c.Text);
            }
        }


       
    }
}
