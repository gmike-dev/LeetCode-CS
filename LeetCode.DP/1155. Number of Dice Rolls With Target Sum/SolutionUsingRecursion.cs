namespace LeetCode.DP._1155._Number_of_Dice_Rolls_With_Target_Sum;

public class SolutionUsingRecursion
{
  private readonly Dictionary<(int, int), int> cache = new();

  public int NumRollsToTarget(int n, int k, int target)
  {
    if (target <= 0)
      return 0;
    if (n == 1)
      return target <= k ? 1 : 0;
    var cacheKey = (n, target);
    if (cache.TryGetValue(cacheKey, out var ans))
      return ans;
    const int mod = (int)1e9 + 7;
    for (var i = 1; i <= k; i++)
      ans = (ans + NumRollsToTarget(n - 1, k, target - i)) % mod;
    cache[cacheKey] = ans;
    return ans;
  }
}
