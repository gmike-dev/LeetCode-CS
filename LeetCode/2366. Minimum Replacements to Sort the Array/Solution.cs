namespace LeetCode._2366._Minimum_Replacements_to_Sort_the_Array;

public class Solution
{
  public long MinimumReplacement(int[] nums)
  {
    var n = nums.Length;
    if (n == 1)
      return 0;
    var result = 0L;
    for (var i = n - 2; i >= 0; i--)
    {
      if (nums[i] <= nums[i + 1])
        continue;
      var k = (nums[i] + nums[i + 1] - 1) / nums[i + 1];
      result += k - 1;
      nums[i] /= k;
    }
    return result;
  }
}