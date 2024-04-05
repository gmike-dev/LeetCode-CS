namespace LeetCode._18._4Sum;

public class Solution
{
  public IList<IList<int>> FourSum(int[] nums, int target)
  {
    Array.Sort(nums);
    var result = new List<IList<int>>();
    for (var i = 0; i < nums.Length - 3; i++)
    {
      if (i > 0 && nums[i - 1] == nums[i])
        continue;
      for (var j = i + 1; j < nums.Length - 2; j++)
      {
        if (j > i + 1 && nums[j - 1] == nums[j])
          continue;
        result.AddRange(TwoSum(nums, (long)target - nums[i] - nums[j], j + 1)
          .Select(pair => new[] { nums[i], nums[j], pair.Item1, pair.Item2 }));
      }
    }
    return result;
  }

  private static IEnumerable<(int, int)> TwoSum(int[] nums, long target, int start)
  {
    var k = start;
    var l = nums.Length - 1;
    while (k < l)
    {
      long s = nums[k] + nums[l];
      if (s < target)
        k++;
      else if (s > target)
        l--;
      else
      {
        yield return (nums[k], nums[l]);
        while (k < l && nums[k] == nums[k + 1])
          k++;
        while (k < l && nums[l - 1] == nums[l])
          l--;
        k++;
        l--;
      }
    }
  }
}
