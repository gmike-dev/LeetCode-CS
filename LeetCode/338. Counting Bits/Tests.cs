namespace LeetCode._338._Counting_Bits;

[TestFixture]
public class Tests
{
  [TestCase(2, new[] { 0, 1, 1 })]
  [TestCase(5, new[] { 0, 1, 1, 2, 1, 2 })]
  [TestCase(1, new[] { 0, 1 })]
  [TestCase(0, new[] { 0 })]
  public void Test(int n, int[] expected)
  {
    new Solution().CountBits(n).Should().BeEquivalentTo(expected,
      o => o.WithStrictOrdering());
  }
}
