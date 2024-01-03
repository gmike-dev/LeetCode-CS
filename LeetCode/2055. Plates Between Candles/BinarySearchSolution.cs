using System.Collections.Generic;

namespace LeetCode._2055._Plates_Between_Candles;

public class BinarySearchSolution
{
  public int[] PlatesBetweenCandles(string s, int[][] queries)
  {
    var m = s.Length;
    var candles = new List<int>(m);
    for (var i = 0; i < m; i++)
    {
      if (s[i] == '|')
        candles.Add(i);
    }
    var n = queries.Length;
    var result = new int[n];
    for (var i = 0; i < n; i++)
    {
      var q = queries[i];
      var nextCandle = candles.BinarySearch(q[0]);
      if (nextCandle < 0)
        nextCandle = ~nextCandle;
      var prevCandle = candles.BinarySearch(q[1]);
      if (prevCandle < 0)
        prevCandle = ~prevCandle - 1;
      var dist = prevCandle - nextCandle;
      if (dist > 0)
        result[i] = candles[prevCandle] - candles[nextCandle] - dist;
    }
    return result;
  }
}