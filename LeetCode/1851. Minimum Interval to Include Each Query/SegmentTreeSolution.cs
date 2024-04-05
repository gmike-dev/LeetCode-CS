namespace LeetCode._1851._Minimum_Interval_to_Include_Each_Query;

public class SegmentTreeSolution
{
  public int[] MinInterval(int[][] intervals, int[] queries)
  {
    var s = new SegmentTree(1, 10000000);
    // var s = new SegmentTree(intervals.Min(i => i[0]), intervals.Max(i => i[1]));
    foreach (var i in intervals)
      s.AddSegment(i[0], i[1]);
    for (var i = 0; i < queries.Length; i++)
      queries[i] = s.Query(queries[i]);
    return queries;
  }

  private class SegmentTree
  {
    private readonly SegmentTreeNode root;

    public int Query(int pos) => root.Query(pos);
    public void AddSegment(int l, int r) => root.AddSegment(l, r, r - l + 1);
    public SegmentTree(int l, int r) => root = new SegmentTreeNode(l, r);
  }

  private class SegmentTreeNode
  {
    private readonly int l;
    private readonly int r;
    private int length = -1;
    private SegmentTreeNode left;
    private SegmentTreeNode right;

    public void AddSegment(int l, int r, int len)
    {
      if (l == this.l && r == this.r)
      {
        if (length == -1 || len < length)
          length = len;
      }
      else if (length == -1 || len < length)
      {
        var m = this.l + (this.r - this.l) / 2;
        if (l <= m)
          (left ??= new SegmentTreeNode(this.l, m)).AddSegment(l, Math.Min(m, r), len);
        if (r > m)
          (right ??= new SegmentTreeNode(m + 1, this.r)).AddSegment(Math.Max(m + 1, l), r, len);
      }
    }

    public int Query(int pos)
    {
      var m = l + (r - l) / 2;
      var node = pos <= m ? left : right;
      if (node == null)
        return length;
      var result = node.Query(pos);
      if (length == -1)
        return result;
      if (result == -1)
        return length;
      return Math.Min(length, result);
    }

    public SegmentTreeNode(int l, int r)
    {
      this.l = l;
      this.r = r;
    }
  }
}
