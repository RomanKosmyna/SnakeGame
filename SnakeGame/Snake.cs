using System.Drawing;

public class Snake : ISnake
{
    private List<Point> _snakeBody = [];
    //private readonly List<Point> _bodyPart = [];
    private Point _head;

    private readonly int _initialSize = 1;

    private readonly int _leftIndent;
    private readonly int _topIndent;

    public List<Point> SnakeBody { get { return _snakeBody; } }
    //public List<Point> BodyPart { get { return _bodyPart; } }
    public Point Head { get { return _head; } }

    public int LeftIndent { get { return _leftIndent; } }
    public int TopIndent { get { return _topIndent; } }

    public Snake(int leftIndent, int topIndent)
    {
        _leftIndent = leftIndent;
        _topIndent = topIndent;
    }

    public void Instantiate()
    {
        for (int i = 0; i < _initialSize; i++)
        {
            Point bodySegment = new(LeftIndent + i, TopIndent);
            _snakeBody.Add(bodySegment);
        }
    }

    public void MoveLeft()
    {
        List<Point> newSnake = [];

        foreach (Point bodySegment in _snakeBody)
        {
            int newX = bodySegment.X - 1;
            newSnake.Add(new Point(newX, bodySegment.Y));
        }

        if (newSnake.Count > _initialSize)
        {
            _snakeBody.RemoveAt(_snakeBody.Count - 1);
        }

        _snakeBody = newSnake;

        UpdateSnakeDisplay();
    }

    public void MoveRight()
    {
        List<Point> newSnake = [];

        foreach (Point bodySegment in _snakeBody)
        {
            int newX = bodySegment.X + 1;
            newSnake.Add(new Point(newX, bodySegment.Y));
        }

        if (newSnake.Count > _initialSize)
        {
            _snakeBody.RemoveAt(0);
        }

        _snakeBody = newSnake;

        UpdateSnakeDisplay();
    }

    public void MoveTop()
    {
        List<Point> newSnake = [];

        foreach (Point bodySegment in _snakeBody)
        {
            int newY = bodySegment.Y - 1;
            newSnake.Add(new Point(bodySegment.X, newY));
        }

        if (newSnake.Count > _initialSize)
        {
            _snakeBody.RemoveAt(0);
        }

        _snakeBody = newSnake;

        UpdateSnakeDisplay();
    }

    public void MoveBottom()
    {
        List<Point> newSnake = [];

        foreach (Point bodySegment in _snakeBody)
        {
            int newY = bodySegment.Y + 1;
            newSnake.Add(new Point(bodySegment.X, newY));
        }

        if (newSnake.Count > _initialSize)
        {
            _snakeBody.RemoveAt(0);
        }

        _snakeBody = newSnake;

        UpdateSnakeDisplay();
    }

    public void UpdateSnakeDisplay()
    {
        //Console.ForegroundColor = ConsoleColor.Green;
        Console.BackgroundColor = ConsoleColor.Green;

        foreach (Point part in _snakeBody)
        {
            Console.SetCursorPosition(part.X + LeftIndent, part.Y + TopIndent);
            Console.Write(" ");
            Thread.Sleep(70);
        }

        Console.ResetColor();
    }

    public void SnakeCount()
    {
        Console.WriteLine(_snakeBody.Count);
        
        foreach (Point part in _snakeBody)
        {
            Console.WriteLine($"{part.X} {part.Y}");
        }
    }
}