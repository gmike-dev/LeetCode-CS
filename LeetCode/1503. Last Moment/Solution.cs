using System;
using System.Linq;

namespace LeetCode._1503._Last_Moment;

public class Solution
{
  public int GetLastMoment(int n, int[] left, int[] right)
  {
    return left.Concat(right.Select(r => n - r)).Max();
  }
}