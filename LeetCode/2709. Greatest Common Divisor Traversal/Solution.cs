namespace LeetCode._2709._Greatest_Common_Divisor_Traversal;

public class Solution
{
  public bool CanTraverseAllPairs(int[] nums)
  {
    if (nums.Length == 1 && nums[0] == 1)
      return true; // First nasty case with 1.
    var n = 0;
    foreach (var x in nums)
    {
      if (x == 1)
        return false; // Second nasty case with 1.
      n = Math.Max(x, n);
    }
    var exists = new bool[n + 1];
    foreach (var x in nums)
      exists[x] = true;
    var u = new UnionFind(n + 1);
    for (var i = 2; i <= n; i++)
      u.MakeSet(i);
    var prime = new bool[n + 1];
    for (var i = 2; i <= n; i++)
    {
      if (!prime[i])
      {
        prime[i] = true;
        for (var j = i + i; j <= n; j += i)
        {
          if (exists[j])
            u.Union(i, j);
        }
      }
    }
    return nums.DistinctBy(u.Find).Count() == 1;
  }

  private class UnionFind
  {
    private readonly int[] parent;
    private readonly int[] size;
    public void MakeSet(int x)
    {
      parent[x] = x;
      size[x] = 1;
    }

    public int Find(int x)
    {
      while (parent[x] != x)
      {
        parent[x] = parent[parent[x]];
        x = parent[x];
      }
      return x;
    }

    public void Union(int x, int y)
    {
      x = Find(x);
      y = Find(y);
      if (x != y)
      {
        if (size[x] < size[y])
          (x, y) = (y, x);
        parent[y] = x; // Always add a smaller set to a larger set.
        size[x] += size[y];
      }
    }

    public UnionFind(int n)
    {
      parent = new int[n];
      size = new int[n];
    }
  }
}

[TestFixture]
public class Tests
{
  [TestCase(new[] { 2, 3, 6 }, true)]
  [TestCase(new[] { 3, 9, 5 }, false)]
  [TestCase(new[] { 4, 3, 12, 8 }, true)]
  [TestCase(new[] { 20, 6 }, true)]
  [TestCase(new[] { 28, 39 }, false)]
  [TestCase(new[] { 42, 40, 45, 42, 50, 33, 30, 45, 33, 45, 30, 36, 44, 1, 21, 10, 40, 42, 42 }, false)]
  [TestCase(new[] { 10 }, true)]
  [TestCase(new[] { 1, 1 }, false)]
  [TestCase(new[] { 1 }, true)]
  public void Test(int[] nums, bool expected)
  {
    new Solution().CanTraverseAllPairs(nums).Should().Be(expected);
  }
}
