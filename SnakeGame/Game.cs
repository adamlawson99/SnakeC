using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace SnakeGame
{
    class Game
    {
        //height = Y width = X
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
            this.snake = new Snake(5, Directions.Up,height,width);
            rnd = new Random();
            this.apple = new Apple(new Point(5,5));
        }

        public string[,] board_matrix(int height, int width)
        {
            string[,] gameBoard = new string[height,width];
            //board rows
            for (int y = 0; y < gameBoard.GetLength(0); y++)
            {
                //board columns
                for (int x = 0; x < gameBoard.GetLength(1); x++)
                {
                    gameBoard[y, x] = " ";
                }
            }

            //set corners of gameboard
            gameBoard[0, 0] = "+";
            gameBoard[0, width - 1] = "+";
            gameBoard[height - 1, 0] = "+";
            gameBoard[height - 1, width - 1] = "+";


            //set edges of gameboard
            for (int y = 1; y < gameBoard.GetLength(0)-1; y++)
            {
                gameBoard[y, 0] = "|";
                gameBoard[y, width-1] = "|";
            }
            for (int x = 1; x < gameBoard.GetLength(1)-1; x++)
            {
                gameBoard[0, x] = "-";
                gameBoard[height -1, x] = "-";
            }
            return gameBoard;

        }

        public void setApple(string[,] gameBoard)
        {
            gameBoard[apple.getPosition().Y, apple.getPosition().X] = "Y";
        }

        public void render()
        {
            string[,] gameBoard = board_matrix(height, width);
            updateState();
            setApple(gameBoard);
            renderSnake(gameBoard);

            ///Render the game board on screen
            
            for(int y=0; y < gameBoard.GetLength(0); y++)
            {
                for(int x=0; x < gameBoard.GetLength(1); x++)
                {
                    Console.Write(gameBoard[y, x]);
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
                gameBoard[snake.getBody()[sx].Y +1 , snake.getBody()[sx].X +1] = "X";
            }

            //Make the snake head an "O"
            gameBoard[snake.getHead().Y + 1, snake.getHead().X + 1] = "0";
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
            List<Point> snakeBody = snake.getBody();
            Point snakeHead = snake.getHead();
            //check for collisions with game board
            if (snakeHead.Y == -1 || snakeHead.Y == height-2)
            {
                return true;
            }
            else if (snakeHead.X == -1 || snakeHead.X == width-2)
            {
                return true;
            }
            //check for collisions with body
            for(int i =0; i < snakeBody.Count -1; i++)
            {
                if(snakeHead.X == snakeBody[i].X && snakeHead.Y == snakeBody[i].Y)
                {
                    return true;
                }
            }
            return false;
        }

        public void spawnApple()
        {
            apple.setPosition(rnd.Next(1, width - 2), rnd.Next(1, height - 2));
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
