using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace SnakeGame
{
    class Game
    {
        private int height;
        private int width;
        private Snake snake;
        private List<Point> snake_body;
        private Point direction;
        private Apple apple;
        private Random rnd;
        public Game(int height, int width)
        {
            this.height = height;
            this.width = width;
            this.snake_body = new List<Point>() { 
                new Point {X = 0, Y = 0 },
                new Point {X = 1, Y = 0 },
                new Point {X = 2, Y = 0 },
                new Point {X = 2, Y = 1 },
                new Point {X = 3, Y = 1 },
            };
            this.direction = new Point { X = 0, Y = -1 };
            this.snake = new Snake(snake_body, direction);
            rnd = new Random();
            this.apple = new Apple(new Point(5,5));
        }

        public string[,] board_matrix(int height, int width)
        {
            string[,] gameBoard = new string[height,width];
            for (int x = 0; x < gameBoard.GetLength(0); x++)
            {
                for (int y = 0; y < gameBoard.GetLength(1); y++)
                {
                    gameBoard[x, y] = " ";
                }
            }

            //set corners of gameboard
            gameBoard[0, 0] = "+";
            gameBoard[0, width - 1] = "+";
            gameBoard[height - 1, 0] = "+";
            gameBoard[height - 1, width - 1] = "+";


            //set edges of gameboard
            for (int x = 1; x < gameBoard.GetLength(0)-1; x++)
            {
                gameBoard[x, 0] = "|";
                gameBoard[x, width-1] = "|";
            }
            for (int y = 1; y < gameBoard.GetLength(1)-1; y++)
            {
                gameBoard[0, y] = "-";
                gameBoard[height -1, y] = "-";
            }
            return gameBoard;

        }

        public void setApple(string[,] gameBoard)
        {
            gameBoard[apple.getPosition().X, apple.getPosition().Y] = "Y";
        }

        public void render()
        {
            string[,] gameBoard = board_matrix(height, width);
            updateState();
            setApple(gameBoard);
            renderSnake(gameBoard);

            ///Render the game board on screen
            
            for(int x=0; x < gameBoard.GetLength(0); x++)
            {
                for(int y=0; y < gameBoard.GetLength(1); y++)
                {
                    Console.Write(gameBoard[x, y]);
                }
                Console.Write("\n");
            }

        }

        private void updateState()
        {
            hasEaten(apple);
        }

        public void renderSnake(string[,] gameBoard)
        {
            //Add the snake body to the game board
            for (int sx = 0; sx < snake.getLength() - 1; sx++)
            {
                gameBoard[snake.getBody()[sx].X +1 , snake.getBody()[sx].Y +1] = "X";
            }

            //Make the snake head an "O"
            gameBoard[snake.getHead().X + 1, snake.getHead().Y + 1] = "0";
        }

        public Snake getSnake()
        {
            return snake;
        }

        public bool inBounds()
        {
            return true;
        }

        //each time the player moves we must see if they collided with any of the edges of the game board
        //or if they collided with themselves
        //if they collide the game terminates
        public bool check_collision()
        {
            //check for width
            if (snake.getHead().X == -1 || snake.getHead().X == height-2)
            {
                return true;
            }
            else if (snake.getHead().Y == -1 || snake.getHead().Y == width-2)
            {
                return true;
            }
            return false;
        }

        public void spawnApple()
        {
            apple.setPosition(rnd.Next(1, height - 2), rnd.Next(1, width - 2));
        }

        public bool hasEaten(Apple p)
        {
            
            if(snake.getHead().X == p.getPosition().X -1 && snake.getHead().Y == p.getPosition().Y -1)
            {
                //remove the apple, spawn a new one and increas the size of the snake
                snake.increaseSize();
                spawnApple();
                return true;

            }
            return false;
        }
    }
}
