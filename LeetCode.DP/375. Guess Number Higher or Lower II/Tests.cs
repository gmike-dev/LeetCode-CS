namespace LeetCode.DP._375._Guess_Number_Higher_or_Lower_II;

[TestFixture]
public class Tests
{
  [TestCase(10, 16)]
  [TestCase(1, 0)]
  [TestCase(2, 1)]
  [TestCase(200, 952)]
  public void Test(int n, int expected)
  {
    new DpSolution().GetMoneyAmount(n).Should().Be(expected);
    new RecursiveSolution().GetMoneyAmount(n).Should().Be(expected);
  }
}
