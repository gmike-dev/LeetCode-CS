namespace LeetCode._218._The_Skyline_Problem;

public class SegmentTreeSolution
{
  public IList<IList<int>> GetSkyline(int[][] buildings)
  {
    var left = int.MaxValue;
    var right = 0;
    foreach (var building in buildings)
    {
      left = int.Min(left, building[0]);
      right = int.Max(right, building[1]);
    }
    var st = new SegmentTreeNode(left, right);
    foreach (var building in buildings)
      st.Update(building[0], building[1], building[2]);
    var points = new List<(int, int)>(2 * buildings.Length);
    foreach (var building in buildings)
    {
      points.Add((building[0], st.GetMax(building[0])));
      points.Add((building[1], st.GetMax(building[1])));
    }
    points.Sort();
    var result = new List<IList<int>>();
    var prevHeight = 0;
    foreach (var (pos, height) in points)
    {
      if (prevHeight != height)
      {
        result.Add([pos, height]);
        prevHeight = height;
      }
    }
    return result;
  }

  private class SegmentTreeNode(int l, int r)
  {
    private SegmentTreeNode leftNode;
    private SegmentTreeNode rightNode;
    private readonly int left = l;
    private readonly int right = r;
    private int maxValue;

    public void Update(int l, int r, int value)
    {
      if (value <= maxValue)
        return;

      if (right - left <= 1 || left == l && right == r && (maxValue != 0 || leftNode == null))
      {
        maxValue = value;
        return;
      }

      var m = left + (right - left) / 2;
      leftNode ??= new SegmentTreeNode(left, m);
      rightNode ??= new SegmentTreeNode(m, right);

      if (maxValue != 0)
      {
        leftNode.maxValue = maxValue;
        rightNode.maxValue = maxValue;
        maxValue = 0;
      }

      if (l < leftNode.right)
        leftNode.Update(l, int.Min(r, leftNode.right), value);
      if (r > rightNode.left)
        rightNode.Update(int.Max(l, rightNode.left), r, value);
    }

    public int GetMax(int pos)
    {
      if (pos == right)
        return 0;
      if (right - left <= 1 || maxValue != 0 || leftNode == null)
        return maxValue;
      return pos < leftNode.right ? leftNode.GetMax(pos) : rightNode.GetMax(pos);
    }
  }
}

[TestFixture]
public class SegmentTreeSolutionTests
{
  [Test]
  public void Test1()
  {
    IList<IList<int>> expected = [[2, 10], [3, 15], [7, 12], [12, 0], [15, 10], [20, 8], [24, 0]];
    new SegmentTreeSolution()
      .GetSkyline([[2, 9, 10], [3, 7, 15], [5, 12, 12], [15, 20, 10], [19, 24, 8]])
      .Should()
      .BeEquivalentTo(expected);
  }

  [Test]
  public void Test2()
  {
    IList<IList<int>> expected = [[0, 3], [5, 0]];
    new SegmentTreeSolution()
      .GetSkyline([[0, 2, 3], [2, 5, 3]])
      .Should()
      .BeEquivalentTo(expected);
  }

  [Test]
  public void Test3()
  {
    IList<IList<int>> expected = [[1, 1], [2, 0], [2147483646, 2147483647], [2147483647, 0]];
    new SegmentTreeSolution()
      .GetSkyline([[1, 2, 1], [2147483646, 2147483647, 2147483647]])
      .Should()
      .BeEquivalentTo(expected);
  }

  [Test]
  public void Test4()
  {
    IList<IList<int>> expected = [[1, 1], [2, 0], [6, 1], [7, 0]];
    new SegmentTreeSolution()
      .GetSkyline([[1, 2, 1], [6, 7, 1]])
      .Should()
      .BeEquivalentTo(expected);
  }
}
