using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Contour
{
    public partial class Form1 : Form
    {
        private bool dragging = false;
        Point startdrag = Point.Empty;
        private string fileName = string.Empty;
        
        

        List<Rectangle> rectangles = new List<Rectangle>();
        

        private Rectangle activeRectangle=Rectangle.Empty;
        private bool isResizing;
        private Point previousMouseLocation;
        private bool newRect = false;
        private bool createrect = false;
        private bool leftsize;
        private bool rightsize;
        private bool topsize;
        private bool botsize;
        private Point startPoint;
        private Point endPoint;
        private Rectangle oldRect= Rectangle.Empty;
        int placehover = 15;
        int penwidth = 3;




        public Form1()
        {
            InitializeComponent();

            this.KeyDown += Form1_KeyDown;
            
            panel1.MouseWheel += panel1_MouseWheel;
            pictureBox1.MouseDown += PictureBox1_MouseDown;
            pictureBox1.MouseMove += PictureBox1_MouseMove;
            pictureBox1.MouseUp += PictureBox1_MouseUp;
            buSaveObl.Click += BuSaveObl_Click;
            buSaveActiveObl.Click += BuSaveActiveObl_Click;
            pictureBox1.Paint += PictureBox1_Paint;
            buSave.Click += BuSave_Click;
            buCreateRect.Click += BuCreateRect_Click;
            buExportToFile.Click += BuExportToFile_Click;
            buImportFromFile.Click += BuImportFromFile_Click;
            
        }

        

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Delete)
            {
                if (activeRectangle != Rectangle.Empty)
                {
                    rectangles.Remove(activeRectangle);
                    pictureBox1.Invalidate();
                }
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------
        private void BuImportFromFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog import = new OpenFileDialog();
            import.Title = "Сохранить области как";
            
            import.CheckPathExists = true;

            import.Filter = "(*.txt)|*.txt";
            import.ShowHelp = true;
            DialogResult res = import.ShowDialog();
            if (res == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(import.FileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(new[] { ", " }, StringSplitOptions.None);
                        int x = int.Parse(parts[0].Split(new[] { ": " }, StringSplitOptions.None)[1]);
                        int y = int.Parse(parts[1]);
                        int width = int.Parse(parts[2].Split(new[] { ": " }, StringSplitOptions.None)[1]);
                        int height = int.Parse(parts[3]);
                        Rectangle rect = new Rectangle(x, y, width, height); // Ваш прямоугольник
                        rectangles.Add(rect);
                    }
                }
                pictureBox1.Invalidate();
            }
            else
            {
                MessageBox.Show("Картинка не выбрана!", "Выберите картинку!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }
        //-----------------------------------------------------------------------------------------------------------------------------
        private void BuExportToFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Сохранить области как";
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.CheckPathExists = true;

            saveFileDialog.Filter = "(*.txt)|*.txt";
            saveFileDialog.ShowHelp = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName, true))
                    {
                        foreach (Rectangle rect in rectangles)
                        {
                            sw.WriteLine($"Координаты: {rect.X}, {rect.Y}, Размеры: {rect.Width}, {rect.Height}");
                            this.Cursor= Cursors.WaitCursor;
                        }
                        this.Cursor = Cursors.Default;
                    }
                }
                catch
                {
                    MessageBox.Show("Невозможно сохранить изображение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
        }
        //-----------------------------------------------------------------------------------------------------------------------------
        private void BuSaveActiveObl_Click(object sender, EventArgs e)
        {
            if (activeRectangle != Rectangle.Empty)
            {
                Bitmap bmp = new Bitmap(activeRectangle.Width, activeRectangle.Height);

                
                Graphics g = Graphics.FromImage(bmp);

               
                g.DrawImage(pictureBox1.Image, 0, 0, activeRectangle, GraphicsUnit.Pixel);

                // Сохраните изображение
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Сохранить картинку как";
                saveFileDialog.OverwritePrompt = true;
                saveFileDialog.CheckPathExists = true;

                saveFileDialog.Filter = "Image Files(*.PNG)|*.png|Image Files(*.JPG)|*.jpg|All files(*.*)|*.*";
                saveFileDialog.ShowHelp = true;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        bmp.Save(saveFileDialog.FileName);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Нет активной области", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //-----------------------------------------------------------------------------------------------------------------------------
        private void BuSaveObl_Click(object sender, EventArgs e)
        {
            foreach (Rectangle rectangle in rectangles)
            {
                Bitmap bmp = new Bitmap(rectangle.Width, rectangle.Height);

                
                Graphics g = Graphics.FromImage(bmp);

                
                g.DrawImage(pictureBox1.Image, 0, 0, rectangle, GraphicsUnit.Pixel);

                // Сохраните изображение
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Сохранить картинку как";
                saveFileDialog.OverwritePrompt = true;
                saveFileDialog.CheckPathExists = true;

                saveFileDialog.Filter = "Image Files(*.PNG)|*.png|Image Files(*.JPG)|*.jpg|All files(*.*)|*.*";
                saveFileDialog.ShowHelp = true;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        bmp.Save(saveFileDialog.FileName);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        //-----------------------------------------------------------------------------------------------------------------------------
        private void BuCreateRect_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Выделите область", "Создание области", MessageBoxButtons.OK);
            newRect = true;
        }
        //-----------------------------------------------------------------------------------------------------------------------------
        
        //-----------------------------------------------------------------------------------------------------------------------------


        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Red, penwidth);




            if (rectangles.Count > 0)
            {
                foreach (Rectangle rectangle in rectangles)
                {
                    if (rectangle == activeRectangle)
                    {
                        Pen foractive = new Pen(Color.LightSeaGreen, penwidth);
                        foractive.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                        e.Graphics.DrawRectangle(foractive, rectangle);
                    }
                    else
                    {
                        e.Graphics.DrawRectangle(pen, rectangle);
                    }
                }
            }



            
        }
        //-----------------------------------------------------------------------------------------------------------------------------
        private void BuSave_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Сохранить картинку как";
                saveFileDialog.OverwritePrompt = true;
                saveFileDialog.CheckPathExists = true;

                saveFileDialog.Filter = "Image Files(*.PNG)|*.png|Image Files(*.JPG)|*.jpg|All files(*.*)|*.*";
                saveFileDialog.ShowHelp = true;
                if(saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pictureBox1.Image.Save(saveFileDialog.FileName);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        //-----------------------------------------------------------------------------------------------------------------------------


        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Middle)
            {
                dragging = false;
                pictureBox1.Cursor = Cursors.Default;
            }
            if (e.Button == MouseButtons.Right)
            {
               
                isResizing = false;
                newRect = false;
                createrect = false;
                oldRect = Rectangle.Empty;
            }
            if (e.Button == MouseButtons.Left)
            {

                leftsize =rightsize=topsize=botsize= false;
                pictureBox1.Cursor = Cursors.Default;
            }
        }
        //-----------------------------------------------------------------------------------------------------------------------------
        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Control c = sender as Control;
            if (dragging && pictureBox1 != null)
            {
                c.Top += e.Y - startdrag.Y;
                c.Left += e.X - startdrag.X;
            }
            if (createrect)
            {
                if (oldRect != Rectangle.Empty)
                {
                    rectangles.Remove(oldRect);
                }
                endPoint = e.Location;
                Point center = new Point((startPoint.X + endPoint.X) / 2, (startPoint.Y + endPoint.Y) / 2);
                Size rectSize = new Size(Math.Abs(startPoint.X - endPoint.X), Math.Abs(startPoint.Y - endPoint.Y));
                Rectangle rect = new Rectangle(center, rectSize);
                oldRect = rect;
                rectangles.Add(rect);
                pictureBox1.Invalidate();
            }
            else if (isResizing)
            {
                rectangles.Remove(activeRectangle);
                int deltaX = e.X - previousMouseLocation.X;
                int deltaY = e.Y - previousMouseLocation.Y;

                activeRectangle.X += deltaX;
                activeRectangle.Y += deltaY;
                rectangles.Add(activeRectangle);
                
                previousMouseLocation = e.Location;
                pictureBox1.Invalidate();
            }
            else
            {
                if (leftsize || rightsize || topsize || botsize)
                {

                   

                    rectangles.Remove(activeRectangle);
                    endPoint = e.Location;
                    if (leftsize)
                    {
                            activeRectangle.X -= ((startPoint.X - endPoint.X) );
                            activeRectangle.Width += ((startPoint.X - endPoint.X) );
                    }
                    if (rightsize)
                    {
                        
                        activeRectangle.Width -= ((startPoint.X - endPoint.X));
                    }
                    if (topsize)
                    {
                        activeRectangle.Y -= ((startPoint.Y - endPoint.Y));
                        activeRectangle.Height += ((startPoint.Y - endPoint.Y));
                    }
                    if (botsize)
                    {
                        
                        activeRectangle.Height -= ((startPoint.Y - endPoint.Y));
                    }

                    rectangles.Remove(activeRectangle);
                   

                    
                    rectangles.Add(activeRectangle);
                    pictureBox1.Invalidate();
                    startPoint=e.Location; ;
                }
            }
            if (activeRectangle != Rectangle.Empty)
            {
                if ((e.X > activeRectangle.Left - placehover) && (e.X < activeRectangle.Left + placehover) && (e.Y > activeRectangle.Top - placehover) && (e.Y < activeRectangle.Top + placehover))
                {
                    pictureBox1.Cursor = Cursors.SizeNWSE;
                }
                else if ((e.X > activeRectangle.Left - placehover) && (e.X < activeRectangle.Left + placehover)&& (e.Y > activeRectangle.Bottom - placehover) && (e.Y < activeRectangle.Bottom + placehover))
                {
                    pictureBox1.Cursor = Cursors.SizeNESW;
                }
                else if ((e.X > activeRectangle.Right - placehover) && (e.X < activeRectangle.Right + placehover) && (e.Y > activeRectangle.Bottom - placehover) && (e.Y < activeRectangle.Bottom + placehover))
                {
                    pictureBox1.Cursor = Cursors.SizeNWSE;
                }
                else if ((e.X > activeRectangle.Right - placehover) && (e.X < activeRectangle.Right + placehover) && (e.Y > activeRectangle.Top - placehover) && (e.Y < activeRectangle.Top + placehover))
                {
                    pictureBox1.Cursor = Cursors.SizeNESW;
                }
                else if ((e.X > activeRectangle.Right - placehover) && (e.X < activeRectangle.Right + placehover))
                {
                    pictureBox1.Cursor = Cursors.SizeWE;
                }
                else if ((e.Y > activeRectangle.Top - placehover) && (e.Y < activeRectangle.Top + placehover))
                {
                    pictureBox1.Cursor = Cursors.SizeNS;
                }
                else if ((e.Y > activeRectangle.Bottom - placehover) && (e.Y < activeRectangle.Bottom + placehover))
                {
                    pictureBox1.Cursor = Cursors.SizeNS;
                }
                else if ((e.X > activeRectangle.Left - placehover) && (e.X < activeRectangle.Left + placehover))
                {
                    pictureBox1.Cursor = Cursors.SizeWE;
                }
                else
                {
                    if (!(leftsize|| rightsize|| topsize|| botsize))
                    {
                        pictureBox1.Cursor = Cursors.Default;
                    }
                }
            }
            

        }
        //-----------------------------------------------------------------------------------------------------------------------------
        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            
            if (e.Button == MouseButtons.Middle)
            {
                pictureBox1.Cursor = Cursors.SizeAll;
                dragging = true;
                startdrag.X = e.X;
                startdrag.Y = e.Y;
            }


            if (e.Button == MouseButtons.Left)
            {
                if (activeRectangle != Rectangle.Empty)
                {
                    if((e.X>activeRectangle.Left-placehover)&& (e.X < activeRectangle.Left + placehover))
                    {
                        leftsize = true;
                        startPoint = e.Location;
                    }
                    if((e.X > activeRectangle.Right - placehover) && (e.X < activeRectangle.Right + placehover))
                    {
                        rightsize = true;
                        startPoint = e.Location;
                    }
                    if((e.Y > activeRectangle.Top - placehover) && (e.Y < activeRectangle.Top + placehover) )
                    {
                        topsize = true;
                        startPoint = e.Location;
                    }
                    if((e.Y > activeRectangle.Bottom - placehover) && (e.Y < activeRectangle.Bottom + placehover))
                    {
                        botsize = true;
                        startPoint = e.Location;
                    }
                   
                }
                
            }

            if (e.Button == MouseButtons.Right)
            {
                if (newRect) 
                {
                    startPoint = e.Location;
                    createrect = true;
                }
                //if (rect.Contains(e.Location))
                //{
                //    isResizing = true;
                //    previousMouseLocation = e.Location;
                //}




                foreach (Rectangle rectangle in rectangles)
                {

                    if (rectangle.Contains(e.Location))
                    {
                        activeRectangle = rectangle;
                        previousMouseLocation = e.Location;
                        
                        isResizing = true;
                        pictureBox1.Invalidate();
                        return;
                    }
                }

                activeRectangle = Rectangle.Empty;
                pictureBox1.Invalidate();

            }

            
        }
        //-----------------------------------------------------------------------------------------------------------------------------
        private void panel1_MouseWheel(object sender, MouseEventArgs e)
        {
            

            float zoomratio = (float)(e.Delta > 0 ? 1.15 : 0.85);
            pictureBox1.Width = (int)(pictureBox1.Width * zoomratio);
            pictureBox1.Height = (int)(pictureBox1.Height * zoomratio);
            pictureBox1.Top = (int)(e.Y - zoomratio * (e.Y - pictureBox1.Top));
            pictureBox1.Left = (int)(e.X - zoomratio * (e.X - pictureBox1.Left));

            //rectangles= new List<Rectangle>();
            if (checkBox1.CheckState == CheckState.Checked)
            {
                FindObjects();
            }
            else
            {
                rectangles= new List<Rectangle>();
            }
            
        }
        //-----------------------------------------------------------------------------------------------------------------------------
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //-----------------------------------------------------------------------------------------------------------------------------
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
        //-----------------------------------------------------------------------------------------------------------------------------

        private void buFindObjects_Click(object sender, EventArgs e)
        {
            FindObjects();




        }
        //-----------------------------------------------------------------------------------------------------------------------------
        private void FindObjects()
        {
            rectangles= new List<Rectangle>();
            
            Bitmap image = new Bitmap(pictureBox1.Image);
            
            
            //----------------------------------------------------------------------
            Point p = pictureBox1.PointToClient(Cursor.Position);
            Point unscaled_p = new Point();

            // image and container dimensions
            int w_i = pictureBox1.Image.Width;
            int h_i = pictureBox1.Image.Height;
            int w_c = pictureBox1.Width;
            int h_c = pictureBox1.Height;
            float filler = 0;
            float imageRatio = w_i / (float)h_i; // image W:H ratio
            float containerRatio = w_c / (float)h_c; // container W:H ratio

            if (imageRatio >= containerRatio)
            {
                // horizontal image
                float scaleFactor = w_c / (float)w_i;
                float scaledHeight = h_i * scaleFactor;
                // calculate gap between top of container and top of image
                filler = Math.Abs(h_c - scaledHeight) / 2;
                unscaled_p.X = (int)(p.X / scaleFactor);
                unscaled_p.Y = (int)((p.Y - filler) / scaleFactor);
            }
            else
            {
                // vertical image
                float scaleFactor = h_c / (float)h_i;
                float scaledWidth = w_i * scaleFactor;
                filler = Math.Abs(w_c - scaledWidth) / 2;
                unscaled_p.X = (int)((p.X - filler) / scaleFactor);
                unscaled_p.Y = (int)(p.Y / scaleFactor);
            }
            //----------------------------------------------------------------------

            float coefx = (float)(pictureBox1.Width-filler*2) / image.Width;

            float coefy = (float)pictureBox1.Height / image.Height;

            
            Bitmap image1 = new Bitmap(pictureBox1.Image);
            Graphics g = Graphics.FromImage(image);
            


            int x = 0;
            int y = 0;
            float fonebrightness = (float)(getBrightFone() - 0.3);
            // Проход по всем пикселям изображения
            while (x < image.Width)
            {
                y = 0;
                while (y < image.Height)
                {
                    
                    Color pixelColor = image.GetPixel(x, y);

                    // Проверка, является ли пиксель темным
                    if (pixelColor.GetBrightness() < fonebrightness)
                    {


                        int x1 = x;
                        int y1 = y;

                        int width = 0;
                        int height = 0;
                        while ((image.GetPixel(x, y).GetBrightness() < fonebrightness) && x < image.Width)
                        {
                            width++;
                            x++;
                        }
                        x--;
                        x = x - width / 2;
                        while ((image.GetPixel(x, y).GetBrightness() < fonebrightness) && y > 0)
                        {

                            y--;
                        }
                        y1 = y;
                        y++;
                        while ((image.GetPixel(x, y).GetBrightness() < fonebrightness) && y < image.Height)
                        {
                            height++;
                            y++;
                        }
                        float xx = x1;

                        Point center = new Point(x1 - 2, y1 - 2);
                        Size rectSize = new Size(width + 4, height + 4);
                        Rectangle rect = new Rectangle(center, rectSize);
                        SolidBrush brush = new SolidBrush(Color.White);
                        g.FillRectangle(brush, rect);
                        center = new Point(Convert.ToInt32(x1 * coefx) + Convert.ToInt32(filler) - 2, Convert.ToInt32(y1 * coefy) - 2);
                        rectSize = new Size(Convert.ToInt32((width) * coefx) + 4, Convert.ToInt32((height) * coefy) + 4);
                        rect = new Rectangle(center, rectSize);
                        rectangles.Add(rect);


                        //// Обновление координат и размеров прямоугольника
                        //if (x < minX)
                        //    minX = x;
                        //if (x > maxX)
                        //    maxX = x;
                        //if (y < minY)
                        //    minY = y;
                        //if (y > maxY)
                        //    maxY = y;

                    }
                    y++;


                }
                x++;


            }

            // Вычисление координат центра прямоугольника
            //int centerX = (minX + maxX) / 2;
            //int centerY = (minY + maxY) / 2;

            //// Вычисление размеров прямоугольника
            //int width = maxX - minX + 1;
            //int height = maxY - minY + 1;
            //int a = pictureBox1.Width / pictureBox1.Height;
            //Point center = new Point(centerX - width / 2, centerY - height / 2);
            //Size rectSize = new Size(width + 1, height + 1);
            //Rectangle rect = new Rectangle(center, rectSize);
            //rectangles.Add(rect);

            //pictureBox1.Height = pictureBox1.Image.Height; pictureBox1.Width=pictureBox1.Image.Width;


            pictureBox1.Image = image1;
        }
        //-----------------------------------------------------------------------------------------------------------------------------
        private float getBrightFone()
        {
            Bitmap image = new Bitmap(pictureBox1.Image);
            Color backgroundColor1 = image.GetPixel(1, 1);
            Color backgroundColor2 = image.GetPixel(1, image.Height-1);
            Color backgroundColor3 = image.GetPixel(image.Width-1, image.Height-1);
            Color backgroundColor4 = image.GetPixel(image.Width - 1, 1);
            float res = (backgroundColor1.GetBrightness()+ backgroundColor2.GetBrightness()+backgroundColor3.GetBrightness()+backgroundColor4.GetBrightness())/4;
            return res;
        }
        //-----------------------------------------------------------------------------------------------------------------------------
    }
}
