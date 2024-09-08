namespace LeetCode._327._Count_of_Range_Sum;

public class Solution
{
  public int CountRangeSum(int[] nums, int lower, int upper)
  {
    var n = nums.Length;
    var s = new long[n];
    s[0] = nums[0];
    for (var i = 1; i < n; i++)
      s[i] = s[i - 1] + nums[i];
    var st = new SegmentTree(s);
    var count = 0;
    long d = 0;
    for (var i = 0; i < n; i++)
    {
      count += st.CountInRange(i, n - 1, lower + d, upper + d);
      d = s[i];
    }
    return count;
  }

  private class SegmentTree
  {
    private readonly int n;
    private readonly long[] min;
    private readonly long[] max;

    public int CountInRange(int l, int r, long lower, long upper)
    {
      return CountInRange(1, 0, n - 1, l, r, lower, upper);
    }

    private int CountInRange(int v, int tl, int tr, int l, int r, long lower, long upper)
    {
      if (l > r)
        return 0;
      if (tl == tr)
        return lower <= min[v] && min[v] <= upper ? 1 : 0;
      if (max[v] < lower || min[v] > upper)
        return 0;
      if (lower <= min[v] && max[v] <= upper)
        return r - l + 1;
      var vl = 2 * v;
      var vr = 2 * v + 1;
      var tm = tl + (tr - tl) / 2;
      return CountInRange(vl, tl, tm, l, Math.Min(tm, r), lower, upper) +
             CountInRange(vr, tm + 1, tr, Math.Max(tm + 1, l), r, lower, upper);
    }

    private void Build(long[] nums, int v, int l, int r)
    {
      if (l == r)
      {
        min[v] = max[v] = nums[l];
      }
      else
      {
        var m = l + (r - l) / 2;
        var vl = 2 * v;
        var vr = 2 * v + 1;
        Build(nums, vl, l, m);
        Build(nums, vr, m + 1, r);
        min[v] = Math.Min(min[vl], min[vr]);
        max[v] = Math.Max(max[vl], max[vr]);
      }
    }

    public SegmentTree(long[] nums)
    {
      n = nums.Length;
      min = new long[4 * n];
      max = new long[4 * n];
      Build(nums, 1, 0, n - 1);
    }
  }
}

[TestFixture]
public class Tests
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
    new Solution().CountRangeSum(nums, lower, upper).Should().Be(expected);
  }

  [Test]
  public void Test_LargeData()
  {
    var random = new Random();
    var nums = Enumerable.Range(0, 100000).Select(i => random.Next(-10000, 10000)).ToArray();
    new Solution().CountRangeSum(nums, -10000, 10000);
    // new Solution().ExecutionTimeOf(s => s.CountRangeSum(nums, -10000, 10000))
    //   .Should().BeLessThan(TimeSpan.FromSeconds(2));
  }
}
