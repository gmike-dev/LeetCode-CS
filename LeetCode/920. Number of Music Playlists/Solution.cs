using System;

namespace LeetCode._920._Number_of_Music_Playlists;

public class Solution
{
  public int NumMusicPlaylists(int n, int goal, int k)
  {
    const int mod = 1000000007;
    var dp = new int[goal + 1, n + 1];
    dp[0, 0] = 1;
    for (var i = 1; i <= goal; i++)
    {
      for (var j = 1; j <= Math.Min(n, i); j++)
      {
        dp[i, j] = (int)((long)dp[i - 1, j - 1] * (n - j + 1) % mod);
        if (j > k)
          dp[i, j] = (int)((dp[i, j] + (long)dp[i - 1, j] * (j - k) % mod) % mod);
        
      }
    }
    return dp[goal, n];
  }
}