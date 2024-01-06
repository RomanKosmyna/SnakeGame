using System.Drawing;

public class SnakeGame
{
    private Menu menu = new();
    private Point startingPoint = new Point(13, 7);
    private int startingSize = 10;

    public void Run()
    {
        Console.CursorVisible = false;

        Snake snake = new(startingPoint, startingSize);

        Playfield playfield = new();
        Playfield.RenderField();

        PositionSeeker positionSeeker = new(Playfield.PlayField);

        snake.DrawSnake();

        menu.LaunchMenu();

        bool gameStatus = true;

        ConsoleKey previousKey = ConsoleKey.RightArrow;

        Food food = null;

        while (gameStatus)
        {
            if (food == null || food.IsEaten)
            {
                food = Food.SpawnFood();
            }

            if (food != null)
            {
                food.DrawFood();
            }

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

            gameStatus = snake.IsSnakeCollisionNotDetected();
        }

        GameStatus.DrawGameStatus(false);

        Console.ReadKey();
        Console.SetCursorPosition(6, 22);
    }

    public void SetPreviousKey(ref ConsoleKey previousKey)
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