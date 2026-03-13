namespace LeetCode._307._Range_Sum_Query___Mutable;

public class NumArray
{
  private readonly int[] tree;
  private readonly int[] a;
  private readonly int n;

  public NumArray(int[] nums)
  {
    n = nums.Length;
    a = new int[n];
    tree = new int[n + 1];

    for (int i = 0; i < n; i++)
    {
      Update(i, nums[i]);
    }
  }

  public void Update(int index, int val)
  {
    int diff = val - a[index];
    a[index] = val;
    UpdateTree(index + 1, diff);
  }

  private void UpdateTree(int index, int val)
  {
    while (index <= n)
    {
      tree[index] += val;
      index += index & -index;
    }
  }

  public int SumRange(int left, int right)
  {
    return Query(right + 1) - Query(left);
  }

  private int Query(int index)
  {
    int s = 0;
    while (index > 0)
    {
      s += tree[index];
      index -= index & -index;
    }
    return s;
  }
}

[TestFixture]
public class NumArrayTests
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
