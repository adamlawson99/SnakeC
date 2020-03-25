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
            this.direction = initial_direction;
            if (direction == Directions.Up || direction == Directions.Down)
            {
                for(int i = length-1; i > 1 ; i--)
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

        public void take_step(Directions direction)
        {
            bool canMove = isStepValid(direction);
            if (!canMove)
            {
                return;
            }
            else
            {
                this.direction = direction;
                Point newBodySegment = new Point();
                switch (direction)
                {
                    case (Directions.Up):
                        newBodySegment = new Point { X = 0, Y = -1 };
                        break;
                    case (Directions.Down):
                        newBodySegment = new Point { X = 0, Y = 1 };
                        break;
                    case (Directions.Left):
                        newBodySegment = new Point { X = -1, Y = 0 };
                        break;
                    case (Directions.Right):
                        newBodySegment = new Point { X = 1, Y = 0 };
                        break;
                }



                
                for (int i = 0; i < snake.Count - 1; i++)
                {
                    snake[i] = snake[i + 1];
                }
                snake[snake.Count - 1] = (new Point { Y = snake[snake.Count - 1].Y + newBodySegment.Y, X = snake[snake.Count - 1].X + newBodySegment.X });

            }
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

        public bool isStepValid(Directions direction)
        {
            switch (direction)
            {
                case Directions.Down:
                    if(this.direction == Directions.Up)
                    {
                        return false;
                    }
                    return true;
                case Directions.Up:
                    if(this.direction == Directions.Down)
                    {
                        return false;
                    }
                    return true;
                case Directions.Left:
                    if(this.direction == Directions.Right)
                    {
                        return false;
                    }
                    return true;
                case Directions.Right:
                    if(this.direction == Directions.Left)
                    {
                        return false;
                    }
                    return true;
                default:
                    return false;
            }
            //if(this.direction == Directions.Down || this.direction == Directions.Up)
            //{
            //    if(this.direction == Directions.Up && direction == Directions.Down)
            //    {
            //        return false;
            //    }
            //    if (this.direction == Directions.Down && direction == Directions.Up)
            //    {
            //        return false;
            //    }

            //    return true;
            //}
            //else if(this.direction == Directions.Right || this.direction == Directions.Left)
            //{
                
            //    return
            //}
            //else
            //{
            //    return false;
            //}
        }
    }
}
