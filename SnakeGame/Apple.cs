using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace SnakeGame
{
    class Apple
    {
        Point pos;
        public Apple(Point p)
        {
            this.pos = p;
        }

        public Point getPosition()
        {
            return this.pos;
        }

        public void setPosition(int x, int y)
        {
            pos.X = x;
            pos.Y = y;
        }
    }
}
