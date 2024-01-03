using System.Drawing;
using System.Linq;

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
    // -------------------------------
    public enum Direction { Up, Down, Left, Right }

    private SnakePart[] _body;
    private int _startingSize;
    private Point _startingPoint;
    public string Part { get; set; }
 
    public SnakePart[] Body { get {  return _body; } }

    public Snake(Point startingPoint, int startingSize, string part = " ")
    {
        _startingPoint = startingPoint;
        _startingSize = startingSize;
        Part = part;

        _body = Enumerable
            .Range(0, _startingSize)
            .Select(x => new SnakePart(Part, _startingPoint))
            .ToArray();
    }

    public void DrawSnake()
    {
        foreach (SnakePart part in _body)
        {
            part.DrawPart();
        }
    }

    public void Move(Direction direction)
    {
        SnakePart newPart = null;

        switch (direction)
        {
            case Direction.Up:
                {
                    newPart = new SnakePart(Part, new Point(_body.First().Position.X, _body.First().Position.Y - 1));
                    break;
                }
            case Direction.Down:
                {
                    newPart = new SnakePart(Part, new Point(_body.First().Position.X, _body.First().Position.Y + 1));
                    break;
                }
            case Direction.Left:
                {
                    newPart = new SnakePart(Part, new Point(_body.First().Position.X - 1, _body.First().Position.Y));
                    break;
                }
            case Direction.Right:
                {
                    newPart = new SnakePart(Part, new Point(_body.First().Position.X + 1, _body.First().Position.Y));
                    break;
                }
        }

        _body.Last().ErasePart();
        for (var i = _body.Length - 1; i > 0; i--)
        {
            _body[i] = _body[i - 1];
        }

        _body[0] = newPart;

        DrawSnake();
    }
}