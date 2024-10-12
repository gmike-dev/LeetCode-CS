namespace LeetCode.Strings._2416._Sum_of_Prefix_Scores_of_Strings;

public class Solution
{
  public int[] SumPrefixScores(string[] words)
  {
    var trie = new TrieNode();
    foreach (var word in words)
    {
      var t = trie;
      foreach (var c in word)
      {
        t = t.Next[c - 'a'] ??= new TrieNode();
        t.PrefixCount++;
      }
    }
    var result = new int[words.Length];
    for (var i = 0; i < words.Length; i++)
    {
      var t = trie;
      foreach (var c in words[i])
      {
        t = t.Next[c - 'a'];
        if (t is null)
          break;
        result[i] += t.PrefixCount;
      }
    }
    return result;
  }

  private class TrieNode
  {
    public readonly TrieNode[] Next = new TrieNode[26];
    public int PrefixCount;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { "abc", "ab", "bc", "b" }, new[] { 5, 4, 3, 2 })]
  [TestCase(new[] { "abcd" }, new[] { 4 })]
  public void Test(string[] words, int[] expected)
  {
    new Solution().SumPrefixScores(words).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
