using System.Drawing;

public class Food
{
    private static bool isEaten = true;
    private static readonly string visualView = " ";
    private static Point position;

    public bool IsEaten { get => isEaten; set => isEaten = value; }
    public Point Position { get => position; }

    private System.Timers.Timer spawnTimer;

    private static Food instance;

    public static Food Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Food();
            }
            return instance;
        }
    }

    private static Food CreateFood()
    {
        isEaten = false;
        int randomPositionX = new Random().Next(6, 24);
        int randomPositionY = new Random().Next(3, 23);
        position = new Point(randomPositionX, randomPositionY);
        return new Food();
    }

    public static Food SpawnFood()
    {
        if (isEaten)
        {
            return CreateFood();
        }
        return null;
    }

    public void DrawFood()
    {
        Console.SetCursorPosition(position.X, position.Y);
        Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine(visualView);
        Console.ResetColor();
    }
}