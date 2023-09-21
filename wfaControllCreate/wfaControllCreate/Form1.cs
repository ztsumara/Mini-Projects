using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfaControllCreate
{
    public partial class Form1 : Form
    {
        private Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
            this.MouseDown += Form1_MouseDown;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left )
            {
                Label x = new Label();
                x.Location = e.Location;
                x.Text = $"{e.X},{e.Y}";
                x.Text = e.Location.ToString();
                x.BackColor = System.Drawing.SystemColors.ActiveCaption; ;
                x.AutoSize = true;
                this.Controls.Add( x );

            }
            if (e.Button == MouseButtons.Right)
            {
                Label x = new Label();

                x.Location = new Point(rnd.Next(this.ClientSize.Width), rnd.Next(this.ClientSize.Height));
                x.Text = $"{x.Location.X},{x.Location.Y}";
                x.Text = e.Location.ToString();
                x.BackColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)) ;
                
                x.AutoSize = true;
                this.Controls.Add(x);

            }
            if (e.Button == MouseButtons.Middle)
            {
                this.Controls.Clear();
            }
            this.Text=$"{Application.ProductName} : count = {this.Controls.Count}";
        }
            
    }
}
