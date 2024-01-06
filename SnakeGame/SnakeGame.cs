using static System.Console;
using System.Drawing;

public class SnakeGame
{
    private readonly Menu menu;
    private readonly Point startingPoint = new(13, 7);
    private readonly int startingSize = 1;
    
    private readonly Snake snake;
    private Food food = null;

    private bool gameStatus = true;

    private readonly SnakeMovement snakeMovement;

    public SnakeGame()
    {
        menu = new();
        snake = new(startingPoint, startingSize);
        snakeMovement = new(snake);
    }

    public void Run()
    {
        CursorVisible = false;

        LoadGameObjects();

        ConsoleKey previousKey = ConsoleKey.RightArrow;

        while (gameStatus)
        {
            if (food == null || food.IsEaten)
            {
                food = Food.SpawnFood();
            }

            food?.DrawFood();

            bool isSnakeEating = snake.IsSnakeEatingFood(food, snake);

            if (isSnakeEating)
            {
                snake.EatFood(food);
                menu.Scoreboard.IncrementScore();
                menu.DrawScore();
            }

            if (KeyAvailable)
            {
                snakeMovement.SetPreviousKey(ref previousKey);
            }

            snakeMovement.SnakeControl(previousKey);

            gameStatus = snake.IsSnakeCollisionNotDetected();
        }

        GameStatus.DrawGameStatus(false);

        ReadKey();
        SetCursorPosition(6, 22);
    }

    protected void LoadGameObjects()
    {
        Playfield.RenderField();

        snake.DrawSnake();

        menu.LaunchMenu();
    }
}