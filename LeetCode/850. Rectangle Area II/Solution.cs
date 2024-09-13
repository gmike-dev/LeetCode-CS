namespace LeetCode._850._Rectangle_Area_II;

public class Solution
{
  private const int Mod = (int)1e9 + 7;

  public int RectangleArea(int[][] rectangles)
  {
    var (minX, maxX, minY, maxY) = (int.MaxValue, 0, int.MaxValue, 0);
    foreach (var r in rectangles)
    {
      minX = Math.Min(minX, r[0] - 1);
      minY = Math.Min(minY, r[1] - 1);
      maxX = Math.Max(maxX, r[2] - 1);
      maxY = Math.Max(maxY, r[3] - 1);
    }
    var st = new SegmentTree2d(minX, maxX, minY, maxY);
    foreach (var r in rectangles)
    {
      var (x1, y1, x2, y2) = (r[0], r[1], r[2], r[3]);
      if (x1 < x2 || y1 < y2)
        st.Cover(x1, x2 - 1, y1, y2 - 1);
    }
    return st.GetArea();
  }

  private class SegmentTree2d(int leftX, int rightX, int minY, int maxY)
  {
    private SegmentTree2d leftTree;
    private SegmentTree2d rightTree;
    private SegmentTree1d ySegmentTree;

    public void Cover(int x1, int x2, int y1, int y2)
    {
      if (x1 > x2)
        return;
      if (x1 == leftX && x2 == rightX && leftTree == null)
      {
        ySegmentTree ??= new SegmentTree1d(minY, maxY);
        ySegmentTree.Cover(y1, y2);
        return;
      }
      var m = leftX + (rightX - leftX) / 2;
      if (leftTree == null)
      {
        leftTree = new SegmentTree2d(leftX, m, minY, maxY);
        rightTree = new SegmentTree2d(m + 1, rightX, minY, maxY);
        leftTree.ySegmentTree = ySegmentTree;
        rightTree.ySegmentTree = ySegmentTree?.Clone();
        ySegmentTree = null;
      }
      leftTree.Cover(x1, Math.Min(x2, m), y1, y2);
      rightTree.Cover(Math.Max(m + 1, x1), x2, y1, y2);
    }

    public int GetArea()
    {
      if (ySegmentTree != null)
        return (int)((long)ySegmentTree.GetArea() * (rightX - leftX + 1) % Mod);
      if (leftTree != null)
        return (leftTree.GetArea() + rightTree.GetArea()) % Mod;
      return 0;
    }

    private class SegmentTree1d(int left, int right)
    {
      private SegmentTree1d leftTree;
      private SegmentTree1d rightTree;
      private bool covered;
      private int area;

      public void Cover(int l, int r)
      {
        if (covered || l > r)
          return;
        if (l == left && r == right)
        {
          area = r - l + 1;
          covered = true;
          return;
        }
        var m = left + (right - left) / 2;
        leftTree ??= new SegmentTree1d(left, m);
        rightTree ??= new SegmentTree1d(m + 1, right);
        leftTree.Cover(l, Math.Min(r, m));
        rightTree.Cover(Math.Max(l, m + 1), r);
        area = (leftTree.area + rightTree.area) % Mod;
      }

      public int GetArea() => area;

      public SegmentTree1d Clone() => new(left, right)
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
