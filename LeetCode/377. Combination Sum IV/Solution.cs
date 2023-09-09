using System;
using System.Linq;

namespace LeetCode._377._Combination_Sum_IV;

public class Solution
{
  public int CombinationSum4(int[] nums, int target)
  {
    var n = nums.Length;
    var dp = new int[target + 1];
    dp[0] = 1;
    for (var s = 0; s < target; s++)
    {
      if (dp[s] == 0)
        continue;
      for (var j = 0; j < n; j++)
      {
        if (s + nums[j] <= target)
          dp[s + nums[j]] += dp[s];
      }
    }
    return dp[target];
  }
}