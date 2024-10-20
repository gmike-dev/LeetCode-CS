namespace LeetCode.Graphs._1971._Find_if_Path_Exists_in_Graph;

public class UnionFindSolution
{
  public bool ValidPath(int n, int[][] edges, int source, int destination)
  {
    if (source == destination)
      return true;

    var uf = new UnionFind(n);
    foreach (var e in edges)
      uf.Union(e[0], e[1]);

    return uf.Find(source) == uf.Find(destination);
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
    new UnionFindSolution().ValidPath(3, [[0, 1], [1, 2], [2, 0]], 0, 2).Should().BeTrue();
  }

  [Test]
  public void Test2()
  {
    new UnionFindSolution().ValidPath(6, [[0, 1], [0, 2], [3, 5], [5, 4], [4, 3]], 0, 5).Should().BeFalse();
  }

  [Test]
  public void Test3()
  {
    new UnionFindSolution().ValidPath(1, [], 0, 0).Should().BeTrue();
  }
}
