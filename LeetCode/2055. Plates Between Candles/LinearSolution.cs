namespace LeetCode._2055._Plates_Between_Candles;

public class LinearSolution
{
  public int[] PlatesBetweenCandles(string s, int[][] queries)
  {
    var m = s.Length;
    var prevCandle = new int[m];
    var candle = -1;
    for (var i = 0; i < m; i++)
    {
      if (s[i] == '|')
        candle = i;
      prevCandle[i] = candle;
    }
    var nextCandle = new int[m];
    candle = m;
    for (var i = m - 1; i >= 0; i--)
    {
      if (s[i] == '|')
        candle = i;
      nextCandle[i] = candle;
    }
    var platesCount = new int[m + 1];
    var count = 0;
    for (var i = 0; i < m; i++)
    {
      if (s[i] == '*')
        count++;
      platesCount[i + 1] = count;
    }
    var n = queries.Length;
    var result = new int[n];
    for (var i = 0; i < n; i++)
    {
      var q = queries[i];
      var left = nextCandle[q[0]];
      var right = prevCandle[q[1]];
      if (left < right)
        result[i] = platesCount[right + 1] - platesCount[left];
    }
    return result;
  }
}