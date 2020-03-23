using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace SnakeGame
{
    class Snake
    {
        private List<Point> snake;
        private Point direction;
        //UP(0,-1) DOWN(0,1) RIGHT(1,0) LEFT(-1,0)

        public Snake(List<Point> initial_body, Point initial_direction)
        {
            this.snake = initial_body;
            this.direction = initial_direction;
        }

        public void take_step(Point position)
        {
            for(int i = 0; i < snake.Count -1; i++)
            {
                snake[i] = snake[i+1];
            }
            snake[snake.Count - 1] = new Point(snake[snake.Count - 1].X + position.X, snake[snake.Count - 1].Y + position.Y);
        }

        public void set_direction(Point direction)
        {
            this.direction = direction;
        }

        public Point getHead()
        {
            int headPosition = snake.Count - 1;
            return snake[headPosition];
        }

        public List<Point> getBody()
        {
            return snake;
        }

        public int getLength()
        {
            return snake.Count;
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

        public void increaseSize()
        {
            Point tail_of_snake = snake[0];
            snake.Insert(0, new Point(tail_of_snake.X -1, tail_of_snake.Y -1));
        }
    }
}
