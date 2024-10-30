namespace LeetCode.DP._1671._Minimum_Number_of_Removals_to_Make_Mountain_Array;

public class Solution
{
  public int MinimumMountainRemovals(int[] nums)
  {
    var n = nums.Length;

    var lis = new int[n];
    lis.AsSpan().Fill(1);
    for (var i = 1; i < n; i++)
    {
      for (var j = 0; j < i; j++)
      {
        if (nums[j] < nums[i])
          lis[i] = Math.Max(lis[i], lis[j] + 1);
      }
    }

    var lds = new int[n];
    lds.AsSpan().Fill(1);
    for (var i = n - 2; i >= 0; i--)
    {
      for (var j = i + 1; j < n; j++)
      {
        if (nums[i] > nums[j])
          lds[i] = Math.Max(lds[i], lds[j] + 1);
      }
    }

    var minRemovals = n;
    for (var i = 1; i < n - 1; i++)
    {
      if (lis[i] > 1 && lds[i] > 1)
        minRemovals = Math.Min(minRemovals, n - lis[i] - lds[i] + 1);
    }
    return minRemovals;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { 1, 3, 1 }, 0)]
  [TestCase(new[] { 2, 1, 1, 5, 6, 2, 3, 1 }, 3)]
  [TestCase(new[] { 100, 92, 89, 77, 74, 66, 64, 66, 64 }, 6)]
  public void Test(int[] nums, int expected)
  {
    new Solution().MinimumMountainRemovals(nums).Should().Be(expected);
  }
}
