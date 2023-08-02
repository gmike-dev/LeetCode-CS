using System.Collections.Generic;
using System.Linq;

namespace LeetCode._77._Combinations;

public class Solution
{
  public IList<IList<int>> Combine(int n, int k)
  {
    var result = new List<IList<int>>();
    for (var i = 1; i < 1 << n; i++)
    {
      var ones = 0;
      for (var x = i; x != 0; x >>= 1)
        ones += x & 1;
      if (ones != k)
        continue;
      var list = new List<int>(k);
      for (int x = i, item = 1; x != 0; x >>= 1, item++)
        if ((x & 1) == 1)
          list.Add(item);
      result.Add(list);
    }
    return result;
  }
  
  public IList<IList<int>> Combine_Recursion(int n, int k)
  {
    return Combine(1, n, k).ToList();
  }
  
  private static IEnumerable<IList<int>> Combine(int from, int n, int k)
  {
    if (k == 1)
    {
      for (var i = from; i <= n; i++)
        yield return new List<int> { i };
    }
    else if (n - from + 1 == k)
    {
      yield return Enumerable.Range(from, k).ToList();
    }
    else
    {
      for (var i = from; i <= n - k + 1; i++)
      {
        foreach (var combination in Combine(i + 1, n, k - 1))
        {
          var item = new List<int> { i };
          item.AddRange(combination);
          yield return item;
        }
      }
    }
  }
}