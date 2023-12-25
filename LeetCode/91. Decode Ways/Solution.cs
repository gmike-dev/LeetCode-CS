namespace LeetCode._91._Decode_Ways;

public class Solution
{
  public int NumDecodings(string s)
  {
    if (s[0] == '0')
      return 0;
    var n = s.Length;
    var dp = new int[n + 1];
    dp[0] = dp[1] = 1;
    for (var len = 2; len <= s.Length; len++)
    {
      if (s[len - 1] > '0')
        dp[len] = dp[len - 1];
      var k = (s[len - 2] - '0') * 10 + s[len - 1] - '0';
      if (k is >= 10 and <= 26)
        dp[len] += dp[len - 2];
    }
    return dp[n];
  }
}