using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode._139._Word_Break;

public class Solution 
{
  public bool WordBreak(string s, IList<string> wordDict)
  {
    var dp = new bool[s.Length + 1];
    foreach (var word in wordDict)
      if (s.StartsWith(word))
        dp[word.Length] = true;
    for (var i = 1; i < s.Length; i++)
    {
      if (dp[i])
      {
        foreach (var word in wordDict)
          if (s.AsSpan(i).StartsWith(word))
            dp[i + word.Length] = true;
      }
    }
    return dp[^1];
  }
  
  public bool WordBreak_Recursion(string s, IList<string> wordDict)
  {
    return new WordsChecker(wordDict).CanBuild(s);
  }

  private class WordsChecker
  {
    private readonly IList<string> _wordDict;

    public bool CanBuild(string s)
    {
      return CanBuild(s, 0, new bool?[s.Length]);
    }
    
    private bool CanBuild(string s, int start, bool?[] dp)
    {
      if (start >= s.Length)
        return true;
      return dp[start] ??= _wordDict.Any(word => s.AsSpan(start).StartsWith(word) && CanBuild(s, start + word.Length, dp));
    }

    public WordsChecker(IList<string> wordDict)
    {
      _wordDict = wordDict;
    }
  }
}