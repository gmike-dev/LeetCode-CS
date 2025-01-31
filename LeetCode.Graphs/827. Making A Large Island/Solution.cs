namespace LeetCode.Graphs._827._Making_A_Large_Island;

public class Solution
{
  public int LargestIsland(int[][] grid)
  {
    var n = grid.Length;
    var uf = new UnionFind(n * n);
    for (var i = 0; i < n; i++)
    {
      for (var j = 0; j < n; j++)
      {
        if (grid[i][j] == 0)
          continue;
        var p = n * i + j;
        if (i > 0 && grid[i - 1][j] != 0)
          uf.Union(p, p - n);
        if (j > 0 && grid[i][j - 1] != 0)
          uf.Union(p, p - 1);
      }
    }
    var largestIsland = 0;
    for (var i = 0; i < n; i++)
    {
      for (var j = 0; j < n; j++)
      {
        var p = n * i + j;
        if (grid[i][j] == 0)
        {
          var size = 1;
          var connected = new HashSet<int>();
          if (j > 0 && grid[i][j - 1] != 0 && connected.Add(uf.Find(p - 1)))
            size += uf.Size(p - 1);
          if (j + 1 < n && grid[i][j + 1] != 0 && connected.Add(uf.Find(p + 1)))
            size += uf.Size(p + 1);
          if (i > 0 && grid[i - 1][j] != 0 && connected.Add(uf.Find(p - n)))
            size += uf.Size(p - n);
          if (i + 1 < n && grid[i + 1][j] != 0 && connected.Add(uf.Find(p + n)))
            size += uf.Size(p + n);
          largestIsland = Math.Max(largestIsland, size);
        }
        else
        {
          largestIsland = Math.Max(largestIsland, uf.Size(p));
        }
      }
    }
    return largestIsland;
  }

  private class UnionFind
  {
    private readonly int[] parent;
    private readonly int[] size;

    public UnionFind(int n)
    {
      parent = new int[n];
      size = new int[n];
      for (var i = 0; i < n; i++)
        MakeSet(i);
    }

    private void MakeSet(int x)
    {
      parent[x] = x;
      size[x] = 1;
    }

    public int Size(int x)
    {
      return size[Find(x)];
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
      if (x == y)
        return;
      if (size[x] < size[y])
        (x, y) = (y, x);
      parent[y] = x;
      size[x] += size[y];
    }
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    new Solution().LargestIsland([[1, 0], [0, 1]]).Should().Be(3);
  }

  [Test]
  public void Test2()
  {
    new Solution().LargestIsland([[1, 1], [1, 0]]).Should().Be(4);
  }

  [Test]
  public void Test3()
  {
    new Solution().LargestIsland([[1, 1], [1, 1]]).Should().Be(4);
  }
}
