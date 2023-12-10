using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Contour
{
    public partial class Form1 : Form
    {
        private string fileName = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buOpen_Click(object sender, EventArgs e)
        {
            DialogResult res = openFileDialog1.ShowDialog();
            if(res == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
                pictureBox1.Image=Image.FromFile(fileName);
            }
            else
            {
                MessageBox.Show("Картинка не выбрана!", "Выберите картинку!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void buFindObjects_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(pictureBox1.Image);
            int flag = 0;
            Graphics graphics = Graphics.FromImage(image);

            int minX = image.Width;
            int minY = image.Height;
            int maxX = 0;
            int maxY = 0;

            // Проход по всем пикселям изображения
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixelColor = image.GetPixel(x, y);

                    // Проверка, является ли пиксель темным
                    if (pixelColor.GetBrightness() < 0.8)
                    {
                        // Обновление координат и размеров прямоугольника
                        if (x < minX)
                            minX = x;
                        if (x > maxX)
                            maxX = x;
                        if (y < minY)
                            minY = y;
                        if (y > maxY)
                            maxY = y;
                        
                    }
                  
                }
                
            }

            // Вычисление координат центра прямоугольника
            int centerX = (minX + maxX) / 2;
            int centerY = (minY + maxY) / 2;

            // Вычисление размеров прямоугольника
            int width = maxX - minX + 1;
            int height = maxY - minY + 1;

            Point center = new Point(centerX-width/2, centerY-height/2);
            Size rectSize = new Size(width+1, height+1);
            Rectangle rect = new Rectangle(center, rectSize);
            Pen pen = new Pen(Color.Red, 5);
            graphics.DrawRectangle(pen, rect);
                       

            
            pictureBox1.Image = image;
        }

        private void findObject(Point p)
        {
           
        }
    }
}
