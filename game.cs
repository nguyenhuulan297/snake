using System;
using System.Collections.Generic;
using System.Text;

namespace gamesnake
{
    internal class Game
    {
        public int width = 50;
        public int height = 20;
        private int score;
        private Snake snake;
        private Food food;
        public Game()
        {
            Console.CursorVisible = false;
            snake = new Snake(width, height);
            food = new Food(snake.Body, width, height);
            score = 0;
            Drawmap();
            Drawsnake();
            Drawfood();
        }
        private void Drawmap()
        {
            for ( int i = 0; i <= width; i++ ) {
                Console.SetCursorPosition(i, 0);
                Console.Write("_");
                Console.SetCursorPosition(i, height);
                Console.Write("_");
            }
            for ( int i = 1; i <= height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("|");
                Console.SetCursorPosition(width , i);
                Console.Write("|");
            }
        }
        private void Drawsnake()
        {
            foreach( Point p in snake.Body)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("O");
            }
            Console.ResetColor();
        }
        private void Drawfood()
        {
            Console.SetCursorPosition(food.position.x, food.position.y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("*");
            Console.ResetColor();
        }
        private void Drawhead(Point newhead)
        {
            Console.SetCursorPosition(newhead.x, newhead.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("O");
            Console.ResetColor();
        }
        private void Xoa(Point rac)
        {
            Console.SetCursorPosition(rac.x, rac.y);
            Console.Write(" ");
        }
        public void Start()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        case ConsoleKey.UpArrow:
                            if (snake.CurrentDirection != Direction.Down) snake.CurrentDirection = Direction.Up;
                            break;
                        case ConsoleKey.DownArrow:
                            if (snake.CurrentDirection != Direction.Up) snake.CurrentDirection = Direction.Down;
                            break;
                        case ConsoleKey.RightArrow:
                            if (snake.CurrentDirection != Direction.Left) snake.CurrentDirection = Direction.Right;
                            break;
                        case ConsoleKey.LeftArrow:
                            if (snake.CurrentDirection != Direction.Right) snake.CurrentDirection = Direction.Left;
                            break;
                    }
                }
                Point oldtail = snake.Body[^1];
                snake.Move();
                Point head = snake.Body[0];
                Drawhead(head);
                if (head.x <= 0 || head.x >= width || head.y <= 0 || head.y >= height)
                {
                    Gameover();
                    return;
                }
                for ( int i = 2; i < snake.Body.Count; i++)
                {
                    if ( head.x == snake.Body[i].x && head.y == snake.Body[i].y)
                    {
                        Gameover();
                        return;
                    }
                }
                bool atefood = (snake.Body[0].x == food.position.x && snake.Body[0].y == food.position.y);
                if (!atefood) Xoa(oldtail);
                if (atefood)
                {
                    snake.Grow(oldtail);
                    score += 10;
                    Xoa(food.position);
                    food = new Food(snake.Body, width, height);
                    Drawfood();
                }
                Thread.Sleep(150);
            }
        }
        private void Gameover()
        {
            Console.Clear();
            Console.SetCursorPosition(width / 2, height / 2);
            Console.WriteLine("Gameover!");
            Console.Write($"so diem dat duoc: {score}");
        }
    }
}
