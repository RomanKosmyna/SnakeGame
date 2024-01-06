public class Scoreboard
{
    private int score = 0;

    public int Score { get { return score; } }

    public void IncrementScore()
    {
        score++;
    }
}