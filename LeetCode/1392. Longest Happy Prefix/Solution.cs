namespace LeetCode._1392._Longest_Happy_Prefix;

public class Solution
{
  public string LongestPrefix(string s)
  {
    var pi = Pi(s);
    return s[..pi[^1]];
  }

  private static int[] Pi(string s)
  {
    var n = s.Length;
    var pi = new int[n];
    for (var i = 1; i < n; i++)
    {
      var j = pi[i - 1];
      while (j != 0 && s[j] != s[i])
        j = pi[j - 1];
      if (s[j] == s[i])
        j++;
      pi[i] = j;
    }
    return pi;
  }
}