using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace SnakeGame
{
    class Game : IGame
    {
        private ISnake snake;
        private IApple apple;
        private IBoard board;
        private Random rnd;
        public bool Continue { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public Game()
        {
        }

        public void Intialize()
        {
            Continue = true;

            if (Height == 0 || Width == 0)
            {
                throw new Exception($"Height and Width must be initialized Height:{Height} Width:{Width}");
            }

            board = new Board() {Height = Height, Width = Width };

            board.Initialize();

            snake = new Snake() {Direction = Directions.Up };
            snake.InitializeSnake();

            apple = new Apple();
            apple.Position = new Point(5, 5);

            rnd = new Random();
            updateState();
        }

        private void updateState()
        {
            //check for collisions between the snake and the board
            if (check_collision())
            {
                Continue = false;
                return;
            }
            //check if the snake ate the apple
            hasEaten(apple);

            board.SetSnake(snake);
            board.SetApple(apple);
            board.RenderBoard();
        }

        public ISnake getSnake()
        {
            return snake;
        }

        //each time the player moves we must see if they collided with any of the edges of the game board
        //or if they collided with themselves
        //if they collide the game terminates
        public bool check_collision()
        {
            List<Point> snakeBody = snake.Body;
            Point snakeHead = snake.Head;
            //check for collisions with game board
            if (snakeHead.Y == -1 || snakeHead.Y == Height - 2)
            {
                return true;
            }
            else if (snakeHead.X == -1 || snakeHead.X == Width - 2)
            {
                return true;
            }
            //check for collisions with body
            for (int i = 0; i < snakeBody.Count - 1; i++)
            {
                if (snakeHead.X == snakeBody[i].X && snakeHead.Y == snakeBody[i].Y)
                {
                    return true;
                }
            }
            return false;
        }

        public void spawnApple()
        {
            if (Height != 0 && Width != 0)
            {
                apple.Position = new Point(rnd.Next(1, Width - 2), rnd.Next(1, Height - 2));
            }

        }

        public bool hasEaten(IApple p)
        {

            if (snake.Head.X == p.Position.X - 1 && snake.Head.Y == p.Position.Y - 1)
            {
                //remove the apple, spawn a new one and increas the size of the snake
                snake.increaseSize();
                spawnApple();
                return true;
            }
            return false;
        }

        public bool canMove(Directions direction)
        {
            switch (direction)
            {
                case (Directions.Up):
                    return !(snake.Direction == Directions.Down);

                case (Directions.Down):
                    return !(snake.Direction == Directions.Up);

                case (Directions.Left):
                    return !(snake.Direction == Directions.Right);

                case (Directions.Right):
                    return !(snake.Direction == Directions.Left);
                default:
                    return false;
            }
        }

        public void Move(Directions direction)
        {
            bool allowed = canMove(direction);
            if (!allowed) { return; }

            //if we are moving in a new direction update the snake's direction
            if (direction != snake.Direction)
            {
                snake.Direction = direction;
            }

            //move the snake in the new direction
            snake.Move();

            //update the game state
            updateState();
            return;
        }

    }
}
