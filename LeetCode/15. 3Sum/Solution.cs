using System;
using System.Collections.Generic;

namespace LeetCode._15._3Sum;

public class Solution
{
  public IList<IList<int>> ThreeSum(int[] nums)
  {
    const int m = 100001;
    var cnt = new int[2 * m + 1];

    foreach (var num in nums)
      cnt[m + num]++;

    var hashSet = new HashSet<(int, int, int)>();
    for (var i = 0; i < nums.Length - 2; i++)
    {
      cnt[m + nums[i]]--;
      for (var j = i + 1; j < nums.Length - 1; j++)
      {
        var a = nums[i];
        var b = nums[j];
        cnt[m + nums[j]]--;
        var c = -(a + b);
        if (Math.Abs(c) < m && cnt[m + c] > 0)
        {
          if (a > b)
            (a, b) = (b, a);
          if (a > c)
            (a, c) = (c, a);
          if (b > c)
            (b, c) = (c, b);
          hashSet.Add((a, b, c));
        }
        cnt[m + nums[j]]++;
      }
      cnt[m + nums[i]]++;
    }

    var result = new List<IList<int>>();
    foreach (var (a, b, c) in hashSet)
      result.Add(new[] { a, b, c });
    return result;
  }
}