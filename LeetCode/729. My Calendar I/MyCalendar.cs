using System.Collections.Generic;

namespace LeetCode._729._My_Calendar_I;

public class MyCalendar
{
  private readonly SortedSet<(int start, int end)> _events;

  public MyCalendar()
  {
    var comparer = Comparer<(int start, int end)>.Create((x, y) =>
    {
      if (x.end <= y.start)
        return -1;
      if (y.end <= x.start)
        return 1;
      return 0;
    });
    _events = new SortedSet<(int start, int end)>(comparer);
  }

  public bool Book(int start, int end)
  {
    return _events.Add((start, end));
  }
}