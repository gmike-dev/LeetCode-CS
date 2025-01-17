namespace LeetCode.Numbers._2683._Neighboring_Bitwise_XOR;

public class SumSolution
{
  public bool DoesValidArrayExist(int[] derived)
  {
    return derived.Sum() % 2 == 0;
  }
}

[TestFixture]
public class SumSolutionTests
{
  [TestCase(new[] { 1, 1, 0 }, true)]
  [TestCase(new[] { 1, 1 }, true)]
  [TestCase(new[] { 1, 0 }, false)]
  public void Test(int[] derived, bool expected)
  {
    new SumSolution().DoesValidArrayExist(derived).Should().Be(expected);
  }
}
