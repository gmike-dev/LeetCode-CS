using LeetCode.Common;

namespace LeetCode.Numbers._952._Largest_Component_Size_by_Common_Factor;

public class Solution
{
  public int LargestComponentSize(int[] nums)
  {
    int m = nums.Max();
    UnionFind uf = new(m + 1);
    foreach (var num in nums)
    {
      int x = num;
      for (int p = 2; p * p <= x; p++)
      {
        if (x % p == 0)
        {
          uf.Union(num, p);
          while (x % p == 0)
          {
            x /= p;
          }
        }
      }
      if (x > 1)
      {
        uf.Union(num, x);
      }
    }

    int[] count = new int[m + 1];
    foreach (var num in nums)
    {
      count[uf.Find(num)]++;
    }

    return count.Max();
  }

  private class UnionFind
  {
    private readonly int[] parent;
    private readonly int[] size;

    private void MakeSet(int x)
    {
      parent[x] = x;
      size[x] = 1;
    }

    public int GetMaxSize()
    {
      int max = int.MinValue;
      foreach (var i in size)
        max = Math.Max(max, i);
      return max;
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
        parent[y] = x;
        size[x] += size[y];
      }
    }

    public UnionFind(int n)
    {
      parent = new int[n];
      size = new int[n];
      for (int i = 0; i < n; i++)
        MakeSet(i);
    }
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("[20,50,9,63]", 2)]
  [TestCase("[2,3,6,7,4,12,21,39]", 8)]
  public void Test(string nums, int expected)
  {
    new Solution().LargestComponentSize(nums.Array()).Should().Be(expected);
  }
}
