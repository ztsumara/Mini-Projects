namespace cnsGenMapSapper
{
    using System;
    using System.Collections.Generic;

    
    internal class Program
    {
        static void GenerateMap(int height, int width, int mineCount, List<Tuple<int, int>> mines = null, Tuple<int, int> firstMove = null)
        {
            char[,] map = new char[height, width];

            
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    map[i, j] = '0';
                }
            }

           
            if (mines == null)
            {
                Random random = new Random();
                for (int i = 0; i < mineCount; i++)
                {
                    int randX = random.Next(0, width);
                    int randY = random.Next(0, height);
                    while (map[randY, randX] == '*')
                    {
                        randX = random.Next(0, width);
                        randY = random.Next(0, height);
                    }
                    map[randY, randX] = '*';
                }
            }
            else
            {
                foreach (var mine in mines)
                {
                    map[mine.Item2, mine.Item1] = '*';
                }
            }

            
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (map[i, j] == '*')
                    {
                        continue;
                    }
                    int count = 0;
                    for (int x = -1; x <= 1; x++)
                    {
                        for (int y = -1; y <= 1; y++)
                        {
                            if (i + y >= 0 && i + y < height && j + x >= 0 && j + x < width)
                            {
                                if (map[i + y, j + x] == '*')
                                {
                                    count++;
                                }
                            }
                        }
                    }
                    map[i, j] = count.ToString()[0];
                }
            }

            // Clear first move 
            if (firstMove != null)
            {
                map[firstMove.Item2, firstMove.Item1] = ' ';
            }
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
            
        }
        static void Main(string[] args)
        {
            List<Tuple<int, int>> mines = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(1, 0),
                new Tuple<int, int>(2, 1),
                new Tuple<int, int>(1, 2),
                new Tuple<int, int>(3, 2),
                new Tuple<int, int>(3, 3),
                new Tuple<int, int>(2, 4)
            };
            //Tuple<int, int> firstMove = new Tuple<int, int>(0, 0);

            GenerateMap(5, 5, 6, mines);

            
            

        }
    }
}