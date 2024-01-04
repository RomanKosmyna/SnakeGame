using System.Drawing;

public class SnakeGame
{
    public void Run()
    {
        Console.CursorVisible = false;

        Point startingPoint = new Point(5, 10);
        int startingSize = 20;
        Snake snake = new(startingPoint, startingSize);

        Playfield playfield = new();
        Playfield.RenderField();

        PositionSeeker positionSeeker = new(Playfield.PlayField);

        snake.DrawSnake();

        bool isSnakeAlive = true;

        while (isSnakeAlive)
        {
            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    {
                        snake.Move(Snake.Direction.Up);
                        isSnakeAlive = snake.IsSnakeCollisionDetected();
                        break;
                    }
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    {
                        snake.Move(Snake.Direction.Down);
                        isSnakeAlive = snake.IsSnakeCollisionDetected();
                        break;
                    }
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    {
                        snake.Move(Snake.Direction.Left);
                        isSnakeAlive = snake.IsSnakeCollisionDetected();
                        break;
                    }
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    {
                        snake.Move(Snake.Direction.Right);
                        isSnakeAlive = snake.IsSnakeCollisionDetected();
                        break;
                    }
            }
        }
        Console.WriteLine("Game over!");
        //Playfield.InitializeField();
        //Playfield.RenderField();

        //snake.Instantiate();
        //snake.UpdateSnakeDisplay();

        //while (true)
        //{
        //    if (Console.KeyAvailable)
        //    {
        //        var key = Console.ReadKey(true).Key;

        //        switch (key)
        //        {
        //            case ConsoleKey.A:
        //                {
        //                    snake.MoveLeft();
        //                    //snake.SnakeCount();
        //                    break;
        //                }
        //            case ConsoleKey.D:
        //                {
        //                    snake.MoveRight();
        //                    //snake.SnakeCount();
        //                    break;
        //                }
        //            case ConsoleKey.W:
        //                {
        //                    snake.MoveTop();
        //                    //snake.SnakeCount();
        //                    break;
        //                }
        //            case ConsoleKey.S:
        //                {
        //                    snake.MoveBottom();
        //                    //snake.SnakeCount();
        //                    break;
        //                }
        //        }

        //switch (key)
        //{
        //    case ConsoleKey.A:
        //        {
        //            ConsoleKey newKey = key;
        //            do
        //            {
        //                snake.MoveLeft();
        //                if (Console.KeyAvailable)
        //                {
        //                    newKey = Console.ReadKey(true).Key;
        //                }
        //            }
        //            while (newKey != ConsoleKey.W && newKey != ConsoleKey.D && newKey != ConsoleKey.S);
        //            Thread.Sleep(200);
        //            break;
        //        }
        //    case ConsoleKey.D:
        //        {
        //            ConsoleKey newKey = key;
        //            do
        //            {
        //                snake.MoveRight();
        //                if (Console.KeyAvailable)
        //                {
        //                    newKey = Console.ReadKey(true).Key;
        //                }
        //            }
        //            while (newKey != ConsoleKey.A && newKey != ConsoleKey.W && newKey != ConsoleKey.S);
        //            Thread.Sleep(200);
        //            break;
        //        }
        //    case ConsoleKey.W:
        //        {
        //            ConsoleKey newKey = key;
        //            do
        //            {
        //                snake.MoveTop();
        //                if (Console.KeyAvailable)
        //                {
        //                    newKey = Console.ReadKey(true).Key;
        //                }
        //            }
        //            while (newKey != ConsoleKey.A && newKey != ConsoleKey.D && newKey != ConsoleKey.S);
        //            Thread.Sleep(200);
        //            break;
        //        }
        //    case ConsoleKey.S:
        //        {
        //            ConsoleKey newKey = key;
        //            do
        //            {
        //                snake.MoveBottom();
        //                if (Console.KeyAvailable)
        //                {
        //                    newKey = Console.ReadKey(true).Key;
        //                }
        //            }
        //            while (newKey != ConsoleKey.A && newKey != ConsoleKey.W && newKey != ConsoleKey.D);
        //            Thread.Sleep(200);
        //            break;
        //        }
        //}
    }
        }