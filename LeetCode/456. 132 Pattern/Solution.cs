using System.Collections;

namespace LeetCode._456._132_Pattern;

public class Solution
{
  public bool Find132pattern(int[] a)
  {
    var n = a.Length;
    var third = int.MinValue;
    var s = new Stack<int>();
    for (var i = n - 1; i >= 0; i--)
    {
      if (a[i] < third)
        return true;
      while (s.TryPeek(out var top) && top < a[i])
        third = s.Pop();
      s.Push(a[i]);
    }
    return false;
  }
}
