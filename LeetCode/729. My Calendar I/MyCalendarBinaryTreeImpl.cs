using System.Text.RegularExpressions;

namespace LeetCode._729._My_Calendar_I;

public class MyCalendarBinaryTreeImpl
{
  private Event root;

  public bool Book(int start, int end)
  {
    return Dfs(start, end - 1, ref root);
  }

  private static bool Dfs(int start, int end, ref Event e)
  {
    if (e == null)
    {
      e = new Event(start, end);
      return true;
    }
    if (end < e.Start)
      return Dfs(start, end, ref e.Left);
    if (start > e.End)
      return Dfs(start, end, ref e.Right);
    return false;
  }

  private class Event(int start, int end)
  {
    public readonly int Start = start;
    public readonly int End = end;
    public Event Left;
    public Event Right;
  }
}

[TestFixture]
public class MyCalendarBinaryTreeImplTests
{
  [TestCase("[[], [10, 20], [15, 25], [20, 30]]", new object[] { null, true, false, true })]
  [TestCase(
    "[[],[23,32],[42,50],[6,14],[0,7],[21,30],[26,31],[46,50],[28,36],[0,6],[27,36],[6,11],[20,25],[32,37],[14,20],[7,16],[13,22],[39,47],[37,46],[42,50],[9,17],[49,50],[31,37],[43,49],[2,10],[3,12],[8,14],[14,21],[42,47],[43,49],[36,43]]",
    new object[]
    {
      null, true, true, true, false, false, false, false, false, true, false, false, false, true, true, false, false,
      false, false, false, false, false, false, false, false, false, false, false, false, false, false
    })
  ]
  public void Test(string eventsStr, object[] expected)
  {
    var r = new Regex(@"\[(.*?)\]", RegexOptions.Compiled);
    var events = r.Matches(eventsStr[1..^1]).Select(m => m.Groups[1].Value)
      .Select(s =>
        s.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).Select(int.Parse).ToArray())
      .ToArray();
    MyCalendarBinaryTreeImpl calendar = new();
    for (var i = 1; i < events.Length; i++)
      calendar.Book(events[i][0], events[i][1]).Should().Be((bool)expected[i]);
  }
}
