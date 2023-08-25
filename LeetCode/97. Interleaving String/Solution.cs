namespace LeetCode._97._Interleaving_String;

public class Solution
{
  public bool IsInterleave(string s1, string s2, string s3)
  {
    var m = s1.Length;
    var n = s2.Length;
    if (m + n != s3.Length)
      return false;
    var dp = new bool[m + 1][];
    for (var i = 0; i <= m; i++)
      dp[i] = new bool[n + 1];
    dp[0][0] = true;
    for (var i = 0; i < m && s1[i] == s3[i]; i++)
      dp[i + 1][0] = true;
    for (var i = 0; i < n && s2[i] == s3[i]; i++)
      dp[0][i + 1] = true;
    for (var i = 0; i < m; i++)
    for (var j = 0; j < n; j++)
    {
      dp[i + 1][j + 1] = dp[i][j + 1] && s1[i] == s3[i + j + 1] ||
                         dp[i + 1][j] && s2[j] == s3[i + j + 1];
    }
    return dp[m][n];
  }

}