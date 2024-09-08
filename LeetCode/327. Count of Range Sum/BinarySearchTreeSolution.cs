namespace LeetCode._327._Count_of_Range_Sum;

public class BinarySearchTreeSolution
{
  public int CountRangeSum(int[] nums, int lower, int upper)
  {
    var n = nums.Length;
    var s = new long[n];
    s[0] = nums[0];
    for (var i = 1; i < n; i++)
      s[i] = s[i - 1] + nums[i];
    var sorted = new long[n];
    s.AsSpan().CopyTo(sorted);
    Array.Sort(sorted);
    var bst = new Bst(sorted);
    var count = 0;
    long d = 0;
    for (var i = 0; i < n; i++)
    {
      count += bst.CountLessThan(upper + d + 1) - bst.CountLessThan(lower + d);
      bst.Remove(s[i]);
      d = s[i];
    }
    return count;
  }

  private class Bst(long[] sorted)
  {
    private BstNode root = new(sorted, 0, sorted.Length - 1, null);

    public int CountLessThan(long value)
    {
      return CountLessThan(root, value);
    }

    private int CountLessThan(BstNode node, long value)
    {
      while (true)
      {
        if (node == null)
          return 0;
        if (node.value >= value)
        {
          node = node.left;
          continue;
        }
        var count = 1;
        if (node.left != null)
          count += node.left.count;
        return count + CountLessThan(node.right, value);
      }
    }

    public void Remove(long value)
    {
      var node = Find(root, value);
      Delete(node);
      while (node.parent != null)
      {
        node = node.parent;
        node.count--;
      }
    }

    private BstNode Find(BstNode node, long value)
    {
      while (true)
      {
        if (node is null)
          return null;
        if (node.value == value)
          return node;
        if (value < node.value)
          node = node.left;
        else
          node = node.right;
      }
    }

    private void Delete(BstNode z)
    {
      if (z.left == null)
      {
        Transplant(z, z.right);
      }
      else if (z.right == null)
      {
        Transplant(z, z.left);
      }
      else
      {
        var y = Minimum(z.right);

        var p = y.parent;
        while (p != z)
        {
          p.count--;
          p = p.parent;
        }

        if (y.parent != z)
        {
          Transplant(y, y.right);
          y.right = z.right;
          y.right.parent = y;
        }
        Transplant(z, y);
        y.left = z.left;
        y.left.parent = y;

        y.count = 1;
        if (y.left != null)
          y.count += y.left.count;
        if (y.right != null)
          y.count += y.right.count;
      }
    }

    private BstNode Minimum(BstNode x)
    {
      while (x.left != null)
        x = x.left;
      return x;
    }

    private void Transplant(BstNode u, BstNode v)
    {
      if (u.parent == null)
        root = v;
      else if (u == u.parent.left)
        u.parent.left = v;
      else
        u.parent.right = v;
      if (v != null)
        v.parent = u.parent;
    }

    private class BstNode
    {
      public BstNode parent;
      public BstNode left;
      public BstNode right;
      public long value;
      public int count;

      public BstNode(long[] sorted, int l, int r, BstNode parent)
      {
        this.parent = parent;
        if (l < r)
        {
          var m = l + (r - l) / 2;
          value = sorted[m];
          count = r - l + 1;
          if (l < m)
            left = new BstNode(sorted, l, m - 1, this);
          if (m < r)
            right = new BstNode(sorted, m + 1, r, this);
        }
        else
        {
          value = sorted[l];
          count = 1;
        }
      }
    }
  }
}

[TestFixture]
public class BinarySearchTreeSolutionTests
{
  [TestCase(new[] { -2, 5, -1 }, -2, 2, 3)]
  [TestCase(new[] { 0 }, 0, 0, 1)]
  [TestCase(new[] { 2147483647, -2147483648, -1, 0 }, -1, 0, 4)]
  [TestCase(new[] { 10, -10, -1, 0 }, -1, 0, 6)]
  [TestCase(new[] { 10, -11, -1, 0 }, -1, 0, 4)]
  [TestCase(new[] { -2, 0, -2, -3, 2, 2, 1, -3, 4 }, 4, 11, 5)]
  [TestCase(new[] { 0, 0, -3, 2, -2, -2 }, -3, 1, 16)]
  [TestCase(new[] { -4, 0, -3, -1, 1, 2, 1, -4 }, 0, 6, 13)]
  public void Test(int[] nums, int lower, int upper, int expected)
  {
    new BinarySearchTreeSolution().CountRangeSum(nums, lower, upper).Should().Be(expected);
  }

  [Test]
  public void Test_LargeData()
  {
    var random = new Random();
    var nums = Enumerable.Range(0, 100000).Select(i => random.Next(-10000, 10000)).ToArray();
    new BinarySearchTreeSolution().ExecutionTimeOf(s => s.CountRangeSum(nums, -10000, 10000))
      .Should().BeLessThan(TimeSpan.FromSeconds(2));
  }
}
