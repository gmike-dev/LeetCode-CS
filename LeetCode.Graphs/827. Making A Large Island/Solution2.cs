namespace LeetCode.Graphs._827._Making_A_Large_Island;

public class Solution2
{
  public int LargestIsland(int[][] grid)
  {
    var n = grid.Length;
    var uf = new UnionFind2d(n, n);
    for (var i = 0; i < n; i++)
    {
      for (var j = 0; j < n; j++)
      {
        if (grid[i][j] == 0)
          continue;
        if (i > 0 && grid[i - 1][j] != 0)
          uf.Union(i, j, i - 1, j);
        if (j > 0 && grid[i][j - 1] != 0)
          uf.Union(i, j, i, j - 1);
      }
    }
    Span<int> d = [0, 1, 0, -1, 0];
    var largestIsland = 0;
    for (var i = 0; i < n; i++)
    {
      for (var j = 0; j < n; j++)
      {
        if (grid[i][j] == 0)
        {
          var size = 1;
          var connected = new HashSet<int>();
          for (var k = 0; k < 4; k++)
          {
            var x = i + d[k];
            var y = j + d[k + 1];
            if (x >= 0 && y >= 0 && x < n && y < n && grid[x][y] != 0 && connected.Add(uf.Find(x, y)))
              size += uf.Size(x, y);
          }
          largestIsland = Math.Max(largestIsland, size);
        }
        else
        {
          largestIsland = Math.Max(largestIsland, uf.Size(i, j));
        }
      }
    }
    return largestIsland;
  }

  private class UnionFind2d
  {
    private readonly int m;
    private readonly int[] parent;
    private readonly int[] size;

    public UnionFind2d(int n, int m)
    {
      this.m = m;
      parent = new int[n * m];
      size = new int[n * m];
      for (var i = 0; i < n * m; i++)
        MakeSet(i);
    }

    private void MakeSet(int p)
    {
      parent[p] = p;
      size[p] = 1;
    }

    public int Size(int x, int y)
    {
      return size[Find(x, y)];
    }

    public int Find(int x, int y)
    {
      var p = m * x + y;
      while (parent[p] != p)
      {
        parent[p] = parent[parent[p]];
        p = parent[p];
      }
      return p;
    }

    public void Union(int x1, int y1, int x2, int y2)
    {
      var p1 = Find(x1, y1);
      var p2 = Find(x2, y2);
      if (p1 == p2)
        return;
      if (size[p1] < size[p2])
        (p1, p2) = (p2, p1);
      parent[p2] = p1;
      size[p1] += size[p2];
    }
  }
}

[TestFixture]
public class Solution2Tests
{
  [Test]
  public void Test1()
  {
    new Solution2().LargestIsland([[1, 0], [0, 1]]).Should().Be(3);
  }

  [Test]
  public void Test2()
  {
    new Solution2().LargestIsland([[1, 1], [1, 0]]).Should().Be(4);
  }

  [Test]
  public void Test3()
  {
    new Solution2().LargestIsland([[1, 1], [1, 1]]).Should().Be(4);
  }
}
