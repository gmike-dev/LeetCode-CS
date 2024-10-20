namespace LeetCode.DP._1155._Number_of_Dice_Rolls_With_Target_Sum;

[TestFixture]
public class Tests
{
  [TestCase(1, 6, 3, 1)]
  [TestCase(2, 6, 7, 6)]
  [TestCase(30, 30, 500, 222616187)]
  [TestCase(2, 12, 8, 7)]
  public void Test(int n, int k, int target, int expected)
  {
    new SolutionUsingRecursion().NumRollsToTarget(n, k, target).Should().Be(expected);
    new SolutionUsingDp().NumRollsToTarget(n, k, target).Should().Be(expected);
    new SolutionUsingOptimizedDp().NumRollsToTarget(n, k, target).Should().Be(expected);
  }
}
