namespace LeetCode.DP._560._Subarray_Sum_Equals_K;

/// <summary>
/// https://leetcode.com/problems/subarray-sum-equals-k/
/// </summary>
public class LinearSolution
{
  public int SubarraySum(int[] nums, int k)
  {
    var n = nums.Length;
    var result = 0;
    var count = new Dictionary<int, int> { { 0, 1 } };
    var s = 0;
    for (var i = 0; i < n; i++)
    {
      s += nums[i];
      result += count.GetValueOrDefault(s - k, 0);
      count[s] = count.GetValueOrDefault(s, 0) + 1;
    }
    return result;
  }
}
