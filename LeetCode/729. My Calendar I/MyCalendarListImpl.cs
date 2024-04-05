namespace LeetCode._729._My_Calendar_I;

public class MyCalendarListImpl
{
  private readonly List<(int start, int end)> _events = new();

  public bool Book(int start, int end)
  {
    var index = _events.BinarySearch((start, end));
    if (index >= 0)
      return false;
    index = ~index;
    if (_events.Count == 0 ||
        index == 0 && end <= _events[index].start ||
        index == _events.Count && _events[^1].end <= start ||
        index > 0 && index < _events.Count && _events[index - 1].end <= start && end <= _events[index].start)
    {
      _events.Insert(index, (start, end));
      return true;
    }
    return false;
  }
}
