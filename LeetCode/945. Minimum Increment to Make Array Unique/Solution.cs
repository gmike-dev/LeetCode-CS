namespace LeetCode._945._Minimum_Increment_to_Make_Array_Unique;

public class Solution
{
  public int MinIncrementForUnique(int[] nums)
  {
    var count = new int[100001];
    foreach (var num in nums)
      count[num]++;
    var moves = 0;
    var extra = 0;
    foreach (var cnt in count)
    {
      moves += extra;
      extra = Math.Max(0, extra + cnt - 1);
    }
    return moves + (extra + 1) * extra / 2;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { 1, 2, 2 }, 1)]
  [TestCase(new[] { 3, 2, 1, 2, 1, 7 }, 6)]
  public void Test(int[] nums, int expected)
  {
    new Solution().MinIncrementForUnique(nums).Should().Be(expected);
  }
}
