using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.__Strings._290._Word_Pattern;

public class TrieSolution
{
  public bool WordPattern(string pattern, string s)
  {
    var t = new TrieNode();
    var used = new TrieNode[26];
    var node = t;
    var j = 0;
    for (var i = 0; i <= s.Length; i++)
    {
      if (j >= pattern.Length)
        return false;

      if (i == s.Length || s[i] == ' ')
      {
        if (node.Value != '\0')
        {
          if (node.Value != pattern[j])
            return false;
        }
        else
        {
          if (used[pattern[j] - 'a'] != null)
            return false;
          node.Value = pattern[j];
          used[pattern[j] - 'a'] = node;
        }
        j++;
        node = t;
      }
      else
      {
        node = node.Next[s[i] - 'a'] ??= new TrieNode();
      }
    }
    return j == pattern.Length;
  }

  private class TrieNode
  {
    public readonly TrieNode[] Next = new TrieNode[26];
    public char Value;

    public TrieNode(char value = '\0')
    {
      Value = value;
    }
  }
}

[TestFixture]
public class TrieSolutionTests
{
  [TestCase("abba", "dog cat cat dog", true)]
  [TestCase("abba", "dog cat cat fish", false)]
  [TestCase("aaaa", "dog cat cat dog", false)]
  [TestCase("abba", "dog cat cat", false)]
  [TestCase("abb", "dog cat cat", true)]
  [TestCase("abba", "dog dog dog dog", false)]
  public void Test(string pattern, string s, bool expected)
  {
    new TrieSolution().WordPattern(pattern, s).Should().Be(expected);
  }
}
