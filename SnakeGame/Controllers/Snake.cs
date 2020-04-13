using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace SnakeGame
{
    class Snake : ISnake
    {
        //private List<Point> body;

        private List<Point> _body;

        public List<Point> Body
        {
            get { return _body; }
            set {}
        }

        public Point Head { get; set; }
        public Point Tail { get; set; }

        private Directions _direction;

        public Directions Direction
        {
            get { return _direction; }
            set
            {
                _direction = value;
            }
        }

        public void InitializeSnake(int length = 3)
        {
            _body = new List<Point>();
            if (Direction == Directions.Undefined)
            {
                throw new Exception("Direction not set exception");
            }

            for (int i = length - 2; i > 0; i--)
            {
                _body.Add(new Point { Y = i + 1, X = 2 });
            }

            Tail = (new Point { Y = _body[0].Y + 1, X = 2 });

            if (Direction == Directions.Up)
            {
                Head = (new Point { Y = 1, X = 2 });
            }
            
            else
            {
                Head = (new Point { Y = length - 1, X = 2 });
            }

        }

        public int getLength()
        {
            // add the body length + 2 for the head and the tail
            return Body.Count + 2;
        }

        public override string ToString()
        {
            string output = "[";
            output += Head.ToString();
            foreach (Point p in _body)
            {
                output = output + p.ToString();
            }
            output += Tail.ToString();
            output += "]";
            return output;
        }

        public void increaseSize()
        {
            _body.Insert(0, new Point(Tail.X, Tail.Y));
            Tail = new Point(Tail.X - 1, Tail.Y - 1);
        }

        public void Move()
        {
            int X=0, Y=0;

            //move the snake based on the current direction
            switch (Direction)
            {
                case (Directions.Up):
                    Y = -1;
                    break;
                case (Directions.Down):
                    Y = 1;
                    break;
                case (Directions.Left):
                    X = -1;
                    break;
                case (Directions.Right):
                    X = 1;
                    break;
                default:
                    throw new Exception("Invalid Move!");
            }
            Point bodyPart = _body[_body.Count - 1];

            //move the tail
            Tail = new Point(bodyPart.X,bodyPart.Y);
            for(int i = _body.Count -1; i>= 0; i--)
            {
                if(i == 0)
                {
                    _body[i] = new Point(Head.X, Head.Y);
                    continue;
                }
                bodyPart = _body[i-1];
                _body[i] = new Point(bodyPart.X, bodyPart.Y);
            }
            //move the head
            Head = new Point(Head.X + X, Head.Y + Y);
            //move the body by iterating through it
        }

    }
}
