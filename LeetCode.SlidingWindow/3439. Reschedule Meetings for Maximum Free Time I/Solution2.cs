namespace LeetCode.SlidingWindow._3439._Reschedule_Meetings_for_Maximum_Free_Time_I;

public class Solution2
{
  public int MaxFreeTime(int eventTime, int k, int[] startTime, int[] endTime)
  {
    var n = startTime.Length;
    var m = n + 1;
    Span<int> gaps = stackalloc int[m];
    gaps[0] = startTime[0];
    for (var i = 1; i < n; i++)
      gaps[i] = startTime[i] - endTime[i - 1];
    gaps[m - 1] = eventTime - endTime[n - 1];

    Span<long> prefixSum = stackalloc long[m + 1];
    for (var i = 0; i < m; i++)
      prefixSum[i + 1] = prefixSum[i] + gaps[i];

    long maxFreeTime = 0;
    for (var i = k + 1; i <= m; i++)
      maxFreeTime = Math.Max(maxFreeTime, prefixSum[i] - prefixSum[i - k - 1]);
    return (int)maxFreeTime;
  }
}

[TestFixture]
public class Solution2Tests
{
  [TestCase(5, 1, new[] { 1, 3 }, new[] { 2, 5 }, 2)]
  [TestCase(10, 1, new[] { 0, 2, 9 }, new[] { 1, 4, 10 }, 6)]
  [TestCase(5, 2, new[] { 0, 1, 2, 3, 4 }, new[] { 1, 2, 3, 4, 5 }, 0)]
  public void Test(int eventTime, int k, int[] startTime, int[] endTime, int expected)
  {
    new Solution2().MaxFreeTime(eventTime, k, startTime, endTime).Should().Be(expected);
  }
}
