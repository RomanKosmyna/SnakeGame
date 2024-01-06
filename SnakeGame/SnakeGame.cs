using System.Drawing;

public class SnakeGame
{
    private readonly Menu menu;
    private readonly Point startingPoint = new(13, 7);
    private readonly int startingSize = 1;
    
    private readonly Snake snake;
    private Food food = null;

    private bool gameStatus = true;

    public SnakeGame()
    {
        menu = new();
        snake = new(startingPoint, startingSize);
    }

    public void Run()
    {
        Console.CursorVisible = false;

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

            if (Console.KeyAvailable)
            {
                SetPreviousKey(ref previousKey);
            }

            SnakeMovement(previousKey);

            gameStatus = snake.IsSnakeCollisionNotDetected();
        }

        GameStatus.DrawGameStatus(false);

        Console.ReadKey();
        Console.SetCursorPosition(6, 22);
    }

    protected void LoadGameObjects()
    {
        Playfield.RenderField();

        snake.DrawSnake();

        menu.LaunchMenu();
    }

    protected void SnakeMovement(ConsoleKey previousKey)
    {
        switch (previousKey)
        {
            case ConsoleKey.W:
            case ConsoleKey.UpArrow:
                {
                    snake.Move(Snake.Direction.Up);
                    break;
                }
            case ConsoleKey.S:
            case ConsoleKey.DownArrow:
                {
                    snake.Move(Snake.Direction.Down);
                    break;
                }
            case ConsoleKey.A:
            case ConsoleKey.LeftArrow:
                {
                    snake.Move(Snake.Direction.Left);
                    break;
                }
            case ConsoleKey.D:
            case ConsoleKey.RightArrow:
                {
                    snake.Move(Snake.Direction.Right);
                    break;
                }
        }
    }

    protected static void SetPreviousKey(ref ConsoleKey previousKey)
    {
        var key = Console.ReadKey(true).Key;

        if ((key == ConsoleKey.W || key == ConsoleKey.UpArrow) && previousKey != ConsoleKey.S)
        {
            previousKey = ConsoleKey.W;
        }
        else if ((key == ConsoleKey.S || key == ConsoleKey.DownArrow) && previousKey != ConsoleKey.W)
        {
            previousKey = ConsoleKey.S;
        }
        else if ((key == ConsoleKey.A || key == ConsoleKey.LeftArrow) && previousKey != ConsoleKey.D)
        {
            previousKey = ConsoleKey.A;
        }
        else if ((key == ConsoleKey.D || key == ConsoleKey.RightArrow) && previousKey != ConsoleKey.A)
        {
            previousKey = ConsoleKey.D;
        }
    }
}