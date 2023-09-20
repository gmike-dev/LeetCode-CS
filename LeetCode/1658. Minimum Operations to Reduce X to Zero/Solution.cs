using System;

namespace LeetCode._1658._Minimum_Operations_to_Reduce_X_to_Zero;

public class Solution
{
  public int MinOperations(int[] nums, int x)
  {
    int front = 0, s = 0, n = nums.Length;
    for (; front < n && s < x; front++)
      s += nums[front];
    if (s < x)
      return -1;
    var ans = s == x ? front : n + 1;
    for (var back = 1; back < n; back++)
    {
      x -= nums[^back];
      while (front > 0 && s > x)
      {
        front--;
        s -= nums[front];
      }
      if (s == x)
        ans = Math.Min(ans, front + back);
    }

    return ans > n ? -1 : ans;
  }
}