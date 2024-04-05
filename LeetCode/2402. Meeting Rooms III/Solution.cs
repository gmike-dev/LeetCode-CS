namespace LeetCode._2402._Meeting_Rooms_III;

public class Solution
{
  public int MostBooked(int n, int[][] meetings)
  {
    var roomAvailabilityTime = new long[n];
    var meetCount = new int[n];
    SortMeetingsByStartTime();
    foreach (var meeting in meetings)
    {
      var room = GetFirstAvailableRoom(meeting[0]);
      if (roomAvailabilityTime[room] <= meeting[0])
        roomAvailabilityTime[room] = meeting[1];
      else
        roomAvailabilityTime[room] += meeting[1] - meeting[0];
      meetCount[room]++;
    }
    return GetMostUsedRoom();

    int GetMostUsedRoom()
    {
      var mostUsedRoom = 0;
      for (var i = 1; i < n; i++)
      {
        if (meetCount[i] > meetCount[mostUsedRoom])
          mostUsedRoom = i;
      }
      return mostUsedRoom;
    }

    int GetFirstAvailableRoom(int meetingStartTime)
    {
      var room = -1;
      for (var i = 0; i < n; i++)
      {
        if (roomAvailabilityTime[i] <= meetingStartTime)
        {
          room = i;
          break;
        }
        if (room == -1 || roomAvailabilityTime[i] < roomAvailabilityTime[room])
          room = i;
      }
      return room;
    }

    void SortMeetingsByStartTime()
    {
      Array.Sort(meetings, (a, b) => a[0] - b[0]);
    }
  }
}

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().MostBooked(2, new[]
    {
      new[] { 0, 10 },
      new[] { 1, 5 },
      new[] { 2, 7 },
      new[] { 3, 4 }
    }).Should().Be(0);
  }

  [Test]
  public void Test2()
  {
    new Solution().MostBooked(3, new[]
    {
      new[] { 1, 20 },
      new[] { 2, 10 },
      new[] { 3, 5 },
      new[] { 4, 9 },
      new[] { 6, 8 }
    }).Should().Be(1);
  }

  [Test]
  public void Test67()
  {
    new Solution().MostBooked(4, new[]
    {
      new[] { 18, 19 },
      new[] { 3, 12 },
      new[] { 17, 19 },
      new[] { 2, 13 },
      new[] { 7, 10 }
    }).Should().Be(0);
  }
}
