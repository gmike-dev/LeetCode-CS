namespace LeetCode.__Monotonic._2940._Find_Building_Where_Alice_and_Bob_Can_Meet;

public class SegmentTreeSolution
{
  public int[] LeftmostBuildingQueries(int[] heights, int[][] queries)
  {
    int n = queries.Length;
    int m = heights.Length;
    int[] result = new int[n];
    ArraySegmentTree t = new(heights);
    for (int i = 0; i < n; i++)
    {
      int[] q = queries[i];
      int l = Math.Min(q[0], q[1]);
      int r = Math.Max(q[0], q[1]);
      if (l == r)
      {
        result[i] = l;
        continue;
      }
      if (heights[l] < heights[r])
      {
        result[i] = r;
        continue;
      }
      int h = Math.Max(heights[l], heights[r]);
      result[i] = t.Query(r + 1, m - 1, h);
    }
    return result;
  }

  private class ArraySegmentTree
  {
    private readonly int n;
    private readonly int[] max;

    public int Query(int l, int r, int value)
    {
      return Query(1, 0, n - 1, l, r, value);
    }

    private int Query(int v, int tl, int tr, int l, int r, int value)
    {
      if (l > r || max[v] <= value)
      {
        return -1;
      }
      if (tl == tr)
      {
        return tl;
      }
      var tm = tl + (tr - tl) / 2;
      int result = Query(2 * v, tl, tm, l, Math.Min(tm, r), value);
      if (result != -1)
      {
        return result;
      }
      return Query(2 * v + 1, tm + 1, tr, Math.Max(tm + 1, l), r, value);
    }

    private void Build(int[] nums, int v, int l, int r)
    {
      if (l == r)
      {
        max[v] = nums[l];
      }
      else
      {
        var m = l + (r - l) / 2;
        Build(nums, 2 * v, l, m);
        Build(nums, 2 * v + 1, m + 1, r);
        max[v] = Math.Max(max[2 * v], max[2 * v + 1]);
      }
    }

    public ArraySegmentTree(int[] nums)
    {
      max = new int[4 * nums.Length];
      n = nums.Length;
      Build(nums, 1, 0, n - 1);
    }
  }
}

[TestFixture]
public class SegmentTreeSolutionTests
{
  [Test]
  public void Test1()
  {
    new SegmentTreeSolution().LeftmostBuildingQueries(
        [6, 4, 8, 5, 2, 7],
        [[0, 1], [0, 3], [2, 4], [3, 4], [2, 2]]).Should()
      .BeEquivalentTo([2, 5, -1, 5, 2], o => o.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    new SegmentTreeSolution().LeftmostBuildingQueries(
        [5, 3, 8, 2, 6, 1, 4, 6],
        [[0, 7], [3, 5], [5, 2], [3, 0], [1, 6]]).Should()
      .BeEquivalentTo([7, 6, -1, 4, 6], o => o.WithStrictOrdering());
  }
}

