using System;

namespace LeetCode.RomanToInteger;

public class Solution
{
  public int RomanToInt(string s)
  {
    var n = 0;
    var pp = 0;
    for (var i = s.Length - 1; i >= 0; i--)
    {
      var p = s[i] switch
      {
        'I' => 1,
        'V' => 5,
        'X' => 10,
        'L' => 50,
        'C' => 100,
        'D' => 500,
        'M' => 1000,
        _ => throw new ArgumentException()
      };
      if (p >= pp)
        n += p;
      else
        n -= p;
      pp = p;
    }
    return n;
  }
}