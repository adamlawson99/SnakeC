using System;
using System.Drawing;

namespace SnakeGame
{
    class Program
    {

        static void Main(string[] args)
        {
          Point LEFT = new Point { X = 0, Y = -1 };
          Point RIGHT = new Point { X = 0, Y = 1 };
          Point DOWN = new Point { X = 1, Y = 0 };
          Point UP = new Point { X = -1, Y = 0 };

        Game myGame = new Game(10, 20);
            myGame.render();
            Console.WriteLine(myGame.getSnake().ToString());
            while (true)
            {
                //read the direction key and then wait for enter
                ConsoleKeyInfo direc_key = Console.ReadKey();
                ConsoleKeyInfo key = Console.ReadKey();
                if(key.Key == ConsoleKey.Enter)
                {
                    if(direc_key.Key == ConsoleKey.W)
                    {
                        myGame.getSnake().take_step(UP);
                        myGame.render();
                    }
                    else if (direc_key.Key == ConsoleKey.A)
                    {
                        myGame.getSnake().take_step(LEFT);
                        myGame.render();
                    }
                    else if (direc_key.Key == ConsoleKey.S)
                    {
                        myGame.getSnake().take_step(DOWN);
                        myGame.render();
                    }
                    else if (direc_key.Key == ConsoleKey.D)
                    {
                        myGame.getSnake().take_step(RIGHT);
                        myGame.render();
                    }
                }
                Console.WriteLine(myGame.getSnake().ToString());
            }
        }
    }
}
