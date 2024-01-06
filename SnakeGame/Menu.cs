using static System.Console;

public class Menu : GameStatus
{
    private string[,] _menu = new string[10, 20];
    private readonly Scoreboard scoreboard = new();

    public Scoreboard Scoreboard { get { return scoreboard; } }

    public Menu()
    {
        scoreboard = new Scoreboard();
    }

    public void LaunchMenu()
    {
        DrawScore();
        DrawGameStatus(true);
    }

    public void DrawScore()
    {
        SetCursorPosition(52, 3);
        BackgroundColor = ConsoleColor.Black;
        ForegroundColor = ConsoleColor.Green;
        WriteLine($"Score: {Scoreboard.Score}");
        ResetColor();
    }
}