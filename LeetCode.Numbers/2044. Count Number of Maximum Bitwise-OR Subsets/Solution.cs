namespace LeetCode.Numbers._2044._Count_Number_of_Maximum_Bitwise_OR_Subsets;

public class Solution
{
  public int CountMaxOrSubsets(int[] nums)
  {
    var max = 0;
    var n = nums.Length;
    var count = n;
    for (var mask = 1; mask < 1 << n; mask++)
    {
      var or = 0;
      var m = mask;
      for (var i = n - 1; m != 0; i--)
      {
        if ((m & 1) != 0)
          or |= nums[i];
        m >>= 1;
      }
      if (or > max)
      {
        max = or;
        count = 1;
      }
      else if (or == max)
      {
        count++;
      }
    }
    return count;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { 3, 1 }, 2)]
  [TestCase(new[] { 2, 2, 2 }, 7)]
  [TestCase(new[] { 3, 2, 1, 5 }, 6)]
  public void Test(int[] nums, int expected)
  {
    new Solution().CountMaxOrSubsets(nums).Should().Be(expected);
  }
}
