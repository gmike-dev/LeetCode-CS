namespace LeetCode._3347._Maximum_Frequency_of_an_Element_After_Performing_Operations_II;

public class SegmentTreeSolution
{
  public int MaxFrequency(int[] nums, int k, int numOperations)
  {
    var counter = new Dictionary<int, int>();
    var min = int.MaxValue;
    var max = int.MinValue;
    foreach (var x in nums)
    {
      counter[x] = counter.GetValueOrDefault(x) + 1;
      min = Math.Min(min, x);
      max = Math.Max(max, x);
    }
    var t = new SegmentTreeNode(min, max);
    foreach (var x in nums)
      t.Inc(Math.Max(min, x - k), Math.Min(max, x + k));
    var result = Math.Min(t.Max(), numOperations);
    foreach (var (x, count) in counter)
      result = Math.Max(result, count + Math.Min(t.GetAcc(x) - count, numOperations));
    return result;
  }

  private class SegmentTreeNode(int left, int right)
  {
    private int acc;
    private int max;
    private SegmentTreeNode leftTree;
    private SegmentTreeNode rightTree;

    public int Max()
    {
      return max;
    }

    public int GetAcc(int pos)
    {
      if (leftTree == null)
        return acc;
      var m = left + (right - left) / 2;
      return acc + (pos <= m ? leftTree : rightTree).GetAcc(pos);
    }

    public void Inc(int l, int r)
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
        leftTree ??= new SegmentTreeNode(left, m);
        rightTree ??= new SegmentTreeNode(m + 1, right);
        if (acc > 0)
        {
          leftTree.acc += acc;
          leftTree.max += acc;
          rightTree.acc += acc;
          rightTree.max += acc;
          acc = 0;
        }
        leftTree.Inc(l, Math.Min(m, r));
        rightTree.Inc(Math.Max(m + 1, l), r);
        max = Math.Max(leftTree.max, rightTree.max);
      }
    }
  }
}

public class SegmentTreeSolutionTests
{
  [TestCase(new[] { 1, 4, 5 }, 1, 2, 2)]
  [TestCase(new[] { 1, 4, 5 }, 0, 2, 1)]
  [TestCase(new[] { 1, 4, 5, 5 }, 0, 2, 2)]
  [TestCase(new[] { 1, 4, 5, 5 }, 1000, 0, 2)]
  [TestCase(new[] { 1, 4, 5, 6 }, 1000, 0, 1)]
  [TestCase(new[] { 5, 11, 20, 20 }, 5, 1, 2)]
  [TestCase(new[] { 5, 64 }, 42, 2, 2)]
  [TestCase(new[] { 25, 59 }, 39, 2, 2)]
  [TestCase(new[] { 1, 78, 70 }, 39, 3, 3)]
  [TestCase(new[] { 94, 10 }, 51, 1, 1)]
  [TestCase(new[] { 1, 2, 4, 5 }, 2, 4, 4)]
  [TestCase(new[] { 15, 113, 122, 102 }, 90, 3, 4)]
  public void Test1(int[] nums, int k, int numOperations, int expected)
  {
    new SegmentTreeSolution().MaxFrequency(nums, k, numOperations).Should().Be(expected);
  }
}
