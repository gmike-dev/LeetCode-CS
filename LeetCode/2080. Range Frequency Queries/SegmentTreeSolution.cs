namespace LeetCode._2080._Range_Frequency_Queries;

public class SegmentTreeRangeFreqQuery(int[] arr)
{
  private readonly SegmentTree st = new(arr, 0, arr.Length - 1);

  public int Query(int left, int right, int value)
  {
    return st.Query(left, right, value);
  }

  private class SegmentTree
  {
    private readonly int l;
    private readonly int r;
    private readonly SegmentTree leftTree;
    private readonly SegmentTree rightTree;
    private readonly Dictionary<int, int> count;

    public int Query(int left, int right, int value)
    {
      if (left == l && right == r)
        return count.GetValueOrDefault(value);
      var m = l + (r - l) / 2;
      var result = 0;
      if (left <= m)
        result += leftTree.Query(left, Math.Min(m, right), value);
      if (right > m)
        result += rightTree.Query(Math.Max(m + 1, left), right, value);
      return result;
    }

    public SegmentTree(int[] data, int l, int r)
    {
      this.l = l;
      this.r = r;
      if (l == r)
      {
        count = new Dictionary<int, int> { { data[l], 1 } };
      }
      else
      {
        var m = l + (r - l) / 2;
        leftTree = new SegmentTree(data, l, m);
        rightTree = new SegmentTree(data, m + 1, r);
        count = new Dictionary<int, int>(leftTree.count);
        foreach (var (k, v) in rightTree.count)
          count[k] = count.GetValueOrDefault(k) + v;
      }
    }
  }
}

[TestFixture]
public class SegmentTreeRangeFreqQueryTests
{
  [Test]
  public void Test()
  {
    var rfq = new SegmentTreeRangeFreqQuery([12, 33, 4, 56, 22, 2, 34, 33, 22, 12, 34, 56]);
    rfq.Query(1, 2, 4).Should().Be(1);
    rfq.Query(0, 11, 33).Should().Be(2);
    rfq.Query(0, 11, 2).Should().Be(1);
  }
}
