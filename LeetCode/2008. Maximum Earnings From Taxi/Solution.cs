namespace LeetCode._2008._Maximum_Earnings_From_Taxi;

public class Solution
{
  public long MaxTaxiEarnings(int _, int[][] rides)
  {
    var n = rides.Length;
    Array.Sort(rides, ByEndTime);
    var maxProfit = new long[n];
    maxProfit[0] = Profit(rides[0]);
    for (var i = 1; i < n; i++)
    {
      long profit = Profit(rides[i]);
      var prev = FindPrevRide(i);
      if (prev >= 0)
        profit += maxProfit[prev];
      maxProfit[i] = Math.Max(profit, maxProfit[i - 1]);
    }
    return maxProfit[n - 1];

    int Profit(int[] ride)
    {
      return ride[1] - ride[0] + ride[2];
    }

    int ByEndTime(int[] x, int[] y)
    {
      return x[1] - y[1];
    }

    int FindPrevRide(int i)
    {
      var l = 0;
      var r = i - 1;
      var startTime = rides[i][0];
      while (l <= r)
      {
        var m = l + (r - l) / 2;
        if (rides[m][1] <= startTime)
          l = m + 1;
        else
          r = m - 1;
      }
      return r;
    }
  }
}
