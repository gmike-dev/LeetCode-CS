namespace LeetCode.__Strings._440._K_th_Smallest_in_Lexicographical_Order;

public class Solution
{
  public int FindKthNumber(int n, int k)
  {
    var target = 1;
    k--;
    while (k > 0)
    {
      var count = GetCountBetween(n, target, target + 1);
      if (count <= k)
      {
        target++;
        k -= count;
      }
      else
      {
        target *= 10;
        k--;
      }
    }
    return target;
  }

  private int GetCountBetween(int n, long left, long right)
  {
    long count = 0;
    for (; left <= n; left *= 10, right *= 10)
    {
      if (right > n + 1)
        right = n + 1;
      count += right - left;
    }
    return (int)count;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(13, 2, 10)]
  [TestCase(1, 1, 1)]
  [TestCase(250, 1, 1)]
  [TestCase(250, 2, 10)]
  [TestCase(250, 3, 100)]
  [TestCase(250, 4, 101)]
  [TestCase(250, 10, 107)]
  [TestCase(250, 111, 199)]
  [TestCase(250, 112, 2)]
  [TestCase(250, 113, 20)]
  [TestCase(250, 250, 99)]
  public void Test(int n, int k, int expected)
  {
    new Solution().FindKthNumber(n, k).Should().Be(expected);
  }
}
