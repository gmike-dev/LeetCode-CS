namespace LeetCode.Numbers._1829._Maximum_XOR_for_Each_Query;

public class Solution
{
  public int[] GetMaximumXor(int[] nums, int maximumBit)
  {
    var n = nums.Length;
    var px = new int[n + 1];
    for (var i = 0; i < n; i++)
      px[i + 1] = px[i] ^ nums[i];
    var q = new int[n];
    for (var i = 0; i < n; i++)
      q[i] = ((1 << maximumBit) - 1) & ~px[n - i];
    return q;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { 0, 1, 1, 3 }, 2, new[] { 0, 3, 2, 3 })]
  [TestCase(new[] { 2, 3, 4, 7 }, 3, new[] { 5, 2, 6, 5 })]
  [TestCase(new[] { 0, 1, 2, 2, 5, 7 }, 3, new[] { 4, 3, 6, 4, 6, 7 })]
  public void Test(int[] nums, int maximumBit, int[] expected)
  {
    new Solution().GetMaximumXor(nums, maximumBit)
      .Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
