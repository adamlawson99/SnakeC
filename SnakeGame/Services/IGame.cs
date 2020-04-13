namespace SnakeGame
{
    interface IGame
    {
        int Height { get; set; }
        int Width { get; set; }

        bool check_collision();
        bool hasEaten(IApple p);
        void Intialize();
        void Move(Directions direction);
        void spawnApple();
        bool canMove(Directions direction);
    }
}