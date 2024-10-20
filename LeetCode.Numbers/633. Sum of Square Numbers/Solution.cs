namespace LeetCode.Numbers._633._Sum_of_Square_Numbers;

public class Solution
{
  public bool JudgeSquareSum(int c)
  {
    var sc = (int)Math.Sqrt(c);
    for (var a = 0; a <= sc; a++)
    {
      var b = (int)Math.Sqrt(c - a * a);
      if (a * a + b * b == c)
        return true;
    }
    return false;
  }
}

[TestFixture]
public class Tests
{
  [TestCase(5, true)]
  [TestCase(3, false)]
  [TestCase(int.MaxValue, false)]
  [TestCase(0, true)]
  public void Test(int c, bool expected)
  {
    for (var i = 0; i < 1000; i++)
    {
      new Solution().JudgeSquareSum(c).Should().Be(expected);
    }
  }
}
