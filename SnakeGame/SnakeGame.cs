public class SnakeGame
{
    public void Run()
    {
        Console.CursorVisible = false;

        Snake snake = new(6, 5);

        Playfield.InitializeField();
        Playfield.RenderField();

        snake.Instantiate();
        snake.UpdateSnakeDisplay();

        while (true)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.A:
                        {
                            snake.MoveLeft();
                            //snake.SnakeCount();
                            break;
                        }
                    case ConsoleKey.D:
                        {
                            snake.MoveRight();
                            //snake.SnakeCount();
                            break;
                        }
                    case ConsoleKey.W:
                        {
                            snake.MoveTop();
                            //snake.SnakeCount();
                            break;
                        }
                    case ConsoleKey.S:
                        {
                            snake.MoveBottom();
                            //snake.SnakeCount();
                            break;
                        }
                }

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

    }
}