using System.Collections.Generic;

namespace LeetCode._316._Remove_Duplicate_Letters;

public class Solution
{
  public string RemoveDuplicateLetters(string s)
  {
    var cnt = new int[26];
    foreach (var c in s)
      cnt[c - 'a']++;
    var result = new List<char>();
    foreach (var c in s)
    {
      if (!result.Contains(c))
      {
        while (result.Count > 0 && result[^1] > c && cnt[result[^1] - 'a'] != 0)
          result.RemoveAt(result.Count - 1);
        result.Add(c);
      }
      cnt[c - 'a']--;
    }
    return new string(result.ToArray());
  }
}