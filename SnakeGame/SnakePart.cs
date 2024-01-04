using static System.Console;
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
        SetCursorPosition(Position.X, Position.Y);
        BackgroundColor = ConsoleColor.Green;
        Write(Part);
    }

    public void DrawHead()
    {
        SetCursorPosition(Position.X, Position.Y);
        BackgroundColor = ConsoleColor.Yellow;
        Write(Part);
    }

    public void ErasePart()
    {
        SetCursorPosition(Position.X, Position.Y);
        ResetColor();
        BackgroundColor = ConsoleColor.Gray;
        Write(Part);
    }
}