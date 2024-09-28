namespace LeetCode.__DP._3302._Find_the_Lexicographically_Smallest_Valid_Sequence;

public class Solution
{
  public int[] ValidSequence(string word1, string word2)
  {
    var cache = new HashSet<(int, int, bool)>();
    var seq = new List<int>();
    F(0, 0, true);
    return seq.ToArray();

    bool F(int i, int j, bool canReplace)
    {
      if (j == word2.Length)
        return true;
      if (i == word1.Length)
        return false;
      var key = (i, j, canReplace);
      if (cache.Contains(key))
        return false;

      if (word1[i] == word2[j])
      {
        seq.Add(i);
        if (F(i + 1, j + 1, canReplace))
          return true;
        seq.RemoveAt(seq.Count - 1);
        cache.Add((i, j, canReplace));
        return false;
      }
      if (canReplace)
      {
        seq.Add(i);
        if (F(i + 1, j + 1, false))
          return true;
        seq.RemoveAt(seq.Count - 1);
      }
      if (F(i + 1, j, canReplace))
        return true;
      cache.Add((i, j, canReplace));
      return false;
    }
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("vbcca", "abc", new[] { 0, 1, 2 })]
  [TestCase("bacdc", "abc", new[] { 1, 2, 4 })]
  [TestCase("aaaaaa", "aaabc", new int[0])]
  public void Test(string word1, string word2, int[] expected)
  {
    new Solution().ValidSequence(word1, word2).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
