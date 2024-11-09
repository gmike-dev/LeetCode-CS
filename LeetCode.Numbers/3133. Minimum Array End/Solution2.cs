namespace LeetCode.Numbers._3133._Minimum_Array_End;

public class Solution2
{
  public long MinEnd(int n, int x)
  {
    var m = n - 1;
    long y = x;
    for (var mask = 1L; m != 0; mask <<= 1)
    {
      if ((x & mask) == 0)
      {
        if ((m & 1) != 0)
          y |= mask;
        m >>= 1;
      }
    }
    return y;
  }
}

[TestFixture]
public class Solution2Tests
{
  [TestCase(3, 4, 6)]
  [TestCase(2, 7, 15)]
  public void Test(int n, int x, int expected)
  {
    new Solution2().MinEnd(n, x).Should().Be(expected);
  }
}
