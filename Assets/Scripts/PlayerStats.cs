public class PlayerStats
{
    // Points of player
    private static int points = 0;

    /// <summary>
    /// Add some points.
    /// </summary>
    /// <param name="amount">The amount of points to add</param>
    public static void AddAmountPoints(int amount)
    {
        if (amount > 0)
        {
            points += amount;
        }
    }

    /// <summary>
    /// Get points.
    /// </summary>
    public static int getPoints()
    {
        return points;
    }

    public static void resetPoints()
    {
        points = 0;
    }
}