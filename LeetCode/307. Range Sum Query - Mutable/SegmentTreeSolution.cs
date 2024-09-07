namespace LeetCode._307._Range_Sum_Query___Mutable.SegmentTreeSolution;

public class NumArray(int[] nums)
{
  private readonly SegmentTree segmentTree = new(nums, 0, nums.Length - 1);

  public void Update(int index, int val)
  {
    segmentTree.Update(index, val);
  }

  public int SumRange(int left, int right)
  {
    return segmentTree.SumRange(left, right);
  }

  private class SegmentTree
  {
    private readonly int left;
    private readonly int right;
    private readonly SegmentTree leftTree;
    private readonly SegmentTree rightTree;
    private int sum;

    public int SumRange(int l, int r)
    {
      if (l > r)
        return 0;
      if (left == l && right == r)
        return sum;
      return leftTree.SumRange(l, int.Min(r, leftTree.right)) +
             rightTree.SumRange(int.Max(l, rightTree.left), r);
    }

    public void Update(int index, int val)
    {
      if (left == right)
      {
        sum = val;
      }
      else
      {
        if (index <= leftTree.right)
          leftTree.Update(index, val);
        else
          rightTree.Update(index, val);
        sum = leftTree.sum + rightTree.sum;
      }
    }

    public SegmentTree(int[] nums, int l, int r)
    {
      left = l;
      right = r;
      if (l < r)
      {
        var m = l + (r - l) / 2;
        leftTree = new SegmentTree(nums, l, m);
        rightTree = new SegmentTree(nums, m + 1, r);
        sum = leftTree.sum + rightTree.sum;
      }
      else
      {
        sum = nums[left];
      }
    }
  }
}

[TestFixture]
public class SegmentTreeNumArrayTests
{
  [Test]
  public void Test()
  {
    var numArray = new NumArray([1, 3, 5]);
    numArray.SumRange(0, 2).Should().Be(9);
    numArray.Update(1, 2);
    numArray.SumRange(0, 2).Should().Be(8);
  }
}
