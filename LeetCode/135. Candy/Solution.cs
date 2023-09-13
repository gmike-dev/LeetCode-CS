using System;
using System.Linq;

namespace LeetCode._135._Candy;

public class Solution
{
  public int Candy(int[] ratings)
  {
    var n = ratings.Length;
    if (n < 2)
      return n;
    var candies = new int[n];
    candies.AsSpan().Fill(1);
    for (var i = 1; i < n; i++)
    {
      if (ratings[i] > ratings[i - 1])
        candies[i] = candies[i - 1] + 1;
    }
    for (var i = n - 2; i >= 0; i--)
    {
      if (ratings[i] > ratings[i + 1])
        candies[i] = Math.Max(candies[i], candies[i + 1] + 1);
    }
    return candies.Sum();
  }
}