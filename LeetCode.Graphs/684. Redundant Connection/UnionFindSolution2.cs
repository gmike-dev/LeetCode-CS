namespace LeetCode.Graphs._684._Redundant_Connection;

public class UnionFindSolution2
{
  public int[] FindRedundantConnection(int[][] edges)
  {
    var u = new UnionFind(1001);
    foreach (var e in edges)
    {
      if (!u.Union(e[0], e[1]))
        return e;
    }
    return null;
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

    private int Find(int x)
    {
      while (parent[x] != x)
      {
        parent[x] = parent[parent[x]];
        x = parent[x];
      }
      return x;
    }

    public bool Union(int x, int y)
    {
      x = Find(x);
      y = Find(y);
      if (x == y)
        return false;
      if (size[x] < size[y])
        (x, y) = (y, x);
      parent[y] = x;
      size[x] += size[y];
      return true;
    }
  }

}

[TestFixture]
public class UnionFindSolution2Tests
{
  [Test]
  public void Test1()
  {
    new UnionFindSolution2().FindRedundantConnection([[1, 2], [1, 3], [2, 3]]).Should().BeEquivalentTo([2, 3]);
  }

  [Test]
  public void Test2()
  {
    new UnionFindSolution2().FindRedundantConnection([[1, 2], [2, 3], [3, 4], [1, 4], [1, 5]]).Should().BeEquivalentTo([1, 4]);
  }
}
