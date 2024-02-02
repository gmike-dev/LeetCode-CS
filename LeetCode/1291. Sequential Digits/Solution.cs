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
    var first = 1;
    for (var len = 2; len <= 9; len++)
    {
      div *= 10;
      first = first * 10 + len;
      yield return first;
      for (int i = len + 1, n = first; i <= 9; i++)
      {
        n = n % div * 10 + i;
        yield return n;
      }
    }
  }
}
