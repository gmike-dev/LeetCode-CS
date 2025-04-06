namespace LeetCode.DP._368._Largest_Divisible_Subset;

public class Solution
{
  public IList<int> LargestDivisibleSubset(int[] nums)
  {
    var n = nums.Length;
    Array.Sort(nums);
    Span<int> dp = stackalloc int[n];
    Span<int> next = stackalloc int[n];
    dp.Fill(1);
    for (var i = n - 1; i >= 0; i--)
    {
      for (var j = i + 1; j < n; j++)
      {
        if (nums[j] % nums[i] == 0 && dp[i] < dp[j] + 1)
        {
          dp[i] = dp[j] + 1;
          next[i] = j;
        }
      }
    }

    var start = 0;
    for (var i = 1; i < n; i++)
    {
      if (dp[i] > dp[start])
        start = i;
    }
    var subset = new int[dp[start]];
    for (int i = 0, j = start, k = 0; i < dp[start]; i++)
    {
      subset[k++] = nums[j];
      j = next[j];
    }
    return subset;
  }
}
