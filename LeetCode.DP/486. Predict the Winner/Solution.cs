namespace LeetCode.DP._486._Predict_the_Winner;

public class Solution
{
  public bool PredictTheWinner(int[] nums)
  {
    var n = nums.Length;
    var dp = InitDp(n);

    // Calculate last move (1-length segments).
    var firstPlayerMovesLast = n % 2 != 0;
    if (firstPlayerMovesLast)
    {
      for (var i = 0; i < n; i++)
        dp[i][i] = nums[i];
    }

    for (var move = n - 2; move >= 0; move--)
    {
      var firstPlayerMove = move % 2 == 0;
      var segLength = n - move - 1;
      for (var l = 0; l <= move; l++)
      {
        var r = l + segLength;
        if (firstPlayerMove)
          dp[l][r] = Math.Max(nums[l] + dp[l + 1][r], nums[r] + dp[l][r - 1]);
        else
          dp[l][r] = Math.Min(dp[l + 1][r], dp[l][r - 1]);
      }
    }
    var firstPlayerPoints = dp[0][n - 1];
    return 2 * firstPlayerPoints >= nums.Sum();
  }

  private static int[][] InitDp(int n)
  {
    var d = new int[n][];
    for (var i = 0; i < n; i++)
      d[i] = new int[n];
    return d;
  }

  public bool PredictTheWinner_Recursion(int[] nums)
  {
    var firstPlayerPoints = CalculatePoints(nums, 0, nums.Length - 1, true);
    return 2 * firstPlayerPoints >= nums.Sum();
  }

  private int CalculatePoints(int[] nums, int l, int r, bool firstPlayerTurn)
  {
    if (l == r)
      return firstPlayerTurn ? nums[l] : 0;

    if (firstPlayerTurn)
      return Math.Max(
        nums[l] + CalculatePoints(nums, l + 1, r, false),
        nums[r] + CalculatePoints(nums, l, r - 1, false));

    return Math.Min(
      CalculatePoints(nums, l + 1, r, true),
      CalculatePoints(nums, l, r - 1, true));
  }
}
