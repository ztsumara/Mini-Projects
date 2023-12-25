using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Game
    {
        public int Rows { get; }
        public int Columns { get; }
        public gridValue[,] Grid { get; }
        public Direction Dir { get; private set; }
        public int Score { get; private set; }
        public bool IsGameOver { get;private set; }
        public int speed = 200;
        public int scoreOfBadFood = 5;
        public int speedDelta;
        public bool wallsIsOn = true;
        private LinkedList<Pos> snakePosition = new LinkedList<Pos>();
        
        private readonly Random rand = new Random();
        private readonly LinkedList<Direction> dirChanges = new LinkedList<Direction>();
        public Game(int rows, int cols)
        {
            Rows = rows;
            Columns = cols;
            Grid = new gridValue[rows, cols];
            Dir = Direction.Right;

            AddSnake();
            AddFood();
            AddBadFood();
        }

        private void AddSnake()
        {
            int r = Rows / 2;

            for(int i = 0; i <= 3; i++)
            {
                Grid[r, i] = gridValue.Snake;
                snakePosition.AddFirst(new Pos(r, i));
            }
        }
        private IEnumerable<Pos> EmptyPositions()
        {
            for(int i = 0;i< Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (Grid[i,j] == gridValue.Empty)
                    {
                        yield return new Pos(i, j);
                    }
                }
            }
        }

        private void AddFood()
        {
            List<Pos> empty = new List<Pos>(EmptyPositions());

            if(empty.Count == 0)
            {
                return;
            }
            Pos position = empty[rand.Next(empty.Count)];
            if (Grid[position.Row, position.Col] == gridValue.BadFood)
            {
                AddBadFood();
            }
            Grid[position.Row,position.Col]= gridValue.Food;
        }
        private void AddBadFood()
        {
            List<Pos> empty = new List<Pos>(EmptyPositions());

            if (empty.Count == 0)
            {
                return;
            }
            Pos position = empty[rand.Next(empty.Count)];
            if(Grid[position.Row, position.Col] == gridValue.Food)
            {
                AddFood();
            }
            Grid[position.Row, position.Col] = gridValue.BadFood;
        }

        public Pos HeadPos()
        {
            return snakePosition.First.Value;
        }
        public Pos TailPos()
        {
            return snakePosition.Last.Value;
        }

        public IEnumerable<Pos> SnakePos()
        {
            return snakePosition;

        }

        private void AddHead(Pos position) 
        {
            snakePosition.AddFirst(position);
            Grid[position.Row, position.Col] = gridValue.Snake;
        }
        private void RemoveTail() 
        {
            Pos tail = snakePosition.Last.Value;
            Grid[tail.Row, tail.Col] = gridValue.Empty;
            snakePosition.RemoveLast();
        }
        private Direction GetLastDirection()
        {
            if(dirChanges.Count == 0)
            {
                return Dir;
            }
            return dirChanges.Last.Value;
        }

        private bool CanChangeDirection(Direction newDir)
        {
            if (dirChanges.Count == 2)
            {
                return false;
            }
            Direction lastdir = GetLastDirection();
            return newDir != lastdir && newDir != lastdir.Opposite();
        }
        public void ChangeDir(Direction dir)
        {
            if (CanChangeDirection(dir))
            {
                dirChanges.AddLast(dir);
            }
            
        }

        private bool OutsideGrid(Pos position)
        {
            return position.Row < 0 || position.Row >= Rows || position.Col < 0 || position.Col >= Columns;
        }
        private gridValue WillHit(Pos newHeadPos)
        {
            if (OutsideGrid(newHeadPos))
            {
                return gridValue.Outside;
            }

            if(newHeadPos == TailPos())
            {
                return gridValue.Empty;
            }
            return Grid[newHeadPos.Row, newHeadPos.Col];
        }

        public void Move()
        {
            
            if (dirChanges.Count > 0)
            {
                Dir = dirChanges.First.Value;
                dirChanges.RemoveFirst();
            }

            Pos newHeadPos = HeadPos().Translate(Dir);
            gridValue hit = WillHit(newHeadPos);
            if(hit == gridValue.Snake )
            {
                IsGameOver = true;
            }
            else if(hit == gridValue.Outside)
            {
                if (!wallsIsOn)
                {
                    if (newHeadPos.Row >= Rows)
                    {
                        newHeadPos.Row = 0;
                    }
                    else if (newHeadPos.Row < 0)
                    {
                        newHeadPos.Row = Rows - 1;
                    }
                    else if (newHeadPos.Col < 0)
                    {
                        newHeadPos.Col = Columns - 1;
                    }
                    else if (newHeadPos.Col >= Columns)
                    {
                        newHeadPos.Col = 0;
                    }
                    RemoveTail();
                    AddHead(newHeadPos);
                }
                else
                {
                    IsGameOver = true;
                }
            }
            else if(hit == gridValue.BadFood) 
            {
                
                if(scoreOfBadFood >3) 
                { 
                    IsGameOver=true;
                }
                if (Score - 3 >= 0)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        RemoveTail();
                    }
                    AddHead(newHeadPos);
                    Score -= 3;
                }
                else 
                {
                    for (int i = 0; i < Score+1; i++)
                    {
                        RemoveTail();
                    }
                    Score = 0;
                    
                    AddHead(newHeadPos);
                }
                AddBadFood();
                scoreOfBadFood--;
                if (scoreOfBadFood == 0)
                {
                    IsGameOver = true;
                    scoreOfBadFood = 0;
                }

            }
            else if (hit == gridValue.Empty)
            {
                RemoveTail();
                AddHead(newHeadPos);
            }
            else if (hit == gridValue.Food)
            {
                AddHead(newHeadPos);
                Score++;
                speed-=speedDelta;
                if (speed < 30)
                {
                    speed += speedDelta;
                }
                AddFood();
                if(Score%5==0)
                {
                    AddBadFood();
                }
                
            }
            
        }
    }
}
