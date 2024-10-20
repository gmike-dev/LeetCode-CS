namespace LeetCode.Numbers._258._Add_Digits;

public class ConstantSolution
{
  public int AddDigits(int num)
  {
    return DigitalRoot(num);
  }

  private static int DigitalRoot(int n)
  {
    if (n == 0)
      return 0;
    if (n % 9 == 0)
      return 9;
    return n % 9;
  }
}

[TestFixture]
public class ConstantSolutionTests
{
  [TestCase(38, 2)]
  [TestCase(0, 0)]
  [TestCase(9999, 9)]
  [TestCase(3333, 3)]
  [TestCase(179, 8)]
  public void Test(int num, int expected)
  {
    new ConstantSolution().AddDigits(num).Should().Be(expected);
  }
}
