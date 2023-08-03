using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode._735._Asteroid_Collision;

public class Solution
{
  public int[] AsteroidCollision(int[] asteroids)
  {
    var i = 0;
    var n = asteroids.Length;
    var result = new List<int>();
    while (i < n && asteroids[i] < 0)
    {
      result.Add(asteroids[i]);
      i++;
    }
    var right = new Stack<int>();
    for (; i < n; i++)
    {
      var a = asteroids[i];
      if (a > 0)
      {
        right.Push(a);
      }
      else
      {
        while (right.Count > 0 && right.Peek() < Math.Abs(a))
          right.Pop();
        if (right.Count == 0)
          result.Add(a);
        else if (right.Peek() == Math.Abs(a))
          right.Pop();
      }
    }
    result.AddRange(right.Reverse());
    return result.ToArray();
  }
}