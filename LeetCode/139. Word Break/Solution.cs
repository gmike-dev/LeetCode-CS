using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode._139._Word_Break;

public class Solution 
{
  public bool WordBreak(string s, IList<string> wordDict)
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