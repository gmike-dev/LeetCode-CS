namespace LeetCode._454._4Sum_II;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().FourSumCount(new[] { 1, 2 }, new[] { -2, -1 }, new[] { -1, 2 }, new[] { 0, 2 }).Should().Be(2);
    new Solution().FourSumCount(new[] { 0 }, new[] { 0 }, new[] { 0 }, new[] { 0 }).Should().Be(1);
  }
}
