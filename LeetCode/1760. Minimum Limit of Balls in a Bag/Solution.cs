namespace LeetCode._1760._Minimum_Limit_of_Balls_in_a_Bag;

public class Solution
{
  public int MinimumSize(int[] nums, int maxOperations)
  {
    var l = 1;
    var r = nums.Max();
    while (l < r)
    {
      var m = l + (r - l) / 2;
      if (nums.Sum(x => (x + m - 1) / m - 1) <= maxOperations)
        r = m;
      else
        l = m + 1;
    }
    return r;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { 9 }, 2, 3)]
  [TestCase(new[] { 2, 4, 8, 2 }, 4, 2)]
  public void Test(int[] nums, int maxOperations, int expected)
  {
    new Solution().MinimumSize(nums, maxOperations).Should().Be(expected);
  }
}
