using LeetCode.Common;

namespace LeetCode._462._Minimum_Moves_to_Equal_Array_Elements_II;

/// <summary>
/// https://leetcode.com/problems/minimum-moves-to-equal-array-elements-ii/
/// </summary>
public class Solution
{
  public int MinMoves2(int[] nums)
  {
    Array.Sort(nums);
    int median = nums[nums.Length / 2];
    int ans = 0;
    foreach (int x in nums)
    {
      ans += Math.Abs(x - median);
    }
    return ans;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("[1,2,3]", 2)]
  [TestCase("[1,10,2,9]", 16)]
  public void Test(string nums, int expected)
  {
    new Solution().MinMoves2(nums.Array()).Should().Be(expected);
  }
}
