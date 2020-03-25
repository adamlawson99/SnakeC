using System;
using System.Drawing;

namespace SnakeGame
{
    class Program
    {

        static void Main(string[] args)
        {


        Game myGame = new Game(10, 20);
            myGame.render();
            Console.WriteLine(myGame.getSnake().ToString());
            while (!myGame.check_collision())
            {
                //read the direction key and then wait for enter
                ConsoleKeyInfo direc_key = Console.ReadKey(true);
                    if(direc_key.Key == ConsoleKey.W)
                    {
                        myGame.getSnake().take_step(Directions.Up);
                        myGame.render();
                    }
                    else if (direc_key.Key == ConsoleKey.A)
                    {
                        myGame.getSnake().take_step(Directions.Left);
                        myGame.render();
                    }
                    else if (direc_key.Key == ConsoleKey.S)
                    {
                        myGame.getSnake().take_step(Directions.Down);
                        myGame.render();
                    }
                    else if (direc_key.Key == ConsoleKey.D)
                    {
                        myGame.getSnake().take_step(Directions.Right);
                        myGame.render();
                    }
                Console.WriteLine(myGame.getSnake().ToString());
            }
        }
    }
}
