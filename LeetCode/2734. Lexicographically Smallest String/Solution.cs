using System;

namespace LeetCode._2734._Lexicographically_Smallest_String;

public class Solution
{
  public string SmallestString(string s)
  {
    var n = s.Length;
    var a = s.ToCharArray();
    var op = false;
    for (var i = 0; i < n; i++)
    {
      if (a[i] != 'a')
      {
        var j = i;
        while (j < n && a[j] != 'a')
          j++;
        Change(a.AsSpan(i, j - i));
        op = true;
        break;
      }
    }
    if (!op)
      a[^1] = 'z';
    return new string(a);
  }

  private static void Change(Span<char> s)
  {
    for (var i = 0; i < s.Length; i++)
      s[i]--;
  }
}