namespace LeetCode._31._Next_Permutation;

public class Solution
{
  public void NextPermutation(int[] nums)
  {
    var n = nums.Length;
    for (var i = n - 2; i >= 0; i--)
    {
      if (nums[i] >= nums[i + 1])
        continue;
      for (var j = n - 1; j > i; j--)
      {
        if (nums[j] > nums[i])
        {
          (nums[i], nums[j]) = (nums[j], nums[i]);
          nums.AsSpan(i + 1).Reverse();
          return;
        }
      }
    }
    nums.AsSpan().Reverse();
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { 1, 2, 3 }, new[] { 1, 3, 2 })]
  [TestCase(new[] { 3, 2, 1 }, new[] { 1, 2, 3 })]
  [TestCase(new[] { 1, 1, 5 }, new[] { 1, 5, 1 })]
  [TestCase(new[] { 1, 3, 2 }, new[] { 2, 1, 3 })]
  [TestCase(new[] { 2, 3, 1 }, new[] { 3, 1, 2 })]
  public void Test(int[] nums, int[] expected)
  {
    new Solution().NextPermutation(nums);
    nums.Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
