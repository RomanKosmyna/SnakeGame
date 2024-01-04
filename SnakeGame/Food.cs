using System.Drawing;

public class Food
{
    private bool isActive = true;
    private static readonly string visual = " ";
    private Point position;

    public bool IsActive { get => isActive; set => isActive = value; }
    public Point Position { get => position; }

    public Food()
    {
        position = new Point(13, 14);
    }

    public Food FoodFactory()
    {
        return new Food();
    }

    public void SpawnFood()
    {
        Point[,] playfield = Playfield.PlayField;

        int randomPositionX = new Random().Next(6, 24);
        int randomPositionY = new Random().Next(3, 24);

        for (int i = 0; i < playfield.GetLength(0); i++)
        {
            for (int j = 0; j < playfield.GetLength(1); j++)
            {
                position = new Point(randomPositionX, randomPositionY);
            }
        }

        Console.SetCursorPosition(position.X, position.Y);
        Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine(visual);
        Console.ResetColor();
    }
}