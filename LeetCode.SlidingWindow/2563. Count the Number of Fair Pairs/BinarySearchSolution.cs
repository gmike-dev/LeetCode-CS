namespace LeetCode.SlidingWindow._2563._Count_the_Number_of_Fair_Pairs;

public class BinarySearchSolution
{
  public long CountFairPairs(int[] nums, int lower, int upper)
  {
    var n = nums.Length;
    nums.AsSpan().Sort();
    var count = 0L;
    for (var i = 0; i < n - 1; i++)
    {
      count += UpperBound(nums, i + 1, n - 1, upper - nums[i]) -
               LowerBound(nums, i + 1, n - 1, lower - nums[i]);
    }
    return count;
  }

  private static int LowerBound(int[] a, int l, int r, int value)
  {
    while (l < r)
    {
      var m = l + (r - l) / 2;
      if (value > a[m])
        l = m + 1;
      else
        r = m;
    }
    return a[l] < value ? r + 1 : l;
  }

  private static int UpperBound(int[] a, int l, int r, int value)
  {
    while (l < r)
    {
      var m = l + (r - l) / 2;
      if (value < a[m])
        r = m;
      else
        l = m + 1;
    }
    return a[l] <= value ? r + 1 : l;
  }
}

[TestFixture]
public class BinarySearchSolutionTests
{
  [TestCase(new[] { 0, 1, 7, 4, 4, 5 }, 3, 6, 6)]
  [TestCase(new[] { 1, 7, 9, 2, 5 }, 11, 11, 1)]
  public void Test(int[] nums, int lower, int upper, long expected)
  {
    new BinarySearchSolution().CountFairPairs(nums, lower, upper).Should().Be(expected);
  }
}
