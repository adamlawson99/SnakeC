using System;
using System.Drawing;

namespace SnakeGame
{
    class Program
    {

        static void Main(string[] args)
        {


        Game myGame = new Game();
            myGame.Height = 10;
            myGame.Width = 20;
            myGame.Intialize();
            //myGame.Run();
            Console.WriteLine(myGame.getSnake().ToString());
            while (myGame.Continue)
            {
                //read the direction key and then wait for enter
                ConsoleKeyInfo direc_key = Console.ReadKey(true);
                    if(direc_key.Key == ConsoleKey.W)
                    {
                    myGame.Move(Directions.Up);
                    }
                    else if (direc_key.Key == ConsoleKey.A)
                    {
                    myGame.Move(Directions.Left);
                    }
                    else if (direc_key.Key == ConsoleKey.S)
                    {
                    myGame.Move(Directions.Down);
                    }
                    else if (direc_key.Key == ConsoleKey.D)
                    {
                    myGame.Move(Directions.Right);
                    }
                Console.WriteLine(myGame.getSnake().ToString());
            }
        }
    }
}
