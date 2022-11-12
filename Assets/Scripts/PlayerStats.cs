public class PlayerStats
{
    private static int points = 0;

    public static void AddAmountPoints(int amount)
    {
        if (amount > 0)
        {
            points += amount;
        }
    }

    public static int getPoints()
    {
        return points;
    }
}
