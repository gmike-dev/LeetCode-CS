namespace LeetCode.Numbers._3133._Minimum_Array_End;

public class Solution
{
  public long MinEnd(int n, int x)
  {
    var m = n - 1;
    long y = 0;
    for (var i = 0; (x | m) != 0; i++, x >>= 1)
    {
      if ((x & 1) == 0)
      {
        y |= (m & 1L) << i;
        m >>= 1;
      }
      else
      {
        y |= 1L << i;
      }
    }
    return y;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(3, 4, 6)]
  [TestCase(2, 7, 15)]
  public void Test(int n, int x, int expected)
  {
    new Solution().MinEnd(n, x).Should().Be(expected);
  }
}
