using System.Collections.Generic;

namespace LeetCode._2352._Equal_Row_and_Column_Pairs;

public class TrieSolution
{
  public int EqualPairs(int[][] grid)
  {
    var trie = new TrieNode();
    foreach (var row in grid)
      trie.Add(row);
    var answer = 0;
    for (var col = 0; col < grid.Length; col++)
    {
      var next = trie;
      foreach (var row in grid)
      {
        next = next.Find(row[col]);
        if (next is null)
          break;
      }
      if (next != null)
        answer += next.MatchCount;
    }
    return answer;
  }

  private class TrieNode
  {
    private Dictionary<int, TrieNode> _child;
    
    public int MatchCount { get; private set; }

    public TrieNode Find(int value) => _child?.TryGetValue(value, out var next) == true ? next : null;
    
    public void Add(int[] values)
    {
      var node = this;
      foreach (var value in values)
        node = node.Add(value);
      node.MatchCount++;
    }
    
    private TrieNode Add(int value)
    {
      if (_child == null)
        _child = new Dictionary<int, TrieNode>();
      if (_child.TryGetValue(value, out var next))
        return next;
      next = new TrieNode();
      _child[value] = next;
      return next;
    }
  }
}