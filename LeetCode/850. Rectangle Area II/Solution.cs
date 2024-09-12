namespace LeetCode._850._Rectangle_Area_II;

public class Solution
{
  private const int Mod = (int)1e9 + 7;

  private int minX = int.MaxValue;
  private int maxX;
  private int minY = int.MaxValue;
  private int maxY;

  public int RectangleArea(int[][] rectangles)
  {
    foreach (var r in rectangles)
    {
      minX = Math.Min(minX, r[0] - 1);
      minY = Math.Min(minY, r[1] - 1);
      maxX = Math.Max(maxX, r[2] - 1);
      maxY = Math.Max(maxY, r[3] - 1);
    }
    var st = new SegmentTreeX(minX, maxX, minY, maxY);
    foreach (var r in rectangles)
      if (r[0] < r[2] || r[1] < r[3])
        st.Cover(r[0], r[2] - 1, r[1], r[3] - 1);
    return st.GetArea();
  }

  private class SegmentTreeX(int left, int right, int minY, int maxY)
  {
    private SegmentTreeX leftTree;
    private SegmentTreeX rightTree;
    private SegmentTreeY segmentTreeY;

    public void Cover(int x1, int x2, int y1, int y2)
    {
      if (x1 > x2)
        return;
      if (x1 == left && x2 == right && leftTree == null)
      {
        segmentTreeY ??= new SegmentTreeY(minY, maxY);
        segmentTreeY.Cover(y1, y2);
        return;
      }
      var m = left + (right - left) / 2;
      if (leftTree == null)
      {
        leftTree = new SegmentTreeX(left, m, minY, maxY)
        {
          segmentTreeY = segmentTreeY
        };
        rightTree = new SegmentTreeX(m + 1, right, minY, maxY)
        {
          segmentTreeY = segmentTreeY?.Clone()
        };
        segmentTreeY = null;
      }
      leftTree.Cover(x1, Math.Min(x2, m), y1, y2);
      rightTree.Cover(Math.Max(m + 1, x1), x2, y1, y2);
    }

    public int GetArea()
    {
      if (segmentTreeY != null)
        return (int)((long)segmentTreeY.GetArea() * (right - left + 1) % Mod);
      if (leftTree != null)
        return (leftTree.GetArea() + rightTree.GetArea()) % Mod;
      return 0;
    }
  }

  private class SegmentTreeY(int bottom, int top)
  {
    private SegmentTreeY leftTree;
    private SegmentTreeY rightTree;
    private bool covered;
    private int area;

    public void Cover(int y1, int y2)
    {
      if (covered || y1 > y2)
        return;
      if (y1 == bottom && y2 == top)
      {
        area = y2 - y1 + 1;
        covered = true;
        return;
      }
      var m = bottom + (top - bottom) / 2;
      leftTree ??= new SegmentTreeY(bottom, m);
      rightTree ??= new SegmentTreeY(m + 1, top);
      leftTree.Cover(y1, Math.Min(y2, m));
      rightTree.Cover(Math.Max(y1, m + 1), y2);
      area = (leftTree.area + rightTree.area) % Mod;
    }

    public int GetArea()
    {
      return area;
    }

    public SegmentTreeY Clone()
    {
      return new SegmentTreeY(bottom, top)
      {
        leftTree = leftTree?.Clone(),
        rightTree = rightTree?.Clone(),
        covered = covered,
        area = area
      };
    }
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    new Solution().RectangleArea([[0, 0, 2, 2], [1, 0, 2, 3], [1, 0, 3, 1]]).Should().Be(6);
  }

  [Test]
  public void Test2()
  {
    new Solution().RectangleArea([[0, 0, 1000000000, 1000000000]]).Should().Be(49);
  }
}
