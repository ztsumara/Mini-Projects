namespace cnsGenMapMaze1
{
    class MazeGenerator
    {
        private char[,] maze;
        private int height;
        private int width;
        private int startX;
        private int startY;
        private int endX;
        private int endY;

        public MazeGenerator(int height, int width, (int, int)? start = null, (int, int)? end = null)
        {
            this.height = height;
            this.width = width;
            startX = start?.Item1 ?? 0;
            startY = start?.Item2 ?? new Random().Next(height);
            endX = end?.Item1 ?? width - 1;
            endY = end?.Item2 ?? new Random().Next(height);
            maze = new char[height, width];
        }

        public void GenerateMaze()
        {
            // Generate the maze logic here
            // Fill the maze array with corridor, wall, start, and exit characters
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i == startX && j == startY)
                    {
                        maze[i, j] = 'S'; // Start character
                    }
                    else if (i == endX && j == endY)
                    {
                        maze[i, j] = 'E'; // Exit character
                    }
                    else
                    {
                        maze[i, j] = '.'; // Corridor character
                    }
                }
            }
        }

        public void PrintMaze()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(maze[i, j]);
                }
                Console.WriteLine();
            }
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            int height = 10;
            int width = 10;
            var start = (1, 0);
            var end = (8, 9);

            MazeGenerator mazeGenerator = new MazeGenerator(height, width, start, end);
            mazeGenerator.GenerateMaze();
            mazeGenerator.PrintMaze();
        }
    }
}