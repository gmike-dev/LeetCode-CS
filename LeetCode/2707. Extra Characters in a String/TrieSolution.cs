using System;

namespace LeetCode._2707._Extra_Characters_in_a_String;

public class TrieSolution
{
  private class TrieNode
  {
    public readonly TrieNode[] Next = new TrieNode[26];
    public bool EndOfWord;
  }
  
  private static TrieNode BuildTrie(string[] dictionary)
  {
    var root = new TrieNode();
    foreach (var word in dictionary)
      AddToTrie(root, word);
    return root;
  }

  private static void AddToTrie(TrieNode root, string value)
  {
    for (var i = value.Length - 1; i >= 0; i--)
      root = root.Next[value[i] - 'a'] ??= new TrieNode();
    root.EndOfWord = true;
  }
  
  public int MinExtraChar(string s, string[] dictionary)
  {
    var trie = BuildTrie(dictionary);
    var dp = new int[s.Length + 1];
    for (var i = 1; i <= s.Length; i++)
    {
      dp[i] = dp[i - 1] + 1;
      var node = trie;
      for (var j = i - 1; j >= 0; j--)
      {
        node = node.Next[s[j] - 'a'];
        if (node == null)
          break;
        if (node.EndOfWord)
          dp[i] = Math.Min(dp[i], dp[j]);
      }
    }
    return dp[^1];
  }
}