namespace LeetCode._1561._Maximum_Number_of_Coins;

public class LinearSolution
{
  public int MaxCoins(int[] piles)
  {
    var cnt = new int[10001];
    foreach (var p in piles)
      cnt[p]++;
    var count = piles.Length;
    var ans = 0;
    var l = 0;
    var m = cnt.Length - 1;
    var r = cnt.Length - 1;
    while (count > 0)
    {
      while (cnt[l] == 0)
        l++;
      while (cnt[r] == 0)
        r--;
      if (m > r)
        m = r;
      while (cnt[m] == 0 || m == r && cnt[m] == 1)
        m--;
      ans += m;
      cnt[l]--;
      cnt[m]--;
      cnt[r]--;
      count -= 3;
    }
    return ans;
  }
}