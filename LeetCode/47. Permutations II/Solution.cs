using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode._47._Permutations_II;

public class Solution
{
  public IList<IList<int>> PermuteUnique(int[] nums)
  {
    var result = new List<IList<int>>();
    var generator = new PermuteGenerator(items => result.Add(items.ToList()));
    generator.Permute(nums);
    return result;
  }

  private class PermuteGenerator
  {
    private readonly Action<int[]> _handler;

    public void Permute(int[] items) => Permute(items, 0);

    private void Permute(int[] items, int i)
    {
      if (i == items.Length)
      {
        _handler(items);
      }
      else
      {
        var used = new HashSet<int>();
        for (var j = i; j < items.Length; j++)
        {
          if (used.Add(items[j]))
          {
            (items[i], items[j]) = (items[j], items[i]);
            Permute(items, i + 1);
            (items[i], items[j]) = (items[j], items[i]);
          }
        }
      }
    }

    public PermuteGenerator(Action<int[]> handler)
    {
      _handler = handler;
    }
  }
}