using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Media;
using System.Numerics;
using System.Security.Policy;


namespace SnakeGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly Dictionary<gridValue, ImageSource> gridValToImage = new()
        {
            {gridValue.Empty, Images.Empty },
            {gridValue.Snake, Images.Body },
            {gridValue.Food, Images.Food },
            {gridValue.BadFood, Images.BadFood }
        };
        private bool soundOn = true;
        private readonly Dictionary<Direction, int> dirToRotation = new()
        {
            {Direction.Up, 180 },
            {Direction.Down, 0 },
            {Direction.Left, 90 },
            {Direction.Right, 270 }
        };


        MediaPlayer main = new MediaPlayer();


        private int speed = 200;
        private readonly int rows = 15, cols = 20;
        private readonly Image[,] gridImages;
        
        private Game game;
        private bool gameRunning;
        private int maxScore = 0;

        public MainWindow()
        {
            InitializeComponent();
            Sounds.GameOver.Load();
            main.Open(new Uri("main.wav",UriKind.Relative));
            Sounds.Fone.Load();
            Sounds.Fone.PlayLooping();
            // Устанавливаем громкость
            main.Volume = 0.5;


            inst.Visibility = Visibility.Hidden;
            GridBorder.Visibility= Visibility.Hidden;
            ScoreText.Visibility= Visibility.Hidden;
            Overlay.Visibility= Visibility.Hidden;
            easy.Click += Easy_Click;
            exit.Click += Exit_Click;
            medium.Click += Medium_Click;
            hard.Click += Hard_Click;
            walls.Click += Walls_Click;
            close.Click += Close_Click;
            sound.Click += Sound_Click;
            instruction.Click += Instruction_Click;
            gridImages = SetupGrid();
            game= new Game(rows, cols);
        }

        private void Sound_Click(object sender, RoutedEventArgs e)
        {
            soundOn = !soundOn;
            if (soundOn)
            {
                soundText.Text = "Музыка вкл.";
                
                main.Volume = 0.5;
                Sounds.Fone.PlayLooping();

            }
            else
            {
                soundText.Text = "Музыка выкл.";
                main.Volume = 0;
                Sounds.Fone.Stop();

            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Instruction_Click(object sender, RoutedEventArgs e)
        {
            inst.Visibility = Visibility.Visible;
            
            Menu.Visibility = Visibility.Hidden;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            inst.Visibility= Visibility.Hidden;
            
            Menu.Visibility = Visibility.Visible;
        }

        private void Walls_Click(object sender, RoutedEventArgs e)
        {
            if (game.wallsIsOn)
            {
                WallsOn.Text = "Стенки выключены";
            }
            else
            {
                WallsOn.Text = "Стенки включены";
            }
            game.wallsIsOn = !game.wallsIsOn;
        }

        private void Hard_Click(object sender, RoutedEventArgs e)
        {
            game.scoreOfBadFood = 1;
            game.speedDelta = 15;
            if (Menu.Visibility == Visibility.Visible)
            {
                e.Handled = true;
                Menu.Visibility = Visibility.Hidden;
                GridBorder.Visibility = Visibility.Visible;
                ScoreText.Visibility = Visibility.Visible;
                Overlay.Visibility = Visibility.Visible;
            }
        }

        private void Medium_Click(object sender, RoutedEventArgs e)
        {
            game.scoreOfBadFood = 3;
            game.speedDelta = 8;
            if (Menu.Visibility == Visibility.Visible)
            {
                e.Handled = true;
                Menu.Visibility = Visibility.Hidden;
                GridBorder.Visibility = Visibility.Visible;
                ScoreText.Visibility = Visibility.Visible;
                Overlay.Visibility = Visibility.Visible;
            }
        }

        private async void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Menu.Visibility != Visibility.Visible)
            {
                

                if (Overlay.Visibility == Visibility.Visible)
                {
                    e.Handled = true;
                }

                if (!gameRunning)
                {
                    
                    gameRunning = true;
                    await RunGame();
                    gameRunning = false;
                }
            }
        }

        private void Easy_Click(object sender, RoutedEventArgs e)
        {
            game.scoreOfBadFood = 5;
            game.speedDelta = 2;
            if (Menu.Visibility == Visibility.Visible)
            {
                e.Handled = true;
                Menu.Visibility = Visibility.Hidden;
                GridBorder.Visibility = Visibility.Visible;
                ScoreText.Visibility = Visibility.Visible;
                Overlay.Visibility = Visibility.Visible;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (game.IsGameOver)
            {
                return;
            }
            switch (e.Key)
            {
                case Key.Left:
                    game.ChangeDir(Direction.Left);
                    break;
                case Key.Right:
                    game.ChangeDir(Direction.Right);
                    break;
                case Key.Up:
                    game.ChangeDir(Direction.Up);
                    break;
                case Key.Down:
                    game.ChangeDir(Direction.Down);
                    break;
            }
        }

        private async Task RunGame()
        {
            Draw();



            Sounds.Fone.Stop();
            main.Play();
            await ShouCountDown();
            Overlay.Visibility= Visibility.Hidden;
            await GameLoop();
            await ShowGameOver();
            game = new Game(rows, cols);
        }
        private async Task GameLoop()
        {
            
            while (!game.IsGameOver)
            {
                await Task.Delay(game.speed);
                game.Move();
                Draw();
            }
        }
        private Image[,] SetupGrid()
        {
            Image[,] images = new Image[rows, cols];
            GameGrid.Rows = rows;

            GameGrid.Columns = cols;
            GameGrid.Width = GameGrid.Height * (cols / (double)rows);
            

            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < cols; j++)
                {
                    Image image = new Image
                    {
                        Source = Images.Empty,
                        RenderTransformOrigin = new Point(0.5, 0.5)
                    };
                    images[i, j] = image;
                    GameGrid.Children.Add(image);
                }
            }
            return images;
        }

        private void Draw()
        {
            DrawGrid();
            DrawSnakeHead();
            if (game.Score > maxScore)
            {
                maxScore= game.Score;
            }
            ScoreText.Text = $"СЧЕТ {game.Score} | ЖИЗНЕЙ {game.scoreOfBadFood} | РЕКОРД {maxScore}";

            
        }

        

        private void DrawGrid()
        {
            for(int i = 0;i <rows;i++)
            {
                for(int j = 0;j < cols; j++)
                {
                    gridValue gridval = game.Grid[i,j];
                    gridImages[i, j].Source = gridValToImage[gridval];
                    gridImages[i, j].RenderTransform = Transform.Identity;
                }
            }
        }

        private void DrawSnakeHead()
        {
            Pos headPos = game.HeadPos();
            Image image = gridImages[headPos.Row, headPos.Col];
            image.Source = Images.Head;

            int rotation = dirToRotation[game.Dir];
            image.RenderTransform = new RotateTransform(rotation);
        }   

        private async Task DrawDeadSnake()
        {
            Sounds.GameOver.Play();
            List<Pos> positions = new List<Pos>(game.SnakePos());
            for(int i = 0; i < positions.Count; i++)
            {
                Pos pos = positions[i];
                ImageSource source = (i==0)? Images.DeadHead: Images.DeadBody;
                gridImages[pos.Row, pos.Col].Source= source;
                await Task.Delay(50);
            }
        }
        private async Task ShouCountDown()
        {
           
            for (int i = 3; i>=1; i--)
            {
                OverlayText.Text = i.ToString();
                await Task.Delay(500);
            }
        }

        private async Task ShowGameOver()
        {



            main.Stop();

            await DrawDeadSnake();
            await Task.Delay(1000);
            
            WallsOn.Text = "Стенки включены";
            
            Greeting.Text = "Игра окончена, попробуйте еще раз!";
            Overlay.Visibility= Visibility.Visible;
            Menu.Visibility = Visibility.Visible;
            Sounds.Fone.PlayLooping();
            if (soundOn)
            {
                soundText.Text = "Музыка вкл.";
                main.Volume = 0.5;
                Sounds.Fone.PlayLooping();


            }
            else
            {
                soundText.Text = "Музыка выкл.";
                main.Volume = 0;
                Sounds.Fone.Stop();

            }
            OverlayText.Text = "НАЖМИТЕ ЛЮБУЮ КНОПКУ";
        }
    }
}
