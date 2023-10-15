using System;

namespace LeetCode._1269._Number_of_Ways_to_Stay_in_the_Same_Place;

public class Solution
{
  public int NumWays(int steps, int arrLen)
  {
    const int mod = 1000000007;
    var prev = new int[arrLen];
    var curr = new int[arrLen];
    prev[0] = 1;
    for (var step = 1; step <= steps; step++)
    {
      for (var pos = 0; pos < Math.Min(step + 1, arrLen); pos++)
      {
        curr[pos] = prev[pos];
        if (pos > 0)
          curr[pos] = (curr[pos] + prev[pos - 1]) % mod;
        if (pos + 1 < arrLen)
          curr[pos] = (curr[pos] + prev[pos + 1]) % mod;
      }
      (curr, prev) = (prev, curr);
      Array.Clear(curr);
    }
    return prev[0];
  }
}