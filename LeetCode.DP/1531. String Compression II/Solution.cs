namespace LeetCode._1531._String_Compression_II;

public class Solution
{
  private int[][] dp;

  public int GetLengthOfOptimalCompression(string s, int k)
  {
    dp = new int[s.Length][];
    for (var i = 0; i < s.Length; i++)
    {
      dp[i] = new int[k + 1];
      Array.Fill(dp[i], -1);
    }
    return F(s, 0, k);
  }

  private int F(string s, int start, int k)
  {
    var n = s.Length;
    if (k < 0)
      return n;
    if (start >= n || k >= n - start)
      return 0;
    if (dp[start][k] != -1)
      return dp[start][k];
    var cnt = new int['z' - 'a' + 1];
    var freq = 0;
    var result = int.MaxValue;
    for (var i = start; i < n; i++)
    {
      var c = s[i] - 'a';
      cnt[c]++;
      freq = Math.Max(freq, cnt[c]);
      var length = Length(freq) + F(s, i + 1, k - (i - start + 1 - freq));
      result = Math.Min(result, length);
    }
    return dp[start][k] = result;
  }

  private static int Length(int charCount)
  {
    return charCount switch
    {
      <= 0 => 0,
      1 => 1,
      < 10 => 2,
      < 100 => 3,
      _ => 4
    };
  }
}
