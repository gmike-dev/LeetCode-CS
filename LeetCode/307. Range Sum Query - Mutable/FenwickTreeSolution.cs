namespace LeetCode._307._Range_Sum_Query___Mutable.FenwickTreeSolution;

public class NumArray(int[] nums)
{
  private readonly FenwickTree fenwickTree = new(nums);

  public void Update(int index, int val)
  {
    fenwickTree.Update(index, val);
  }

  public int SumRange(int left, int right)
  {
    return fenwickTree.SumRange(left, right);
  }

  private class FenwickTree
  {
    private readonly int[] source;
    private readonly int[] t;

    public int SumRange(int l, int r)
    {
      return Sum(r) - Sum(l - 1);
    }

    private int Sum(int r)
    {
      var s = 0;
      for (; r >= 0; r = (r & (r + 1)) - 1)
        s += t[r];
      return s;
    }

    public void Update(int index, int value)
    {
      Add(index, value - source[index]);
      source[index] = value;
    }

    private void Add(int index, int value)
    {
      for (; index < t.Length; index |= index + 1)
        t[index] += value;
    }

    public FenwickTree(int[] nums)
    {
      source = nums;
      t = new int[nums.Length];
      for (var i = 0; i < nums.Length; i++)
        Add(i, nums[i]);
    }
  }
}

[TestFixture]
public class FenwickTreeNumArrayTests
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
