using System;

namespace LeetCode._1561._Maximum_Number_of_Coins;

public class SortSolution
{
  public int MaxCoins(int[] piles)
  {
    Array.Sort(piles);
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
}