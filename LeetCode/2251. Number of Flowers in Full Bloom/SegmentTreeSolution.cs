using System;

namespace LeetCode._2251._Number_of_Flowers_in_Full_Bloom;

public class SegmentTreeSolution
{
  public int[] FullBloomFlowers(int[][] flowers, int[] people)
  {
    var s = new SegmentTree(1, 1000000000);
    foreach (var flower in flowers)
      s.AddSegment(flower[0], flower[1]);
    for (var i = 0; i < people.Length; i++)
      people[i] = s.Query(people[i]);
    return people;
  }

  private class SegmentTreeNode
  {
    private readonly int l;
    private readonly int r;
    private int s;
    private SegmentTreeNode left;
    private SegmentTreeNode right;

    public void AddSegment(int l, int r)
    {
      if (l == this.l && r == this.r)
      {
        s++;
      }
      else
      {
        var m = this.l + (this.r - this.l) / 2;
        if (l <= m)
          (left ??= new SegmentTreeNode(this.l, m)).AddSegment(l, Math.Min(m, r));
        if (r > m)
          (right ??= new SegmentTreeNode(m + 1, this.r)).AddSegment(Math.Max(m + 1, l), r);
      }
    }

    public int Query(int pos)
    {
      var m = l + (r - l) / 2;
      if (pos <= m)
        return s + (left?.Query(pos) ?? 0);
      return s + (right?.Query(pos) ?? 0);
    }

    public SegmentTreeNode(int l, int r)
    {
      this.l = l;
      this.r = r;
    }
  }

  private class SegmentTree
  {
    private readonly SegmentTreeNode root;

    public int Query(int pos) => root.Query(pos);

    public void AddSegment(int l, int r) => root.AddSegment(l, r);

    public SegmentTree(int l, int r) => root = new SegmentTreeNode(l, r);
  }
}