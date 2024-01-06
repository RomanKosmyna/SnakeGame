using static System.Console;

public class SnakeMovement
{
    private readonly Snake _snake;

    public SnakeMovement(Snake snake)
    {
        _snake = snake;
    }

    public void SnakeControl(ConsoleKey previousKey)
    {
        switch (previousKey)
        {
            case ConsoleKey.W:
            case ConsoleKey.UpArrow:
                {
                    _snake.Move(Snake.Direction.Up);
                    break;
                }
            case ConsoleKey.S:
            case ConsoleKey.DownArrow:
                {
                    _snake.Move(Snake.Direction.Down);
                    break;
                }
            case ConsoleKey.A:
            case ConsoleKey.LeftArrow:
                {
                    _snake.Move(Snake.Direction.Left);
                    break;
                }
            case ConsoleKey.D:
            case ConsoleKey.RightArrow:
                {
                    _snake.Move(Snake.Direction.Right);
                    break;
                }
        }
    }

    public void SetPreviousKey(ref ConsoleKey previousKey)
    {
        var key = ReadKey(true).Key;

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