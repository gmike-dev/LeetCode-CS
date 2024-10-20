namespace LeetCode.DP._63._Unique_Paths_II;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().UniquePathsWithObstacles(
      new[]
      {
        new[] { 0, 0, 0 },
        new[] { 0, 1, 0 },
        new[] { 0, 0, 0 }
      }).Should().Be(2);
    new SolutionClassicDp().UniquePathsWithObstacles(
      new[]
      {
        new[] { 0, 0, 0 },
        new[] { 0, 1, 0 },
        new[] { 0, 0, 0 }
      }).Should().Be(2);
  }

  [Test]
  public void Test2()
  {
    new Solution().UniquePathsWithObstacles(
      new[]
      {
        new[] { 0, 1 },
        new[] { 0, 0 }
      }).Should().Be(1);
    new SolutionClassicDp().UniquePathsWithObstacles(
      new[]
      {
        new[] { 0, 1 },
        new[] { 0, 0 }
      }).Should().Be(1);
  }

  [Test]
  public void Test3()
  {
    new Solution().UniquePathsWithObstacles(
      new[]
      {
        new[] { 1 },
        new[] { 0 }
      }).Should().Be(0);
    new SolutionClassicDp().UniquePathsWithObstacles(
      new[]
      {
        new[] { 1 },
        new[] { 0 }
      }).Should().Be(0);
  }
}
