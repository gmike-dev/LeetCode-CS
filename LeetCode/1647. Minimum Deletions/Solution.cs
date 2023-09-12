using System;

namespace LeetCode._1647._Minimum_Deletions;

public class Solution
{
  public int MinDeletions(string s)
  {
    var freq = new int[26];
    foreach (var c in s)
      freq[c - 'a']++;
    freq.AsSpan().Sort();
    var deletions = 0;
    for (var i = freq.Length - 1; i > 0; i--)
    {
      var target = Math.Max(0, Math.Min(freq[i - 1], freq[i] - 1));
      var d = freq[i - 1] - target;
      deletions += d;
      freq[i - 1] = target;
    }
    return deletions;
  }
}