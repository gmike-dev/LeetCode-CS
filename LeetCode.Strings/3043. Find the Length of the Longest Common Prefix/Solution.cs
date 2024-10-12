namespace LeetCode.Strings._3043._Find_the_Length_of_the_Longest_Common_Prefix;

public class Solution
{
  public int LongestCommonPrefix(int[] arr1, int[] arr2)
  {
    var trie = new TrieNode();
    foreach (var n in arr1)
    {
      var curr = trie;
      foreach (var c in n.ToString())
        curr = curr.Next[c - '0'] ??= new TrieNode();
    }
    var longestPrefix = 0;
    foreach (var n in arr2)
    {
      var prefix = 0;
      var curr = trie;
      foreach (var c in n.ToString())
      {
        curr = curr.Next[c - '0'];
        if (curr == null)
          break;
        prefix++;
      }
      if (prefix > longestPrefix)
        longestPrefix = prefix;
    }
    return longestPrefix;
  }

  private class TrieNode
  {
    public readonly TrieNode[] Next = new TrieNode[10];
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { 1, 10, 100 }, new[] { 1000 }, 3)]
  [TestCase(new[] { 1, 2, 3 }, new[] { 4, 4, 4 }, 0)]
  public void Test(int[] arr1, int[] arr2, int expected)
  {
    new Solution().LongestCommonPrefix(arr1, arr2).Should().Be(expected);
  }
}
