namespace LeetCode.SlidingWindow._3439._Reschedule_Meetings_for_Maximum_Free_Time_I;

public class Solution
{
  public int MaxFreeTime(int eventTime, int k, int[] startTime, int[] endTime)
  {
    var segments = new List<(int start, int end)>();
    segments.Add((0, 0));
    for (var i = 0; i < startTime.Length; i++)
      segments.Add((startTime[i], endTime[i]));
    segments.Add((eventTime, eventTime));

    var dist = new long[segments.Count];
    for (var i = 1; i < segments.Count; i++)
      dist[i] = dist[i - 1] + segments[i].start - segments[i - 1].end;

    long maxFreeTime = 0;
    for (var i = k + 1; i < segments.Count; i++)
      maxFreeTime = Math.Max(maxFreeTime, dist[i] - dist[i - k - 1]);
    return (int)maxFreeTime;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(5, 1, new[] { 1, 3 }, new[] { 2, 5 }, 2)]
  [TestCase(10, 1, new[] { 0, 2, 9 }, new[] { 1, 4, 10 }, 6)]
  [TestCase(5, 2, new[] { 0, 1, 2, 3, 4 }, new[] { 1, 2, 3, 4, 5 }, 0)]
  public void Test(int eventTime, int k, int[] startTime, int[] endTime, int expected)
  {
    new Solution().MaxFreeTime(eventTime, k, startTime, endTime).Should().Be(expected);
  }
}
