namespace LeetCode.Numbers._371._Sum_of_Two_Integers;

public class Solution
{
  public int GetSum(int a, int b)
  {
    while (b != 0)
    {
      int carry = a & b;
      a ^= b;
      b = carry << 1;
    }
    return a;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(1, 2, 3)]
  [TestCase(2, 3, 5)]
  [TestCase(-1, 3, 2)]
  [TestCase(1, -3, -2)]
  [TestCase(-224, -371, -595)]
  public void Test(int a, int b, int expected)
  {
    new Solution().GetSum(a, b).Should().Be(expected);
  }
}
