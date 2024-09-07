namespace LeetCode._307._Range_Sum_Query___Mutable.ArraySegmentTreeSolution;

public class NumArray(int[] nums)
{
  private readonly ArraySegmentTree arraySegmentTree = new(nums);

  public void Update(int index, int val)
  {
    arraySegmentTree.Update(index, val);
  }

  public int SumRange(int left, int right)
  {
    return arraySegmentTree.SumRange(left, right);
  }

  private class ArraySegmentTree
  {
    private readonly int n;
    private readonly int[] sum;

    public int SumRange(int l, int r)
    {
      return SumRange(1, 0, n - 1, l, r);
    }

    private int SumRange(int v, int tl, int tr, int l, int r)
    {
      if (l > r)
        return 0;
      if (tl == l && tr == r)
        return sum[v];
      var tm = tl + (tr - tl) / 2;
      return SumRange(2 * v, tl, tm, l, int.Min(tm, r)) +
             SumRange(2 * v + 1, tm + 1, tr, int.Max(tm + 1, l), r);
    }

    public void Update(int index, int val)
    {
      Update(1, 0, n - 1, index, val);
    }

    private void Update(int v, int l, int r, int index, int val)
    {
      if (l == r)
      {
        sum[v] = val;
      }
      else
      {
        var m = l + (r - l) / 2;
        if (index <= m)
          Update(2 * v, l, m, index, val);
        else
          Update(2 * v + 1, m + 1, r, index, val);
        sum[v] = sum[2 * v] + sum[2 * v + 1];
      }
    }

    private void Build(int[] nums, int v, int l, int r)
    {
      if (l == r)
      {
        sum[v] = nums[l];
      }
      else
      {
        var m = l + (r - l) / 2;
        Build(nums, 2 * v, l, m);
        Build(nums, 2 * v + 1, m + 1, r);
        sum[v] = sum[2 * v] + sum[2 * v + 1];
      }
    }

    public ArraySegmentTree(int[] nums)
    {
      sum = new int[4 * nums.Length];
      n = nums.Length;
      Build(nums, 1, 0, n - 1);
    }
  }
}

[TestFixture]
public class ArraySegmentTreeNumArrayTests
{
  [Test]
  public void Test1()
  {
    var numArray = new NumArray([1, 3, 5]);
    numArray.SumRange(0, 2).Should().Be(9);
    numArray.Update(1, 2);
    numArray.SumRange(0, 2).Should().Be(8);
  }

  [Test]
  public void Test2()
  {
    var numArray = new NumArray([0, 9, 5, 7, 3]);
    numArray.SumRange(4, 4).Should().Be(3);
    numArray.SumRange(2, 4).Should().Be(15);
    numArray.SumRange(3, 3).Should().Be(7);
    numArray.Update(4, 5);
    numArray.Update(1, 7);
    numArray.Update(0, 8);
    numArray.SumRange(1, 2).Should().Be(12);
    numArray.Update(1, 9);
    numArray.SumRange(4, 4).Should().Be(5);
    numArray.Update(3, 4);
  }
}
