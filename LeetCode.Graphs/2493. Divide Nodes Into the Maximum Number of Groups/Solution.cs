namespace LeetCode.Graphs._2493._Divide_Nodes_Into_the_Maximum_Number_of_Groups;

public class Solution
{
  public int MagnificentSets(int n, int[][] edges)
  {
    var uf = new UnionFind(n);
    var g = new List<int>[n];
    for (var i = 0; i < n; i++)
      g[i] = [];
    foreach (var e in edges)
    {
      uf.Union(e[0] - 1, e[1] - 1);
      g[e[0] - 1].Add(e[1] - 1);
      g[e[1] - 1].Add(e[0] - 1);
    }
    Span<int> maxInGroup = stackalloc int[n];
    for (var i = 0; i < n; i++)
    {
      var count = Bfs(i);
      if (count == -1)
        return -1;
      var group = uf.Find(i);
      maxInGroup[group] = Math.Max(maxInGroup[group], count);
    }
    var totalSets = 0;
    foreach (var count in maxInGroup)
      totalSets += count;
    return totalSets;

    int Bfs(int start)
    {
      var q = new Queue<int>();
      Span<int> depth = stackalloc int[n];
      depth.Fill(-1);
      q.Enqueue(start);
      depth[start] = 0;
      var currentDepth = 0;
      while (q.Count != 0)
      {
        var count = q.Count;
        for (var i = 0; i < count; i++)
        {
          var v = q.Dequeue();
          foreach (var nv in g[v])
          {
            if (depth[nv] == currentDepth)
              return -1;
            if (depth[nv] == -1)
            {
              depth[nv] = currentDepth + 1;
              q.Enqueue(nv);
            }
          }
        }
        currentDepth++;
      }
      return currentDepth;
    }
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
    new Solution().MagnificentSets(6, [[1, 2], [1, 4], [1, 5], [2, 6], [2, 3], [4, 6]]).Should().Be(4);
  }

  [Test]
  public void Test2()
  {
    new Solution().MagnificentSets(3, [[1, 2], [2, 3], [3, 1]]).Should().Be(-1);
  }
}
