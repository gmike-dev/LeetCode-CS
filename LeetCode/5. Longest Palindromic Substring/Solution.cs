namespace LeetCode._5._Longest_Palindromic_Substring;

public class Solution
{
  public string LongestPalindrome(string s)
  {
    var result = s.AsSpan(0, 1);
    var n = s.Length;
    for (var i = 1; i < n - 1; i++)
    {
      var l = i - 1;
      var r = i + 1;
      while (l >= 0 && r < n && s[l] == s[r])
      {
        l--;
        r++;
      }
      if (result.Length < r - l - 1)
        result = s.AsSpan(l + 1, r - l - 1);
    }
    for (var i = 0; i < n - 1; i++)
    {
      var l = i;
      var r = i + 1;
      while (l >= 0 && r < n && s[l] == s[r])
      {
        l--;
        r++;
      }
      if (result.Length < r - l - 1)
        result = s.AsSpan(l + 1, r - l - 1);
    }
    return result.ToString();
  }
}
