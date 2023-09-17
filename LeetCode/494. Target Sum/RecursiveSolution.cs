using System.Collections.Generic;

namespace LeetCode._494._Target_Sum;

public class RecursiveSolution
{
  private readonly Dictionary<(int, int), int> _cache = new();

  public int FindTargetSumWays(int[] nums, int target)
  {
    return Find(nums, 0, target);
  }

  private int Find(int[] nums, int start, int target)
  {
    if (start == nums.Length)
      return target == 0 ? 1 : 0;

    var key = (start, target);
    if (!_cache.TryGetValue(key, out var result))
    {
      result = Find(nums, start + 1, target - nums[start]) +
               Find(nums, start + 1, target + nums[start]);
      _cache[key] = result;
    }
    return result;
  }
}