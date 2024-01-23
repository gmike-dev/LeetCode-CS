using System;
using System.Collections.Generic;

namespace LeetCode._1239._Maximum_Length_of_a_Concatenated_String;

public class BitmaskSolution
{
  public int MaxLength(IList<string> arr)
  {
    var n = arr.Count;
    var result = 0;
    for (var mask = 1; mask < (1 << n); mask++)
      result = Math.Max(result, TryBuildSubsequence(mask));
    return result;

    int TryBuildSubsequence(int m)
    {
      var usedChars = 0;
      var length = 0;
      for (var i = 0; m != 0; m >>= 1, i++)
      {
        if ((m & 1) != 0)
        {
          foreach (var c in arr[i])
          {
            var ch = 1 << (c - 'a');
            if ((usedChars & ch) != 0)
              return -1;
            usedChars |= ch;
          }
          length += arr[i].Length;
        }
      }
      return length;
    }
  }
}