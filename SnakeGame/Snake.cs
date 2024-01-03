using System.Drawing;

public class Snake : ISnake
{
    private List<Point> snakeBody = [];
    private List<Point> bodyPart = [];
    private Point head = new();

    public List<Point> SnakeBody { get { return snakeBody; } }
    public List<Point> BodyPart { get { return bodyPart; } }
    public Point Head { get { return head; } }

    public void Instantiate()
    {

    }
}