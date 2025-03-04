namespace LeetCode.Numbers._1780._Check_if_Number_is_a_Sum_of_Powers_of_Three;

public class Solution2
{
  public bool CheckPowersOfThree(int n)
  {
    for (; n != 0; n /= 3)
    {
      if (n % 3 == 2)
        return false;
    }
    return true;
  }
}

[TestFixture]
public class Solution2Tests
{
  [TestCase(12, true)]
  [TestCase(91, true)]
  [TestCase(21, false)]
  [TestCase(22, false)]
  [TestCase(1000000, false)]
  public void Test(int n, bool expected)
  {
    new Solution2().CheckPowersOfThree(n).Should().Be(expected);
  }
}
