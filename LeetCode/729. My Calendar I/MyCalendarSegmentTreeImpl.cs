using System.Text.RegularExpressions;

namespace LeetCode._729._My_Calendar_I;

public class MyCalendarSegmentTreeImpl
{
  private readonly SegmentTree st = new(0, (int)1e9);

  public bool Book(int start, int end)
  {
    if (st.CanBook(start, end - 1))
    {
      st.Book(start, end - 1);
      return true;
    }
    return false;
  }

  private class SegmentTree(int left, int right)
  {
    private readonly int left = left;
    private readonly int right = right;
    private SegmentTree leftTree;
    private SegmentTree rightTree;
    private bool used;

    public bool CanBook(int l, int r)
    {
      if (l > r)
        return true;
      if (leftTree is null || left == l && right == r)
        return !used;
      CreateChild();
      return leftTree.CanBook(l, Math.Min(r, leftTree.right)) &&
             rightTree.CanBook(Math.Max(rightTree.left, l), r);
    }

    public void Book(int l, int r)
    {
      if (l > r)
        return;
      used = true;
      if (left == l && right == r)
        return;
      CreateChild();
      leftTree.Book(l, Math.Min(r, leftTree.right));
      rightTree.Book(Math.Max(rightTree.left, l), r);
    }

    private void CreateChild()
    {
      var m = left + (right - left) / 2;
      leftTree ??= new SegmentTree(left, m);
      rightTree ??= new SegmentTree(m + 1, right);
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
