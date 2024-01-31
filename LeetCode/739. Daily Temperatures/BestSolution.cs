namespace LeetCode._739._Daily_Temperatures;

public class BestSolution
{
  public int[] DailyTemperatures(int[] temperatures)
  {
    var n = temperatures.Length;
    var distance = new int[n];
    var maxT = int.MinValue;
    for (var i = n - 1; i >= 0; i--)
    {
      var t = temperatures[i];
      if (maxT <= t)
      {
        maxT = t;
      }
      else
      {
        var k = 1;
        while (temperatures[i + k] <= t)
          k += distance[i + k];
        distance[i] = k;
      }
    }
    return distance;
  }
}