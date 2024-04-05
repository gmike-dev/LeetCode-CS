namespace LeetCode._1647._Minimum_Deletions;

[TestFixture]
public class Tests
{
  [TestCase("aab", 0)]
  [TestCase("aaabbbcc", 2)]
  [TestCase("ceabaacb", 2)]
  [TestCase("z", 0)]
  [TestCase("zzz", 0)]
  public void Test(string s, int expected)
  {
    new Solution().MinDeletions(s).Should().Be(expected);
  }
}
