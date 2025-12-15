using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace gamesnake
{
    public class Snake
    {
        public List<Point> Body { get; private set; }
        public Direction CurrentDirection { get; set; }
        public Snake(int width, int height)
        {
            Body = new List<Point>();
            CurrentDirection = Direction.Right;
            Body.Add(new Point { x = (width / 2) - 1, y = height / 2});
            Body.Add(new Point { x = width / 2, y = height / 2});
        }
        public void Move()
        {
            Point head = Body[0];
            Point nexthead = new Point { x = head.x, y = head.y };

            switch (CurrentDirection)
            {
                case Direction.Up: nexthead.y--; break;
                case Direction.Down: nexthead.y++; break;
                case Direction.Right: nexthead.x++; break;
                case Direction.Left: nexthead.x--; break;
            }
            Body.Insert(0, nexthead);
            Body.RemoveAt(Body.Count - 1);
        }
        public void Grow(Point oldtail)
        {
            Body.Add(oldtail);
        }
    }
}
