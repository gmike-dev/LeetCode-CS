using System.Collections.Generic;
using System.Linq;

namespace LeetCode._1291._Sequential_Digits;

public class Solution
{
  public IList<int> SequentialDigits(int low, int high)
  {
    return EnumerateDigits()
      .SkipWhile(x => x < low)
      .TakeWhile(x => x <= high)
      .ToArray();
  }

  private static IEnumerable<int> EnumerateDigits()
  {
    var div = 1;
    var start = 1;
    for (var len = 2; len <= 9; len++)
    {
      div *= 10;
      for (int i = len, n = start; i <= 9; i++)
      {
        n = n % div * 10 + i;
        yield return n;
      }
      start = start * 10 + len;
    }
  }
}
