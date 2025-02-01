namespace LeetCode.SlidingWindow._3440._Reschedule_Meetings_for_Maximum_Free_Time_II;

public class Solution
{
  public int MaxFreeTime(int eventTime, int[] startTime, int[] endTime)
  {
    var segments = new List<(int start, int end)>();
    segments.Add((0, 0));
    for (var i = 0; i < startTime.Length; i++)
      segments.Add((startTime[i], endTime[i]));
    segments.Add((eventTime, eventTime));

    var maxLeftHole = 0;
    var maxRightHole = new int[segments.Count];
    for (var i = segments.Count - 2; i > 0; i--)
      maxRightHole[i - 1] = Math.Max(maxRightHole[i], segments[i + 1].start - segments[i].end);

    var maxFreeTime = 0;
    for (var i = 1; i < segments.Count - 1; i++)
    {
      var holeLeft = segments[i].start - segments[i - 1].end;
      var holeRight = segments[i + 1].start - segments[i].end;
      var length = segments[i].end - segments[i].start;
      if (maxLeftHole >= length || maxRightHole[i] >= length)
        maxFreeTime = Math.Max(maxFreeTime, segments[i + 1].start - segments[i - 1].end);
      else
        maxFreeTime = Math.Max(maxFreeTime, holeLeft + holeRight);
      maxLeftHole = Math.Max(maxLeftHole, holeLeft);
    }
    return maxFreeTime;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(5, new[] { 1, 3 }, new[] { 2, 5 }, 2)]
  [TestCase(10, new[] { 0, 7, 9 }, new[] { 1, 8, 10 }, 7)]
  [TestCase(10, new[] { 0, 3, 7, 9 }, new[] { 1, 4, 8, 10 }, 6)]
  [TestCase(5, new[] { 0, 1, 2, 3, 4 }, new[] { 1, 2, 3, 4, 5 }, 0)]
  public void Test(int eventTime, int[] startTime, int[] endTime, int expected)
  {
    new Solution().MaxFreeTime(eventTime, startTime, endTime).Should().Be(expected);
  }
}
