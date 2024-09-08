namespace LeetCode._327._Count_of_Range_Sum;

public class BinarySearchListSolution
{
  public int CountRangeSum(int[] nums, int lower, int upper)
  {
    var n = nums.Length;
    var s = new long[n];
    s[0] = nums[0];
    for (var i = 1; i < n; i++)
      s[i] = s[i - 1] + nums[i];
    var sorted = new List<long>(s);
    sorted.Sort();
    var count = 0;
    long d = 0;
    for (var i = 0; i < n; i++)
    {
      var low = LowerBound(sorted, 0, sorted.Count, lower + d);
      var high = LowerBound(sorted, low, sorted.Count, upper + d + 1);
      count += high - low;
      sorted.RemoveAt(sorted.BinarySearch(s[i]));
      d = s[i];
    }
    return count;
  }

  private static int LowerBound(List<long> a, int beginIndex, int endIndex, long value)
  {
    if (beginIndex >= endIndex)
      return endIndex;
    var l = beginIndex;
    var r = endIndex - 1;
    while (l < r)
    {
      var m = l + (r - l) / 2;
      if (a[m] < value)
        l = m + 1;
      else
        r = m;
    }
    return a[l] < value ? endIndex : l;
  }
}

[TestFixture]
public class BinarySearchListSolutionTests
{
  [TestCase(new[] { -2, 5, -1 }, -2, 2, 3)]
  [TestCase(new[] { 0 }, 0, 0, 1)]
  [TestCase(new[] { 2147483647, -2147483648, -1, 0 }, -1, 0, 4)]
  [TestCase(new[] { 10, -10, -1, 0 }, -1, 0, 6)]
  [TestCase(new[] { 10, -11, -1, 0 }, -1, 0, 4)]
  [TestCase(new[] { -2, 0, -2, -3, 2, 2, 1, -3, 4 }, 4, 11, 5)]
  [TestCase(new[] { 0, 0, -3, 2, -2, -2 }, -3, 1, 16)]
  public void Test(int[] nums, int lower, int upper, int expected)
  {
    new BinarySearchListSolution().CountRangeSum(nums, lower, upper).Should().Be(expected);
  }

  [Test]
  public void Test_LargeData()
  {
    var random = new Random();
    var nums = Enumerable.Range(0, 100000).Select(i => random.Next(-10000, 10000)).ToArray();
    new BinarySearchListSolution().ExecutionTimeOf(s => s.CountRangeSum(nums, -10000, 10000))
      .Should().BeLessThan(TimeSpan.FromSeconds(2));
  }
}
