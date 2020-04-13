using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace SnakeGame
{
    class Apple : IApple
    {

        private Point _position;

        public Point Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
            }
        }
    }
}
