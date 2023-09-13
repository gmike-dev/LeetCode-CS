using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode._135._Candy;

public class Solution
{
  public int Candy(int[] ratings)
  {
    var n = ratings.Length;
    if (n == 1)
      return 1;
    
    var mins = new PriorityQueue<int, int>();
    if (ratings[0] <= ratings[1])
      mins.Enqueue(0, ratings[0]);
    if (ratings[n - 1] <= ratings[n - 2])
      mins.Enqueue(n - 1, ratings[n - 1]);
    for (var i = 1; i < n - 1; i++)
    {
      if (ratings[i - 1] >= ratings[i] && ratings[i] <= ratings[i + 1])
        mins.Enqueue(i, ratings[i]);
    }
    var candies = new int[n];
    while (mins.Count > 0)
    {
      var minPos = mins.Dequeue();
      if (candies[minPos] != 0)
        continue;
      candies[minPos] = 1;
      for (var i = minPos + 1; i < n && candies[i] == 0 && ratings[i] > ratings[i - 1]; i++)
        candies[i] = candies[i - 1] + 1;
      for (var i = minPos - 1; i >= 0 && candies[i] == 0 && ratings[i] > ratings[i + 1]; i--)
        candies[i] = candies[i + 1] + 1;
    }

    for (var i = 1; i < n - 1; i++)
    {
      if (ratings[i - 1] < ratings[i] && ratings[i] > ratings[i + 1] &&
          (candies[i - 1] >= candies[i] || candies[i] <= candies[i + 1]))
        candies[i] = Math.Max(candies[i - 1], candies[i + 1]) + 1;
    }
    
    return candies.Sum();
  }
}