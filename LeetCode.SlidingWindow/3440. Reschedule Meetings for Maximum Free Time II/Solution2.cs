namespace LeetCode.SlidingWindow._3440._Reschedule_Meetings_for_Maximum_Free_Time_II;

public class Solution2
{
  public int MaxFreeTime(int eventTime, int[] startTime, int[] endTime)
  {
    var n = startTime.Length;
    var m = n + 1;
    Span<int> gaps = stackalloc int[m];
    gaps[0] = startTime[0];
    for (var i = 1; i < n; i++)
      gaps[i] = startTime[i] - endTime[i - 1];
    gaps[m - 1] = eventTime - endTime[n - 1];

    var maxLeftGap = 0;
    Span<int> maxRightGap = stackalloc int[m];
    for (var i = m - 1; i > 0; i--)
      maxRightGap[i - 1] = Math.Max(maxRightGap[i], gaps[i]);

    var maxFreeTime = 0;
    for (var i = 0; i < n; i++)
    {
      var freeTime = gaps[i] + gaps[i + 1];
      var eventDuration = endTime[i] - startTime[i];
      if (maxLeftGap >= eventDuration || maxRightGap[i + 1] >= eventDuration)
        freeTime += eventDuration;
      maxFreeTime = Math.Max(maxFreeTime, freeTime);
      maxLeftGap = Math.Max(maxLeftGap, gaps[i]);
    }
    return maxFreeTime;
  }
}

[TestFixture]
public class Solution2Tests
{
  [TestCase(5, new[] { 1, 3 }, new[] { 2, 5 }, 2)]
  [TestCase(10, new[] { 0, 7, 9 }, new[] { 1, 8, 10 }, 7)]
  [TestCase(10, new[] { 0, 3, 7, 9 }, new[] { 1, 4, 8, 10 }, 6)]
  [TestCase(5, new[] { 0, 1, 2, 3, 4 }, new[] { 1, 2, 3, 4, 5 }, 0)]
  public void Test(int eventTime, int[] startTime, int[] endTime, int expected)
  {
    new Solution2().MaxFreeTime(eventTime, startTime, endTime).Should().Be(expected);
  }
}
