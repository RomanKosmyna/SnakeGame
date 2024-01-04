using System.Drawing;

public class Playfield
{
    private static Point[,] _playfield = new Point[20, 40];
    public static Point[,] PlayField => _playfield;

    public Playfield()
    {
        InitializeField();
    }

    private static void InitializeField()
    {
        for (int i = 0; i < _playfield.GetLength(0); i++)
        {
            for (int j = 0; j < _playfield.GetLength(1); j++)
            {
                _playfield[i, j] = new Point(i + 1, j + 1);
            }
        }
    }

    public static void RenderField()
    {
        for (int i = 0;  i < _playfield.GetLength(0); i++)
        {
            for (int j = 0;  j < _playfield.GetLength(1); j++)
            {
                   Console.SetCursorPosition(j + 6, i + 3);
                   Console.BackgroundColor = ConsoleColor.Gray;
                   Console.WriteLine(" ");
            }

            Console.WriteLine();
        }
    }
}