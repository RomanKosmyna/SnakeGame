using static System.Console;

public class GameStatus
{
    public static void DrawGameStatus(bool isSnakeAlive)
    {
        string status = isSnakeAlive ? "Alive" : "Game over!";

        SetCursorPosition(52, 5);
        //BackgroundColor = ConsoleColor.Yellow;

        if (isSnakeAlive)
        {
            ForegroundColor = ConsoleColor.Green;
            WriteLine($"Status: {status}");
            return;
        }
        else
        {
            while (!KeyAvailable)
            {
                ForegroundColor = ConsoleColor.Red;
                BackgroundColor = ConsoleColor.Black;
                SetCursorPosition(52, 5);
                WriteLine($"Status: {status}");
                ResetColor();
                Thread.Sleep(500);

                ClearLastLine();

                Thread.Sleep(500);
            }
        }

        ForegroundColor = ConsoleColor.Red;
        WriteLine($"Status: {status}");
        ResetColor();
    }

    private static void ClearLastLine()
    {
        SetCursorPosition(52, 5);
        BackgroundColor = ConsoleColor.Black;
        Write(new string(' ', 18));
        SetCursorPosition(52, 5);
    }
}