namespace LeetCode.Numbers._2698._Find_the_Punishment_Number_of_an_Integer;

public class Solution
{
  public int PunishmentNumber(int n)
  {
    var s = 0;
    for (var i = 1; i <= n; i++)
    {
      if (CanPartition(i * i, i))
        s += i * i;
    }
    return s;
  }

  private static bool CanPartition(int n, int target)
  {
    if (target < 0 || n < target)
      return false;
    if (target == n)
      return true;
    for (var k = 10; n / k != 0; k *= 10)
    {
      if (CanPartition(n / k, target - n % k))
        return true;
    }
    return false;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(10, 182)]
  [TestCase(37, 1478)]
  [TestCase(1000, 10804657)]
  public void Test(int n, int expected)
  {
    new Solution().PunishmentNumber(n).Should().Be(expected);
  }
}
