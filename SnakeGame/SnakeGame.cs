using System.Drawing;

public class SnakeGame
{
    public void Run()
    {
        Console.CursorVisible = false;

        Point startingPoint = new Point(13, 7);
        int startingSize = 1;
        Snake snake = new(startingPoint, startingSize);

        Playfield playfield = new();
        Playfield.RenderField();

        PositionSeeker positionSeeker = new(Playfield.PlayField);

        snake.DrawSnake();

        bool gameStatus = true;

        ConsoleKey previousKey = ConsoleKey.RightArrow;

        while (gameStatus)
        {
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

        Console.WriteLine("Game over!");
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