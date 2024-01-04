using System.Drawing;

public class PositionSeeker
{
    private static Point[,] _playfield;

    public PositionSeeker(Point[,] playfield)
    {
        _playfield = playfield;
    }

    public static bool AreCoordinatesValid(Point snakePartCoordinates)
    {
        int playfieldRows = _playfield.GetLength(0);
        int playfieldCols = _playfield.GetLength(1);

        //Console.WriteLine($"Snake coords: {snakePartCoordinates.X} {snakePartCoordinates.Y}");
        //Console.WriteLine($"Playfield coords: {playfieldRows} {playfieldCols}");

        for (int i = 0; i < playfieldRows; i++)
        {
            for (int j = 0; j < playfieldCols; j++)
            {
                if (_playfield[i, j] == snakePartCoordinates)
                {
                    return true;
                }
            }
        }
        
        return false;
        
        //if (snakePartCoordinates.X >= 6 && snakePartCoordinates.X < playfieldRows + 6 &&
        //    snakePartCoordinates.Y >= 3 && snakePartCoordinates.Y < playfieldCols + 3)
        //{
        //    return true;
        //}
        //else
        //{
        //    return false;
        //}
    }
}