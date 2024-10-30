namespace LeetCode._300._Longest_Increasing_Subsequence;

public class DpSolution
{
  public int LengthOfLIS(int[] nums)
  {
    var n = nums.Length;
    var length = new int[n];
    Array.Fill(length, 1);
    for (var i = 1; i < n; i++)
    {
      for (var j = 0; j < i; j++)
      {
        if (nums[j] < nums[i])
          length[i] = Math.Max(length[i], length[j] + 1);
      }
    }
    return length.Max();
  }
}
