using System;

namespace LeetCode._2707._Extra_Characters_in_a_String;

public class Solution
{
  private string[] _dictionary;
  private int[] _cache;
  
  public int MinExtraChar(string s, string[] dictionary)
  {
    _dictionary = dictionary;
    _cache = new int[s.Length + 1];
    _cache.AsSpan().Fill(-1);
    return MinExtraChar(s);
  }

  private int MinExtraChar(ReadOnlySpan<char> s)
  {
    if (s.Length == 0)
      return 0;

    if (_cache[s.Length] != -1)
      return _cache[s.Length];
    
    var result = s.Length;
    foreach (var word in _dictionary)
    {
      if (s.StartsWith(word))
        result = Math.Min(result, MinExtraChar(s[word.Length..]));
      else
        result = Math.Min(result, 1 + MinExtraChar(s[1..]));
    }

    _cache[s.Length] = result;
    return result;
  }
}