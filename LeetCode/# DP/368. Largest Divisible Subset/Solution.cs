namespace LeetCode.__DP._368._Largest_Divisible_Subset;

public class Solution
{
  public IList<int> LargestDivisibleSubset(int[] nums)
  {
    var n = nums.Length;
    Array.Sort(nums);
    var dp = new int[n];
    var next = new int[n];
    for (var i = n - 1; i >= 0; i--)
    {
      dp[i] = 1;
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
    var subset = new List<int> { nums[start] };
    for (var i = next[start]; i != 0; i = next[i])
      subset.Add(nums[i]);
    return subset;
  }
}
