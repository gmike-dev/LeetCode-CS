namespace LeetCode._42._Trapping_Rain_Water;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }, 6)]
  [TestCase(new[] { 4, 2, 0, 3, 2, 5 }, 9)]
  [TestCase(new[] { 0, 1 }, 0)]
  [TestCase(new[] { 1, 1 }, 0)]
  [TestCase(new[] { 1, 0 }, 0)]
  [TestCase(new[] { 1 }, 0)]
  public void Test(int[] height, int expected)
  {
    new Solution().Trap(height).Should().Be(expected);
    new SpaceOptimizedSolution().Trap(height).Should().Be(expected);
  }
}
