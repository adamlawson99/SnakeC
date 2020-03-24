using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace SnakeGame
{
    class Snake
    {
        private List<Point> snake;
        private Directions direction;
        //UP(0,-1) DOWN(0,1) RIGHT(1,0) LEFT(-1,0)

        public Snake(int length, Directions initial_direction, int board_height, int board_length)
        {
            //code to genrate a snake body
            this.snake = new List<Point>();
            //{
            //    new Point {X = 0, Y = 0 },
            //    new Point {X = 1, Y = 0 },
            //    new Point {X = 2, Y = 0 },
            //    new Point {X = 2, Y = 1 },
            //    new Point {X = 3, Y = 1 },
            //};
            this.direction = initial_direction;
            if (direction == Directions.Up || direction == Directions.Down)
            {
                for(int i = 2; i <= length -2; i++)
                {
                    snake.Add(new Point { Y = i, X = 2 });
                }
                //add the head in the appropriate direction
                if (direction == Directions.Up)
                {
                    snake.Add(new Point { Y = 1, X = 2 });
                }
                else
                {
                    snake.Add(new Point { Y = board_height - 1, X = 2 });
                }
            }
            else if(direction == Directions.Left || direction == Directions.Right)
            {

            }
        }

        public void take_step(Point position)
        {
            for(int i = 0; i < snake.Count -1; i++)
            {
                snake[i] = snake[i+1];
            }
            snake[snake.Count - 1] = (new Point { Y = snake[snake.Count - 1].Y + position.Y, X = snake[snake.Count - 1].X + position.X });
        }

        public void set_direction(Directions direction)
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
