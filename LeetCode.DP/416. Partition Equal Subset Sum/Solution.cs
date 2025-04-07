namespace LeetCode.DP._416._Partition_Equal_Subset_Sum;

public class Solution
{
  public bool CanPartition(int[] nums)
  {
    var totalSum = 0;
    foreach (var num in nums)
      totalSum += num;
    if (totalSum % 2 != 0)
      return false;
    var targetSum = totalSum / 2;
    Span<bool> canSum = stackalloc bool[targetSum + 1];
    canSum[0] = true;
    foreach (var num in nums)
    {
      for (var s = targetSum - num; s >= 0; s--)
        canSum[s + num] |= canSum[s];
    }
    return canSum[targetSum];
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { 1, 5, 11, 5 }, true)]
  [TestCase(new[] { 1, 2, 3, 5 }, false)]
  [TestCase(new[] { 3, 3, 3, 4, 5 }, true)]
  [TestCase(new[] { 2, 2, 3, 5 }, false)]
  [TestCase(new[] { 20, 9, 10, 18, 14, 4, 15, 19, 19 }, true)]
  [TestCase(
    new[]
    {
      100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100,
      100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100,
      100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100,
      100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100,
      100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100,
      100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100,
      100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100,
      100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100,
      100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 99, 97
    }, false)]
  public void Test(int[] nums, bool expected)
  {
    new Solution().CanPartition(nums).Should().Be(expected);
  }
}
