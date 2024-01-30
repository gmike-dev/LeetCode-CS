namespace LeetCode.__DP._560._Subarray_Sum_Equals_K;

public class BruteforceEnhanced
{
  public int SubarraySum(int[] nums, int k)
  {
    var n = nums.Length;
    var count = 0;
    for (var i = 0; i < n; i++)
    {
      var s = 0;
      for (var j = i; j < n; j++)
      {
        s += nums[j];
        if (s == k)
          count++;
      }
    }
    return count;
  }
}