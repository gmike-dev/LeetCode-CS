namespace LeetCode.Graphs._2685._Count_the_Number_of_Complete_Components;

public class UnionFindSolution
{
  public int CountCompleteComponents(int n, int[][] edges)
  {
    var indegree = new int[n];
    var uf = new UnionFind(n);
    foreach (var e in edges)
    {
      var u = e[0];
      var v = e[1];
      indegree[u]++;
      indegree[v]++;
      uf.Union(u, v);
    }
    var components = new HashSet<int>();
    for (var i = 0; i < n; i++)
      components.Add(uf.Find(i));
    for (var i = 0; i < n; i++)
    {
      if (indegree[i] + 1 != uf.Size(i))
        components.Remove(uf.Find(i));
    }
    return components.Count;
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
      if (x != y)
      {
        if (size[x] < size[y])
          (x, y) = (y, x);
        parent[y] = x; // Always add a smaller set to a larger set.
        size[x] += size[y];
      }
    }
  }
}

[TestFixture]
public class UnionFindSolutionTests
{
  [Test]
  public void Test1()
  {
    new UnionFindSolution()
      .CountCompleteComponents(6, [[0, 1], [0, 2], [1, 2], [3, 4]])
      .Should().Be(3);
  }

  [Test]
  public void Test2()
  {
    new UnionFindSolution()
      .CountCompleteComponents(6, [[0, 1], [0, 2], [1, 2], [3, 4], [3, 5]])
      .Should().Be(1);
  }

  [Test]
  public void Test3()
  {
    new UnionFindSolution()
      .CountCompleteComponents(4, [[1, 0], [2, 0], [3, 1], [3, 2]])
      .Should().Be(0);
  }
}
