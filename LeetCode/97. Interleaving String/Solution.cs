using System;
using System.Collections.Generic;

namespace LeetCode._97._Interleaving_String;

public class Solution
{
  private readonly HashSet<(int, int, bool)> _cache = new();
  
  public bool IsInterleave(string s1, string s2, string s3)
  {
    return IsInterleave(s1.AsSpan(), s2.AsSpan(), s3.AsSpan(), true) ||
           IsInterleave(s2.AsSpan(), s1.AsSpan(), s3.AsSpan(), false);
  }

  private bool IsInterleave(ReadOnlySpan<char> s1, ReadOnlySpan<char> s2, ReadOnlySpan<char> s3, bool first)
  {
    var key = (s1.Length, s2.Length, first);
    if (_cache.Contains(key))
      return false;

    if (s1.Length + s2.Length == s3.Length)
    {
      if (s2.IsEmpty)
      {
        if (s1.SequenceEqual(s3))
          return true;
      }
      else
      {
        for (var i = 0; i < Math.Min(s1.Length, s3.Length) && s1[i] == s3[i]; i++)
          if (IsInterleave(s2, s1.Slice(i + 1), s3.Slice(i + 1), !first))
            return true;
      }
    }
    _cache.Add(key);
    return false;
  }
}