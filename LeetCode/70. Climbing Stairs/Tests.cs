namespace LeetCode._70._Climbing_Stairs;

[TestFixture]
public class Tests
{
  [TestCase(2, 2)]
  [TestCase(3, 3)]
  public void Test1(int n, int expected)
  {
    new Solution().ClimbStairs(n).Should().Be(expected);
  }
}
