using System;

namespace LeetCode.__Strings._2707._Extra_Characters_in_a_String;

public class RecursiveSolution
{
  private string[] dict;
  private int[] cache;

  public int MinExtraChar(string s, string[] dictionary)
  {
    dict = dictionary;
    cache = new int[s.Length + 1];
    cache.AsSpan().Fill(-1);
    return MinExtraChar(s);
  }

  private int MinExtraChar(ReadOnlySpan<char> s)
  {
    if (s.Length == 0)
      return 0;

    if (cache[s.Length] != -1)
      return cache[s.Length];

    var result = s.Length;
    foreach (var word in dict)
    {
      if (s.StartsWith(word))
        result = Math.Min(result, MinExtraChar(s[word.Length..]));
      else
        result = Math.Min(result, 1 + MinExtraChar(s[1..]));
    }

    cache[s.Length] = result;
    return result;
  }
}
