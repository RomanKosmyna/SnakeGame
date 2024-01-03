using System.Drawing;

public class SnakePart
{
    public string Part { get; set; }
    public Point Position { get; set; }

    public SnakePart(string part, Point position)
    {
        Part = part;
        Position = position;
    }

    public void DrawPart()
    {
        Console.SetCursorPosition(Position.X, Position.Y);
        Console.BackgroundColor = ConsoleColor.Green;
        Console.Write(Part);
    }

    public void ErasePart()
    {
        Console.SetCursorPosition(Position.X, Position.Y);
        Console.ResetColor();
        Console.Write(Part);
    }
}