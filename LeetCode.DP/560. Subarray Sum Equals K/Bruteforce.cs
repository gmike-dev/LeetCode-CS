namespace LeetCode.DP._560._Subarray_Sum_Equals_K;

public class Bruteforce
{
  public int SubarraySum(int[] nums, int k)
  {
    var n = nums.Length;
    var s = new int[n + 1];
    for (var i = 0; i < n; i++)
      s[i + 1] = s[i] + nums[i];
    var count = 0;
    for (var i = 0; i < n; i++)
    {
      for (var j = i + 1; j <= n; j++)
      {
        if (s[j] - s[i] == k)
          count++;
      }
    }
    return count;
  }
}