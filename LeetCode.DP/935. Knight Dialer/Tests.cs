namespace LeetCode.DP._935._Knight_Dialer;

[TestFixture]
public class Tests
{
  [TestCase(1, 10)]
  [TestCase(2, 20)]
  [TestCase(3131, 136006598)]
  public void Test(int n, int expected)
  {
    new Solution().KnightDialer(n).Should().Be(expected);
    new SolutionUsingRecursion().KnightDialer(n).Should().Be(expected);
    new BetterDpSolution().KnightDialer(n).Should().Be(expected);
  }
}
