using System.Collections.Generic;
using System.Linq;

namespace LeetCode._1291._Sequential_Digits;

public class QueueSolution
{
  public IList<int> SequentialDigits(int low, int high)
  {
    var q = new Queue<int>(Enumerable.Range(1, 9));
    var result = new List<int>();
    while (q.TryDequeue(out var n) && n <= high)
    {
      if (n >= low)
        result.Add(n);
      if (n % 10 < 9)
        q.Enqueue(n * 10 + n % 10 + 1);
    }
    result.Sort();
    return result;
  }
}
