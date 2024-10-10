namespace LeetCode._962._Maximum_Width_Ramp;

public class Solution
{
  public int MaxWidthRamp(int[] nums)
  {
    var lastIndexOf = new int[50001];
    for (var i = 0; i < nums.Length; i++)
      lastIndexOf[nums[i]] = i;

    for (var i = lastIndexOf.Length - 2; i >= 0; i--)
      lastIndexOf[i] = Math.Max(lastIndexOf[i], lastIndexOf[i + 1]);

    var maxWidth = 0;
    for (var i = 0; i + maxWidth < nums.Length; i++)
    {
      if (lastIndexOf[nums[i]] > i)
        maxWidth = Math.Max(maxWidth, lastIndexOf[nums[i]] - i);
    }
    return maxWidth;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { 6, 0, 8, 2, 1, 5 }, 4)]
  [TestCase(new[] { 9, 8, 1, 0, 1, 9, 4, 0, 4, 1 }, 7)]
  public void Test(int[] nums, int expected)
  {
    new Solution().MaxWidthRamp(nums).Should().Be(expected);
  }

  [Test]
  public void LargeInput()
  {
    new Solution().MaxWidthRamp(Enumerable.Range(0, 50000).ToArray()).Should().Be(49999);
  }
}
