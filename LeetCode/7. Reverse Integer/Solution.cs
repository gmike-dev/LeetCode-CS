using System;

namespace LeetCode._7._Reverse_Integer;

/// <summary>
/// https://leetcode.com/problems/reverse-integer/
/// </summary>
public class Solution
{
  public int Reverse(int x)
  {
    if (x == int.MinValue)
      return 0;
    var max = int.MaxValue / 10;
    var maxD = int.MaxValue % 10;
    var neg = x < 0;
    x = Math.Abs(x);
    var y = 0;
    while (x != 0)
    {
      var d = x % 10;
      if (y > max || y == max && d > maxD)
        return 0;
      y = y * 10 + d;
      x /= 10;
    }
    return neg ? -y : y;
  }
}