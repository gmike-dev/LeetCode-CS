using System;
using System.Collections.Generic;

namespace LeetCode._15._3Sum;

public class Solution
{
  public IList<IList<int>> ThreeSum(int[] nums)
  {
    Array.Sort(nums);
    var result = new List<IList<int>>();
    for (var i = 0; i < nums.Length - 2 && nums[i] <= 0; i++)
    {
      if (i > 0 && nums[i - 1] == nums[i])
        continue;
      var j = i + 1;
      var k = nums.Length - 1;
      while (j < k)
      {
        var s = nums[j] + nums[k];
        if (nums[i] + s < 0)
          j++;
        else if (nums[i] + s > 0)
          k--;
        else
        {
          result.Add(new[] { nums[i], nums[j], nums[k] });
          while (j < k && nums[j] == nums[j + 1])
            j++;
          while (j < k && nums[k - 1] == nums[k])
            k--;
          j++;
          k--;
        }
      }
    }
    return result;
  }
}