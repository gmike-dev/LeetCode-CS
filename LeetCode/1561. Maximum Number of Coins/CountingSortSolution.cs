using System;

namespace LeetCode._1561._Maximum_Number_of_Coins;

public class CountingSortSolution
{
  public int MaxCoins(int[] piles)
  {
    CountingSort(piles, 10_000);
    var l = 0;
    var r = piles.Length - 2;
    var ans = 0;
    while (l < r)
    {
      ans += piles[r];
      r -= 2;
      l++;
    }
    return ans;
  }

  private static void CountingSort(int[] a, int max)
  {
    var cnt = new int[max + 1];
    foreach (var num in a)
      cnt[num]++;
    var len = 0;
    for (var i = 1; len < a.Length; i++)
    {
      for (var j = cnt[i]; j > 0; j--)
        a[len++] = i;
    }
  }
}