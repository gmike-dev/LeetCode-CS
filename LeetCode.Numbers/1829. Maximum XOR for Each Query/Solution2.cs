namespace LeetCode.Numbers._1829._Maximum_XOR_for_Each_Query;

public class Solution2
{
  public int[] GetMaximumXor(int[] nums, int maximumBit)
  {
    var n = nums.Length;
    var m = (1 << maximumBit) - 1;
    var px = 0;
    for (var i = 0; i < n; i++)
      px ^= nums[i];
    var q = new int[n];
    for (var i = 0; i < n; i++)
    {
      q[i] = m & ~px;
      px ^= nums[n - i - 1];
    }
    return q;
  }
}

[TestFixture]
public class Solution2Tests
{
  [TestCase(new[] { 0, 1, 1, 3 }, 2, new[] { 0, 3, 2, 3 })]
  [TestCase(new[] { 2, 3, 4, 7 }, 3, new[] { 5, 2, 6, 5 })]
  [TestCase(new[] { 0, 1, 2, 2, 5, 7 }, 3, new[] { 4, 3, 6, 4, 6, 7 })]
  public void Test(int[] nums, int maximumBit, int[] expected)
  {
    new Solution2().GetMaximumXor(nums, maximumBit)
      .Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
