namespace LeetCode._3254._Find_the_Power_of_K_Size_Subarrays_I;

public class SlidingWindowSolution
{
  public int[] ResultsArray(int[] nums, int k)
  {
    if (k == 1)
      return nums.ToArray();
    var n = nums.Length;
    var ans = new int[n - k + 1];
    ans.AsSpan().Fill(-1);
    var lastBreakIndex = -1;
    for (var i = 0; i < k - 1; i++)
    {
      if (nums[i] + 1 != nums[i + 1])
        lastBreakIndex = i;
    }
    if (lastBreakIndex == -1)
      ans[0] = nums[k - 1];
    for (var i = k; i < n; i++)
    {
      if (nums[i - 1] + 1 != nums[i])
        lastBreakIndex = i - 1;
      else if (lastBreakIndex == i - k)
        lastBreakIndex = -1;

      if (lastBreakIndex == -1 || lastBreakIndex == i - k)
        ans[i - k + 1] = nums[i];
    }
    return ans;
  }
}

[TestFixture]
public class SlidingWindowSolutionTests
{
  [TestCase(new[] { 1, 2, 3, 4, 3, 2, 5 }, 3, new[] { 3, 4, -1, -1, -1 })]
  [TestCase(new[] { 2, 2, 2, 2, 2 }, 4, new[] { -1, -1 })]
  [TestCase(new[] { 3, 2, 3, 2, 3, 2 }, 2, new[] { -1, 3, -1, 3, -1 })]
  [TestCase(new[] { 1 }, 1, new[] { 1 })]
  [TestCase(new[] { 1, 3, 4 }, 2, new[] { -1, 4 })]
  [TestCase(new[] { 3, 3, 3, 4 }, 1, new[] { 3, 3, 3, 4 })]
  public void Test(int[] nums, int k, int[] expected)
  {
    new SlidingWindowSolution().ResultsArray(nums, k).Should()
      .BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
