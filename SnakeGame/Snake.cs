using System.Drawing;

public class Snake : ISnake
{
    //private List<Point> _snakeBody = [];
    ////private readonly List<Point> _bodyPart = [];
    //private Point _head;

    //private readonly int _initialSize = 1;

    //private readonly int _leftIndent;
    //private readonly int _topIndent;

    //public List<Point> SnakeBody { get { return _snakeBody; } }
    ////public List<Point> BodyPart { get { return _bodyPart; } }
    ////public Point Head { get { return _head; } }

    //public int LeftIndent { get { return _leftIndent; } }
    //public int TopIndent { get { return _topIndent; } }

    //public Snake(int leftIndent, int topIndent)
    //{
    //    _leftIndent = leftIndent;
    //    _topIndent = topIndent;
    //}

    //public void Instantiate()
    //{
    //    for (int i = 0; i < _initialSize; i++)
    //    {
    //        Point bodySegment = new(LeftIndent + i, TopIndent);
    //        _snakeBody.Add(bodySegment);
    //    }
    //}

    //public void MoveLeft()
    //{
    //    List<Point> newSnake = [];

    //    foreach (Point bodySegment in _snakeBody)
    //    {
    //        int newX = bodySegment.X - 1;
    //        newSnake.Add(new Point(newX, bodySegment.Y));
    //    }

    //    if (newSnake.Count > _initialSize)
    //    {
    //        _snakeBody.RemoveAt(_snakeBody.Count - 1);
    //    }

    //    _snakeBody = newSnake;

    //    UpdateSnakeDisplay();
    //}

    //public void MoveRight()
    //{
    //    List<Point> newSnake = [];

    //    foreach (Point bodySegment in _snakeBody)
    //    {
    //        int newX = bodySegment.X + 1;
    //        newSnake.Add(new Point(newX, bodySegment.Y));
    //    }

    //    if (newSnake.Count > _initialSize)
    //    {
    //        _snakeBody.RemoveAt(0);
    //    }

    //    _snakeBody = newSnake;

    //    UpdateSnakeDisplay();
    //}

    //public void MoveTop()
    //{
    //    List<Point> newSnake = [];

    //    foreach (Point bodySegment in _snakeBody)
    //    {
    //        int newY = bodySegment.Y - 1;
    //        newSnake.Add(new Point(bodySegment.X, newY));
    //    }

    //    if (newSnake.Count > _initialSize)
    //    {
    //        _snakeBody.RemoveAt(0);
    //    }

    //    _snakeBody = newSnake;

    //    UpdateSnakeDisplay();
    //}

    //public void MoveBottom()
    //{
    //    List<Point> newSnake = [];

    //    foreach (Point bodySegment in _snakeBody)
    //    {
    //        int newY = bodySegment.Y + 1;
    //        newSnake.Add(new Point(bodySegment.X, newY));
    //    }

    //    if (newSnake.Count > _initialSize)
    //    {
    //        _snakeBody.RemoveAt(0);
    //    }

    //    _snakeBody = newSnake;

    //    UpdateSnakeDisplay();
    //}

    //public void UpdateSnakeDisplay()
    //{
    //    //Console.ForegroundColor = ConsoleColor.Green;
    //    Console.BackgroundColor = ConsoleColor.Green;

    //    foreach (Point part in _snakeBody)
    //    {
    //        Console.SetCursorPosition(part.X + LeftIndent, part.Y + TopIndent);
    //        Console.Write(" ");
    //        Thread.Sleep(70);
    //    }

    //    Console.ResetColor();
    //}

    //public void SnakeCount()
    //{
    //    Console.WriteLine(_snakeBody.Count);
        
    //    foreach (Point part in _snakeBody)
    //    {
    //        Console.WriteLine($"{part.X} {part.Y}");
    //    }
    //}
    // -------------------------------
    public enum Direction { Up, Down, Left, Right }

    private SnakePart[] _body;
    private int _startingSize;
    private Point _startingPoint;
    public string Part { get; set; }
    public SnakePart Head => _body.First();
    public SnakePart Tail => _body.Last();

    public SnakePart[] Body { get {  return _body; } }

    public Snake(Point startingPoint, int startingSize, string part = "  ")
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
            if (part == Head)
            {
                part.DrawHead();
            }
            else
            {
                part.DrawPart();
            }
        }
    }

    public void Move(Direction direction)
    {
        SnakePart? newHead = null;

        switch (direction)
        {
            case Direction.Up:
                {
                    newHead = new SnakePart(Part, new Point(Head.Position.X, Head.Position.Y - 1));
                    break;
                }
            case Direction.Down:
                {
                    newHead = new SnakePart(Part, new Point(Head.Position.X, Head.Position.Y + 1));
                    break;
                }
            case Direction.Left:
                {
                    newHead = new SnakePart(Part, new Point(Head.Position.X - 1, Head.Position.Y));
                    break;
                }
            case Direction.Right:
                {
                    newHead = new SnakePart(Part, new Point(Head.Position.X + 1, Head.Position.Y));
                    break;
                }
        }

        Tail.ErasePart();

        for (var i = _body.Length - 1; i > 0; i--)
        {
            _body[i] = _body[i - 1];
        }

        _body[0] = newHead;

        IsSnakeMovingOutOfPlayfieldByX();
        IsSnakeMovingOutOfPlayfieldByY();

        DrawSnake();
        Thread.Sleep(70);
    }

    public bool IsSnakeCollisionNotDetected()
    {
        for (int i = 1; i < _body.Length; i++)
        {
            if (Head.Position.X == _body[i].Position.X && Head.Position.Y == _body[i].Position.Y)
            {
                return false;
            }
        }
        
        return true;
    }

    public void IsSnakeMovingOutOfPlayfieldByX()
    {
        if (Head.Position.X < 6)
        {
            Head.Position = new Point(Playfield.PlayField.GetLength(0) + 24, Head.Position.Y);
        }

        if (Head.Position.X > Playfield.PlayField.GetLength(0) + 24)
        {
            Head.Position = new Point(6, Head.Position.Y);
        }
    }

    public void IsSnakeMovingOutOfPlayfieldByY()
    {
        if (Head.Position.Y < 3)
        {
            Head.Position = new Point(Head.Position.X, 22);
        }

        if (Head.Position.Y > 22)
        {
            Head.Position = new Point(Head.Position.X, 3);
        }
    }
}