namespace LeetCode._1291._Sequential_Digits;

[TestFixture]
public class Tests
{
  [TestCase(100, 300, new[] { 123, 234 })]
  [TestCase(1000, 13000, new[] { 1234, 2345, 3456, 4567, 5678, 6789, 12345 })]
  [TestCase((int)1e7, (int)1e9, new[] { 12345678, 23456789, 123456789 })]
  public void Test(int low, int high, int[] expected)
  {
    new Solution().SequentialDigits(low, high).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
    new QueueSolution().SequentialDigits(low, high).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
