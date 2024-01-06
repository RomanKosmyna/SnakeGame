using static System.Console;

public class Menu : GameStatus
{
    private string[,] _menu = new string[10, 20];
    private readonly Scoreboard scoreboard = new();

    public Scoreboard Scoreboard { get { return scoreboard; } }

    public Menu()
    {
        scoreboard = new Scoreboard();

        InstantiateMenu();
    }

    public void LaunchMenu()
    {
        DrawMenu();
        DrawScore();
        DrawGameStatus(true);
    }

    protected void InstantiateMenu()
    {
        for (int i = 0; i < _menu.GetLength(0); i++)
        {
            for (int j = 0;  j < _menu.GetLength(1); j++)
            {
                _menu[i, j] = " ";
            }
        }
    }

    protected void DrawMenu()
    {
        for (int i = 0; i < _menu.GetLength(0); i++)
        {
            for (int j = 0;  j < _menu.GetLength(1); j++)
            {
                SetCursorPosition(j + 56, i + 3);
                BackgroundColor = ConsoleColor.Yellow;
                Write(" ");
            }

            WriteLine();
        }
    }

    public void DrawScore()
    {
        SetCursorPosition(57, 4);
        BackgroundColor = ConsoleColor.Yellow;
        ForegroundColor = ConsoleColor.Red;
        WriteLine($"Score: {Scoreboard.Score}");
        ResetColor();
    }
}