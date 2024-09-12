namespace LeetCode._732._My_Calendar_III;

public class MyCalendarThree
{
  private readonly SegmentTree st = new(0, (int)1e9);
  private int minTime = int.MaxValue;

  private int maxTime;

  public int Book(int startTime, int endTime)
  {
    st.Increment(startTime, endTime - 1);
    minTime = Math.Min(minTime, startTime);
    maxTime = Math.Max(maxTime, endTime);
    return st.GetMax(minTime, maxTime - 1);
  }

  private class SegmentTree(int left, int right)
  {
    private int max;
    private int accumulated;
    private SegmentTree leftTree;
    private SegmentTree rightTree;

    public int GetMax(int l, int r)
    {
      if (l > r)
        return 0;
      if (l == left && r == right || leftTree == null)
        return max;
      var m = left + (right - left) / 2;
      leftTree ??= new SegmentTree(left, m);
      rightTree ??= new SegmentTree(m + 1, right);
      PushDown();
      return Math.Max(leftTree.GetMax(l, Math.Min(m, r)), rightTree.GetMax(Math.Max(m + 1, l), r));
    }

    public void Increment(int l, int r)
    {
      if (l > r)
        return;
      if (left == l && r == right)
      {
        accumulated++;
        max++;
        return;
      }
      var m = left + (right - left) / 2;
      leftTree ??= new SegmentTree(left, m);
      rightTree ??= new SegmentTree(m + 1, right);
      PushDown();
      leftTree.Increment(l, Math.Min(m, r));
      rightTree.Increment(Math.Max(m + 1, l), r);
      max = Math.Max(leftTree.max, rightTree.max);
    }

    private void PushDown()
    {
      if (accumulated > 0)
      {
        leftTree.max += accumulated;
        rightTree.max += accumulated;
        leftTree.accumulated += accumulated;
        rightTree.accumulated += accumulated;
        accumulated = 0;
      }
    }
  }
}

[TestFixture]
public class MyCalendarThreeTests
{
  [Test]
  public void Test()
  {
    var myCalendarThree = new MyCalendarThree();
    myCalendarThree.Book(10, 20).Should().Be(1);
    myCalendarThree.Book(50, 60).Should().Be(1);
    myCalendarThree.Book(10, 40).Should().Be(2);
    myCalendarThree.Book(5, 15).Should().Be(3);
    myCalendarThree.Book(5, 10).Should().Be(3);
    myCalendarThree.Book(25, 55).Should().Be(3);
  }
}
