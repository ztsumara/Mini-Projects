namespace pazzle
{
    public partial class Form1 : Form
    {
        private  PictureBox[,] px;
        private int cellWight;
        private int cellHeight;
        private Point startMouseDown;
        private int STEP = 10;

        public int Rows { get; private set;  } = 3;
        public int Cols { get; private set;  } = 6;
        
        public Form1()
        {
            InitializeComponent();
            createCells();
            ResizeCells();
            this.ResizeEnd += (s, e) => ResizeCells();
            this.KeyDown += PictureBoxAll_KeyDown;
        }

        private void PictureBoxAll_KeyDown(object? sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    StartLocationCells();
                    break;
                case Keys.F2:
                    ResizeCells();
                    break;
                case Keys.F3:

                    break;
                case Keys.F4:
                    break;
            }
        }

        private void StartLocationCells()
        {
            for (int r = 0; r < Rows; r++)
                for (int c = 0; c < Cols; c++)
                {
                    px[r,c].Location = new Point(c*cellWight, r*cellHeight);
                }
        }
        private void ResizeCells()
        {
            cellWight = this.ClientSize.Width/Cols;
            cellHeight = this.ClientSize.Height / Rows;
            for (int r = 0; r < Rows; r++)
                for (int c = 0; c < Cols; c++)
                {
                    px[r, c].Width = cellWight;
                    px[r, c].Height = cellHeight;
                    px[r,c].Location = new Point(c*cellWight, r*cellHeight);
                    px[r,c].Image = new Bitmap(cellWight, cellHeight);
                    var g = Graphics.FromImage(px[r,c].Image);
                    g.DrawImage(
                        Properties.Resources.hi,
                        new Rectangle(0, 0, cellWight, cellHeight),
                        new Rectangle(c * cellWight, r * cellHeight, cellWight, cellHeight),
                        GraphicsUnit.Pixel
                        );
                    g.DrawString($"[{r},{c}]",
                        new Font("", 20),
                        new SolidBrush(Color.Black),
                        new Rectangle(0, 0, cellWight, cellHeight),
                        new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    g.Dispose();
                }

        }

        private void createCells()
        {
            px = new PictureBox[Rows, Cols];

            for (int r = 0; r < Rows; r++)
                for (int c = 0; c < Cols; c++)
                {
                    px[r, c] = new PictureBox();
                    px[r, c].BorderStyle = BorderStyle.FixedSingle;
                    px[r, c].Tag = (r, c);
                    px[r, c].MouseDown += PictureBoxAll_MouseDown;
                    px[r, c].MouseMove += PictureBoxAll_MouseMove;
                    px[r, c].MouseUp += PictureBoxAll_MouseUp;
                    this.Controls.Add(px[r, c]);
                }
        }

        private void PictureBoxAll_MouseUp(object? sender, MouseEventArgs e)
        {
            if (sender is Control v)
            {
                v.Cursor = Cursors.Default;
                if(e.Button == MouseButtons.Left)
                {
                    var p = v.Location;
                    for (int r = 0; r < Rows; r++)
                        for (int c = 0; c < Cols; c++)
                        {
                            if (p.X > c * cellWight - STEP && p.X < c* cellWight + STEP)
                            {
                                p.X = c * cellWight;

                            }
                            if (p.Y > r * cellHeight - STEP && p.Y < r* cellHeight + STEP)
                            {
                                p.Y = r * cellHeight;
                            }
                        }
                    v.Location = p;

                    CheckCell(v);
                }
                
            }
        }

        private void CheckCell(Control v)
        {
            (int r, int c) = ((int, int))v.Tag;
            if (v.Location == new Point(c* cellWight, r * cellHeight))
            {
                MessageBox.Show("+");
            }
        }

        private void PictureBoxAll_MouseMove(object? sender, MouseEventArgs e)
        {
            if (sender is Control v)
            {
                if (e.Button == MouseButtons.Left)
                {
                    v.Location = new Point(
                        v.Location.X + e.X - startMouseDown.X,
                        v.Location.Y + e.Y - startMouseDown.Y);
                }
            }
        }

        private void PictureBoxAll_MouseDown(object? sender, MouseEventArgs e)
        {
            if (sender is PictureBox v)
            {
                startMouseDown = e.Location;
                v.BringToFront();
                v.Cursor = Cursors.SizeAll;
                if (e.Button == MouseButtons.Right)
                {
                    v.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    v.Invalidate();
                }
            }
            
        }
    }
}