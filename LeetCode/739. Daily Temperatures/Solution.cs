namespace LeetCode._739._Daily_Temperatures;

public class Solution
{
  public int[] DailyTemperatures(int[] temperatures)
  {
    var day = new int[101]; // only range [30; 100] is used.
    var n = temperatures.Length;
    var result = new int[n];
    for (var i = n - 1; i >= 0; i--)
    {
      var minDistance = int.MaxValue;
      for (var j = temperatures[i] + 1; j <= 100; j++)
      {
        if (day[j] != 0)
          minDistance = Math.Min(minDistance, day[j] - i);
      }
      if (minDistance != int.MaxValue)
        result[i] = minDistance;
      day[temperatures[i]] = i;
    }
    return result;
  }
}
