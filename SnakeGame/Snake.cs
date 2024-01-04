using System.Drawing;
using System.Timers;


public class Snake : ISnake
{
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

    public void EatFood()
    {
        SnakePart[] newSnake = new SnakePart[_body.Length + 1];

        Array.Copy(_body, newSnake, _body.Length);

        SnakePart newTailPart = new(Part, Tail.Position);

        newSnake[_body.Length] = newTailPart;

        _body = newSnake;
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

        Thread.Sleep(100);
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