using System.Text.RegularExpressions;

namespace LeetCode._729._My_Calendar_I;

public class MyCalendarSegmentTreeImpl
{
  private readonly SegmentTree st = new(0, (int)1e9);

  public bool Book(int start, int end)
  {
    var canBook = st.CanBook(start, end - 1);
    if (canBook)
      st.Book(start, end - 1);
    return canBook;
  }

  private class SegmentTree(int left, int right)
  {
    private SegmentTree leftTree;
    private SegmentTree rightTree;
    private bool allBooked;
    private bool hasEvent;

    public bool CanBook(int l, int r)
    {
      if (allBooked)
        return false;
      if (left == l && right == r)
        return !hasEvent;
      var m = left + (right - left) / 2;
      var result = true;
      if (l <= m)
      {
        leftTree ??= new SegmentTree(left, m);
        result = leftTree.CanBook(l, Math.Min(r, m));
      }
      if (result && r > m)
      {
        rightTree ??= new SegmentTree(m + 1, right);
        result = rightTree.CanBook(Math.Max(m + 1, l), r);
      }
      return result;
    }

    public void Book(int l, int r)
    {
      hasEvent = true;
      if (left == l && right == r)
      {
        allBooked = true;
        return;
      }
      var m = left + (right - left) / 2;
      if (l <= m)
      {
        leftTree ??= new SegmentTree(left, m);
        leftTree.Book(l, Math.Min(r, m));
      }
      if (r > m)
      {
        rightTree ??= new SegmentTree(m + 1, right);
        rightTree.Book(Math.Max(m + 1, l), r);
      }
    }
  }
}

[TestFixture]
public class MyCalendarSegmentTreeImplTests
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
    MyCalendarSegmentTreeImpl calendar = new();
    for (var i = 1; i < events.Length; i++)
      calendar.Book(events[i][0], events[i][1]).Should().Be((bool)expected[i]);
  }
}
