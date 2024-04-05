namespace LeetCode._62._Unique_Paths;

[TestFixture]
public class Tests
{
  [TestCase(1, 1, 1)]
  [TestCase(3, 7, 28)]
  [TestCase(3, 2, 3)]
  [TestCase(51, 9, 1916797311)]
  [TestCase(23, 12, 193536720)]
  public void Test(int m, int n, int expected)
  {
    new Solution().UniquePaths(m, n).Should().Be(expected);
    new SolutionUsingDp().UniquePaths(m, n).Should().Be(expected);
  }
}
