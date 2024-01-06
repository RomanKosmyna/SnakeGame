public class Menu
{
    private string[,] _menu = new string[15, 30];

    public Menu()
    {
        InstantiateMenu();
    }

    public void InstantiateMenu()
    {
        for (int i = 0; i < _menu.GetLength(0); i++)
        {
            for (int j = 0;  j < _menu.GetLength(1); j++)
            {
                _menu[i, j] = " ";
            }
        }
    }

    public void DrawMenu()
    {
        for (int i = 0; i < _menu.GetLength(0); i++)
        {
            for (int j = 0;  j < _menu.GetLength(1); j++)
            {
                Console.SetCursorPosition(j + 56, i + 3);
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.Write(" ");
            }

            Console.WriteLine();
        }
    }
}