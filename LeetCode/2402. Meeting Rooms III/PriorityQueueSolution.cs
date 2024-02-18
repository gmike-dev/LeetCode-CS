using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._2402._Meeting_Rooms_III;

public class PriorityQueueSolution
{
  public int MostBooked(int n, int[][] meetings)
  {
    var usedRooms = new PriorityQueue<int, (long time, int room)>(n);
    var freeRooms = new PriorityQueue<int, int>(n);
    for (var i = 0; i < n; i++)
      freeRooms.Enqueue(i, i);
    var meetCount = new int[n];
    SortMeetingsByStartTime();
    foreach (var meeting in meetings)
    {
      while (usedRooms.TryPeek(out var room, out var priority) && priority.time <= meeting[0])
      {
        usedRooms.Dequeue();
        freeRooms.Enqueue(room, room);
      }
      if (freeRooms.Count > 0)
      {
        var room = freeRooms.Dequeue();
        usedRooms.Enqueue(room, (meeting[1], room));
        meetCount[room]++;
      }
      else
      {
        usedRooms.TryDequeue(out var room, out var priority);
        usedRooms.Enqueue(room, (priority.time + meeting[1] - meeting[0], room));
        meetCount[room]++;
      }
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

    void SortMeetingsByStartTime()
    {
      Array.Sort(meetings, (a, b) => a[0] - b[0]);
    }
  }
}

[TestFixture]
public class PriorityQueueSolutionTests
{
  [Test]
  public void Test1()
  {
    new PriorityQueueSolution().MostBooked(2, new[]
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
    new PriorityQueueSolution().MostBooked(3, new[]
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
    new PriorityQueueSolution().MostBooked(4, new[]
    {
      new[] { 18, 19 },
      new[] { 3, 12 },
      new[] { 17, 19 },
      new[] { 2, 13 },
      new[] { 7, 10 }
    }).Should().Be(0);
  }
}
