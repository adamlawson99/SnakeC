using System.Collections.Generic;
using System.Drawing;

namespace SnakeGame
{
    interface ISnake
    {
        List<Point> Body { get; set; }
        Directions Direction { get; set; }
        Point Head { get; set; }
        Point Tail { get; set; }

        int getLength();
        void increaseSize();
        void InitializeSnake(int length=3);
        string ToString();
        void Move();
    }
}