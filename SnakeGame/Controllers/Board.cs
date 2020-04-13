using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SnakeGame
{
    class Board : IBoard
    {
        public int Width { get; set; }

        public int Height { get; set; }

        private string[,] gameBoard;

        public void Initialize()
        {
            if(Width == 0 || Height == 0)
            {
                throw new Exception($"Board Height or Width not initialized, Height {Height}, Width {Width}");
            }
            gameBoard = new string[Height, Width];

            //set corners of gameboard
            gameBoard[0, 0] = "+";
            gameBoard[0, Width - 1] = "+";
            gameBoard[Height - 1, 0] = "+";
            gameBoard[Height - 1, Width - 1] = "+";


            //set edges of gameboard
            for (int y = 1; y < gameBoard.GetLength(0) - 1; y++)
            {
                gameBoard[y, 0] = "|";
                gameBoard[y, Width - 1] = "|";
            }
            for (int x = 1; x < gameBoard.GetLength(1) - 1; x++)
            {
                gameBoard[0, x] = "-";
                gameBoard[Height - 1, x] = "-";
            }
        }

        public void RenderBoard()
        {
            ///Render the game board on screen

            for (int y = 0; y < gameBoard.GetLength(0); y++)
            {
                for (int x = 0; x < gameBoard.GetLength(1); x++)
                {
                    Console.Write(gameBoard[y, x]);
                }
                Console.Write("\n");
            }
        }


        public void SetSnake(ISnake snake)
        {
            clearMidle();
            //Add the snake body to the game board
            foreach (Point p in snake.Body)
            {
                gameBoard[p.Y, p.X] = "X";
            }

            //Make the snake head an "O"
            gameBoard[snake.Head.Y, snake.Head.X] = "0";

            //Add the tail to the game board
            gameBoard[snake.Tail.Y, snake.Tail.X] = "Y";
        }

        public void SetApple(IApple apple)
        {
            gameBoard[apple.Position.Y, apple.Position.X] = "A";
        }

        private void clearMidle()
        {
            //fill in the middle of the gameboard
            for (int y = 1; y < Height-1; y++)
            {
                for (int x = 1; x < Width-1; x++)
                {
                    gameBoard[y, x] = " ";
                }
            }
        }
    }
}
