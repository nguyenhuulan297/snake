using System;
using System.Collections.Generic;
using System.Text;

namespace gamesnake
{
    internal class Food
    {
        public Point position { get; private set; }
        private Random rand;
        public Food(List<Point> snakebody, int width, int height)
        {
            position = new Point();
            rand = new Random();
            do
            {
                position.x = rand.Next(2, width - 1);
                position.y = rand.Next(2, height - 1);
            } while (snakebody.Contains(position));
        }
    }
}
