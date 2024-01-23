using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace LeetCode._1239._Maximum_Length_of_a_Concatenated_String;

public class BitmaskSolution
{
  public int MaxLength(IList<string> arr)
  {
    return Enumerable.Range(1, (1 << arr.Count) - 1).Max(SubsequenceLength);

    int SubsequenceLength(int mask)
    {
      var set = 0u;
      for (var i = 0; mask != 0; mask >>= 1, i++)
      {
        if ((mask & 1) != 0)
        {
          foreach (var c in arr[i])
          {
            var ch = 1u << (c - 'a');
            if ((set & ch) != 0)
              return 0;
            set |= ch;
          }
        }
      }
      return BitOperations.PopCount(set);
    }
  }
}