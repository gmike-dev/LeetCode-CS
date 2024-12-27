namespace LeetCode.DP._1531._String_Compression_II;

[TestFixture]
public class Tests
{
  [TestCase("aaabcccd", 2, 4)]
  [TestCase("aabbaa", 2, 2)]
  [TestCase("aaaaaaaaaaa", 0, 3)]
  [TestCase("aabaabbcbbbaccc", 6, 4)]
  [TestCase("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz", 10, 68)]
  [TestCase("aabbccaabbccaabbccaabbccaabbccaabbccaabbccaabbccaabbccaabbccaabbccaabbcc", 9, 59)]
  [TestCase("a", 1, 0)]
  public void Test(string s, int k, int expected)
  {
    new Solution().GetLengthOfOptimalCompression(s, k).Should().Be(expected);
  }
}
