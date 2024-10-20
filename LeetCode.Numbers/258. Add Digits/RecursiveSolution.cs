namespace LeetCode.Numbers._258._Add_Digits;

public class RecursiveSolution
{
  public int AddDigits(int num)
  {
    return num < 10 ? num : AddDigits(num.ToString().Sum(c => c - '0'));
  }
}

[TestFixture]
public class RecursiveSolutionTests
{
  [TestCase(38, 2)]
  [TestCase(0, 0)]
  [TestCase(9999, 9)]
  [TestCase(3333, 3)]
  [TestCase(179, 8)]
  public void Test(int num, int expected)
  {
    new RecursiveSolution().AddDigits(num).Should().Be(expected);
  }
}
