using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace SnakeGame
{
    class Snake
    {
        private Point[] snake;
        private Point direction;
        //UP(0,-1) DOWN(0,1) RIGHT(1,0) LEFT(-1,0)

        public Snake(Point[] initial_body, Point initial_direction)
        {
            this.snake = initial_body;
            this.direction = initial_direction;
        }

        public void take_step(Point position)
        {
            for(int i = 0; i < snake.Length -1; i++)
            {
                snake[i] = snake[i+1];
            }
            snake[snake.Length - 1].X += position.X;
            snake[snake.Length - 1].Y += position.Y;
        }

        public void set_direction(Point direction)
        {
            this.direction = direction;
        }

        public Point getHead()
        {
            int headPosition = snake.Length - 1;
            return snake[headPosition];
        }

        public Point[] getBody()
        {
            return snake;
        }

        public int getLength()
        {
            return snake.Length;
        }

        public override string ToString()
        {
            string output = "[";
            foreach(Point p in snake)
            {
                output = output + p.ToString();
            }
            output += "]";
            return output;
        }
    }
}
