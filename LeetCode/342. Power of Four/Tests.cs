namespace LeetCode._342._Power_of_Four;

[TestFixture]
public class Tests
{
  [TestCase(16, true)]
  [TestCase(8, false)]
  [TestCase(5, false)]
  [TestCase(1, true)]
  [TestCase(0, false)]
  [TestCase(-1, false)]
  [TestCase(-15, false)]
  [TestCase(-16, false)]
  public void Test(int n, bool expected)
  {
    new BitmaskSolution().IsPowerOfFour(n).Should().Be(expected);
    new BitmaskSolution2().IsPowerOfFour(n).Should().Be(expected);
  }
}
