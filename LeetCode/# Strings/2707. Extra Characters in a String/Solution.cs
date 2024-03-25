using System;

namespace LeetCode.__Strings._2707._Extra_Characters_in_a_String;

public class Solution
{
  public int MinExtraChar(string s, string[] dictionary)
  {
    var dp = new int[s.Length + 1];
    for (var i = 1; i <= s.Length; i++)
    {
      dp[i] = dp[i - 1] + 1;
      var prefix = s.AsSpan(0, i);
      foreach (var word in dictionary)
      {
        if (prefix.EndsWith(word))
          dp[i] = Math.Min(dp[i], dp[i - word.Length]);
      }
    }
    return dp[^1];
  }
}
