namespace LeetCode.___Binary_Search._3356._Zero_Array_Transformation_II;

public class SegmentTreeOnArraySolution
{
  public int MinZeroArray(int[] nums, int[][] queries)
  {
    var st = new ArraySegmentTree(nums);
    if (st.GetMax() == 0)
      return 0;
    for (var i = 0; i < queries.Length; i++)
    {
      var q = queries[i];
      var (l, r, val) = (q[0], q[1], q[2]);
      st.RangeAdd(l, r, -val);
      if (Math.Max(0, st.GetMax()) == 0)
        return i + 1;
    }
    return -1;
  }

  private class ArraySegmentTree
  {
    private readonly int n;
    private readonly int[] max;
    private readonly int[] acc;

    public int GetMax()
    {
      return max[1] + acc[1];
    }

    public void RangeAdd(int l, int r, int val)
    {
      RangeAdd(1, 0, n - 1, l, r, val);
    }

    private void RangeAdd(int v, int tl, int tr, int l, int r, int val)
    {
      if (tl == l && tr == r)
      {
        acc[v] += val;
      }
      else
      {
        if (acc[v] != 0)
        {
          acc[2 * v] += acc[v];
          acc[2 * v + 1] += acc[v];
          acc[v] = 0;
        }
        var tm = tl + (tr - tl) / 2;
        if (l <= tm)
          RangeAdd(2 * v, tl, tm, l, Math.Min(r, tm), val);
        if (r > tm)
          RangeAdd(2 * v + 1, tm + 1, tr, Math.Max(l, tm + 1), r, val);
        max[v] = Math.Max(max[2 * v] + acc[2 * v], max[2 * v + 1] + acc[2 * v + 1]);
      }
    }

    private void Build(int[] nums, int v, int tl, int tr)
    {
      if (tl == tr)
      {
        max[v] = nums[tl];
      }
      else
      {
        var m = tl + (tr - tl) / 2;
        Build(nums, 2 * v, tl, m);
        Build(nums, 2 * v + 1, m + 1, tr);
        max[v] = Math.Max(max[2 * v], max[2 * v + 1]);
      }
    }

    public ArraySegmentTree(int[] nums)
    {
      max = new int[4 * nums.Length];
      acc = new int[4 * nums.Length];
      n = nums.Length;
      Build(nums, 1, 0, n - 1);
    }
  }

}

[TestFixture]
public class SegmentTreeOnArraySolutionTests
{
  [Test]
  public void Test1()
  {
    new SegmentTreeOnArraySolution().MinZeroArray([2, 0, 2], [[0, 2, 1], [0, 2, 1], [1, 1, 3]]).Should().Be(2);
  }

  [Test]
  public void Test2()
  {
    new SegmentTreeOnArraySolution().MinZeroArray([4, 3, 2, 1], [[1, 3, 2], [0, 2, 1]]).Should().Be(-1);
  }

  [Test]
  public void Test3()
  {
    new SegmentTreeOnArraySolution().MinZeroArray([0], [[0, 0, 2], [0, 0, 4], [0, 0, 4], [0, 0, 3], [0, 0, 5]]).Should().Be(0);
  }

  [Test]
  public void Test4()
  {
    new SegmentTreeOnArraySolution().MinZeroArray([7, 6, 8], [[0, 0, 2], [0, 1, 5], [2, 2, 5], [0, 2, 4]]).Should()
      .Be(4);
  }
}
