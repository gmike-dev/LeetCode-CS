namespace LeetCode.Numbers._2683._Neighboring_Bitwise_XOR;

public class XorSolution
{
  public bool DoesValidArrayExist(int[] derived)
  {
    var x = 0;
    foreach (var d in derived)
      x ^= d;
    return x == 0;
  }
}

[TestFixture]
public class XorSolutionTests
{
  [TestCase(new[] { 1, 1, 0 }, true)]
  [TestCase(new[] { 1, 1 }, true)]
  [TestCase(new[] { 1, 0 }, false)]
  public void Test(int[] derived, bool expected)
  {
    new XorSolution().DoesValidArrayExist(derived).Should().Be(expected);
  }
}
