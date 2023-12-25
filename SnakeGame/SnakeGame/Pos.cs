

using System;
using System.Collections.Generic;

namespace SnakeGame
{
    public class Pos
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public Pos(int row, int col)
        {
            Row = row; 
            Col = col;
        }
        public Pos Translate(Direction dir)
        {
            return new Pos(Row+dir.RowOffset, Col+dir.ColumnOffset);
        }

        public override bool Equals(object obj)
        {
            return obj is Pos pos &&
                   Row == pos.Row &&
                   Col == pos.Col;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Row, Col);
        }

        public static bool operator ==(Pos left, Pos right)
        {
            return EqualityComparer<Pos>.Default.Equals(left, right);
        }

        public static bool operator !=(Pos left, Pos right)
        {
            return !(left == right);
        }
    }
}
