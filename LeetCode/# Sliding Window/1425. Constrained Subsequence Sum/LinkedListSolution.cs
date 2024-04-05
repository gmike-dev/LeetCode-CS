namespace LeetCode.__Sliding_Window._1425._Constrained_Subsequence_Sum;

public class LinkedListSolution
{
  public int ConstrainedSubsetSum(int[] nums, int k)
  {
    var d = new LinkedList<int>();
    d.AddLast(0);
    var n = nums.Length;
    var dp = new int[n];
    dp[0] = nums[0];
    for (var i = 1; i < n; i++)
    {
      dp[i] = Math.Max(nums[i], dp[d.First.Value] + nums[i]);
      while (d.Count > 0 && dp[d.Last.Value] <= dp[i])
        d.RemoveLast();
      d.AddLast(i);
      while (d.First.Value <= i - k)
        d.RemoveFirst();
    }
    return dp.Max();
  }
}
