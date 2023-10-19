namespace LeetCode._713._Subarray_Product_Less_Than_K;

public class Solution
{
  public int NumSubarrayProductLessThanK(int[] nums, int k)
  {
    if (k <= 1)
      return 0;
    
    var n = nums.Length;
    var ans = 0;
    for (int i = 0, j = 0, p = nums[0]; i < n; i++)
    {
      while (j < n && p < k)
      {
        ans += j - i + 1;
        j++;
        if (j < n)
          p *= nums[j];
      }
      p /= nums[i];
    }
    return ans;
  }
}