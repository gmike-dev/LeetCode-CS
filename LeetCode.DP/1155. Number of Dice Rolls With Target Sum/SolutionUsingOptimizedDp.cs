namespace LeetCode.DP._1155._Number_of_Dice_Rolls_With_Target_Sum;

public class SolutionUsingOptimizedDp
{
  public int NumRollsToTarget(int n, int k, int target)
  {
    if (n == 1)
      return target <= k ? 1 : 0;
    const int mod = (int)1e9 + 7;
    var prev = new int[target + 1];
    var curr = new int[target + 1];
    for (var i = 1; i <= Math.Min(k, target); i++)
      prev[i] = 1;
    for (var i = 1; i < n; i++)
    {
      for (var s = 1; s <= target; s++)
      {
        for (var d = 1; d <= k && s + d <= target; d++)
          curr[s + d] = (curr[s + d] + prev[s]) % mod;
      }
      (prev, curr) = (curr, prev);
      Array.Clear(curr);
    }
    return prev[target];
  }
}
