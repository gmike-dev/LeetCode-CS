namespace LeetCode._2008._Maximum_Earnings_From_Taxi;

public class LinearSolution
{
  public long MaxTaxiEarnings(int n, int[][] rides)
  {
    var maxProfit = new long[n + 1];
    var posRides = new List<int[]>[n + 1];
    foreach (var ride in rides)
      (posRides[ride[1]] ??= new List<int[]>()).Add(ride);

    for (var i = 1; i <= n; i++)
    {
      maxProfit[i] = maxProfit[i - 1];
      if (posRides[i] != null)
      {
        foreach (var ride in posRides[i])
          maxProfit[i] = Math.Max(maxProfit[i], Earnings(ride) + maxProfit[ride[0]]);
      }
    }

    return maxProfit[n];
  }

  private static int Earnings(int[] ride) => ride[1] - ride[0] + ride[2];
}
