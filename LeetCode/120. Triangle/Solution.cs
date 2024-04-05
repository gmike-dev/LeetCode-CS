namespace LeetCode._120._Triangle;

public class Solution
{
  public int MinimumTotal(IList<IList<int>> triangle)
  {
    var dp = new int[triangle[^1].Count];
    triangle[^1].CopyTo(dp, 0);
    for (var i = triangle.Count - 2; i >= 0; i--)
    {
      for (var j = 0; j <= i; j++)
        dp[j] = triangle[i][j] + Math.Min(dp[j], dp[j + 1]);
    }
    return dp[0];
  }
}
