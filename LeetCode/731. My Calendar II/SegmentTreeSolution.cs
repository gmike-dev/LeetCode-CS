namespace LeetCode._731._My_Calendar_II;

public class MyCalendarTwo
{
  private readonly SegmentTree st = new(0, (int)1e9);

  public bool Book(int start, int end)
  {
    if (st.GetMax(start, end - 1) > 1)
      return false;
    st.Increment(start, end - 1);
    return true;
  }

  private class SegmentTree(int l, int r)
  {
    private readonly int left = l;
    private readonly int right = r;
    private int max;
    private int acc;
    private SegmentTree leftTree;
    private SegmentTree rightTree;

    public int GetMax(int l, int r)
    {
      if (l > r)
        return 0;
      if (left == l && right == r || leftTree == null)
        return max;
      PushDown();
      return Math.Max(
        leftTree.GetMax(l, Math.Min(r, leftTree.right)),
        rightTree.GetMax(Math.Max(rightTree.left, l), r));
    }

    public void Increment(int l, int r)
    {
      if (l > r)
        return;
      if (left == l && right == r)
      {
        acc++;
        max++;
      }
      else
      {
        var m = left + (right - left) / 2;
        leftTree ??= new SegmentTree(left, m);
        rightTree ??= new SegmentTree(m + 1, right);
        PushDown();
        leftTree.Increment(l, Math.Min(r, m));
        rightTree.Increment(Math.Max(m + 1, l), r);
        max = Math.Max(leftTree.max, rightTree.max);
      }
    }

    private void PushDown()
    {
      if (acc > 0)
      {
        leftTree.acc += acc;
        rightTree.acc += acc;
        leftTree.max += acc;
        rightTree.max += acc;
        acc = 0;
      }
    }
  }
}

[TestFixture]
public class Tests
{
  [Test]
  public void Test()
  {
    var myCalendarTwo = new MyCalendarTwo();
    myCalendarTwo.Book(10, 20).Should().BeTrue();
    myCalendarTwo.Book(50, 60).Should().BeTrue();
    myCalendarTwo.Book(10, 40).Should().BeTrue();
    myCalendarTwo.Book(5, 15).Should().BeFalse();
    myCalendarTwo.Book(5, 10).Should().BeTrue();
    myCalendarTwo.Book(25, 55).Should().BeTrue();
  }
}
