namespace LeetCode.___Binary_Search._3356._Zero_Array_Transformation_II;

public class SegmentTreeSolution
{
  public int MinZeroArray(int[] nums, int[][] queries)
  {
    var st = new SegmentTree(nums);
    if (st.GetMax() == 0)
      return 0;
    for (var i = 0; i < queries.Length; i++)
    {
      var q = queries[i];
      var (l, r, val) = (q[0], q[1], q[2]);
      st.Add(l, r, -val);
      if (st.GetMax() == 0)
        return i + 1;
    }
    return -1;
  }

  private class SegmentTreeNode
  {
    private readonly int left;
    private readonly int right;
    private int max;
    private int s;
    private readonly SegmentTreeNode leftNode;
    private readonly SegmentTreeNode rightNode;

    public void Add(int l, int r, int val)
    {
      if (l == left && r == right)
      {
        s += val;
      }
      else
      {
        var m = left + (right - left) / 2;
        if (s != 0)
        {
          leftNode.s += s;
          rightNode.s += s;
          s = 0;
        }
        if (l <= m)
          leftNode.Add(l, Math.Min(m, r), val);
        if (r > m)
          rightNode.Add(Math.Max(m + 1, l), r, val);
        max = Math.Max(leftNode.GetMax(), rightNode.GetMax());
      }
    }

    public int GetMax()
    {
      return Math.Max(0, max + s);
    }

    public SegmentTreeNode(int l, int r, int[] values)
    {
      left = l;
      right = r;
      if (l == r)
      {
        max = values[l];
      }
      else
      {
        var m = left + (right - left) / 2;
        leftNode = new SegmentTreeNode(left, m, values);
        rightNode = new SegmentTreeNode(m + 1, right, values);
        max = Math.Max(leftNode.max, rightNode.max);
      }
    }
  }

  private class SegmentTree
  {
    private readonly SegmentTreeNode root;

    public int GetMax() => root.GetMax();

    public void Add(int l, int r, int val) => root.Add(l, r, val);

    public SegmentTree(int[] values)
    {
      root = new SegmentTreeNode(0, values.Length - 1, values);
    }
  }
}

[TestFixture]
public class SegmentTreeSolutionTests
{
  [Test]
  public void Test1()
  {
    new SegmentTreeSolution().MinZeroArray([2, 0, 2], [[0, 2, 1], [0, 2, 1], [1, 1, 3]]).Should().Be(2);
  }

  [Test]
  public void Test2()
  {
    new SegmentTreeSolution().MinZeroArray([4, 3, 2, 1], [[1, 3, 2], [0, 2, 1]]).Should().Be(-1);
  }

  [Test]
  public void Test3()
  {
    new SegmentTreeSolution().MinZeroArray([0], [[0, 0, 2], [0, 0, 4], [0, 0, 4], [0, 0, 3], [0, 0, 5]]).Should().Be(0);
  }
}
