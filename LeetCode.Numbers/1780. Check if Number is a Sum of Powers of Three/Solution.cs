namespace LeetCode.Numbers._1780._Check_if_Number_is_a_Sum_of_Powers_of_Three;

public class Solution
{
  public bool CheckPowersOfThree(int n)
  {
    return n == 0 || n % 3 == 0 && CheckPowersOfThree(n / 3) ||
           n % 3 == 1 && CheckPowersOfThree(n - 1);
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(12, true)]
  [TestCase(91, true)]
  [TestCase(21, false)]
  [TestCase(22, false)]
  [TestCase(1000000, false)]
  public void Test(int n, bool expected)
  {
    new Solution().CheckPowersOfThree(n).Should().Be(expected);
  }
}
