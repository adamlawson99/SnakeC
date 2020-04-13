namespace SnakeGame
{
    interface IBoard
    {
        int Height { get; set; }
        int Width { get; set; }

        void Initialize();
        void RenderBoard();

        void SetSnake(ISnake snake);
        void SetApple(IApple apple);
    }
}