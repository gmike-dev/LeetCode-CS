namespace LeetCode._459._Repeated_Substring_Pattern;

public class Solution
{
  public bool RepeatedSubstringPattern(string s)
  {
    var n = s.Length;
    for (var len = 1; len <= n / 2; len++)
      if (IsRepeatedSubstring(s, len))
        return true;
    return false;
  }

  private static bool IsRepeatedSubstring(string s, int len)
  {
    if (s.Length % len != 0)
      return false;
    for (var i = 0; i < len; i++)
    for (var j = i + len; j < s.Length; j += len)
      if (s[i] != s[j])
        return false;
    return true;
  }
}