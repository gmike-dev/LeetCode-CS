namespace LeetCode.Graphs._684._Redundant_Connection;

public class UnionFindSolution
{
  public int[] FindRedundantConnection(int[][] edges)
  {
    var u = CreateUnionFind(1001);
    foreach (var e in edges)
    {
      if (!Union(u, e[0], e[1]))
        return e;
    }
    return null;
  }

  private static int[] CreateUnionFind(int n)
  {
    var u = new int[n];
    for (var i = 0; i < u.Length; i++)
      u[i] = i;
    return u;
  }

  private static int Find(int[] u, int x)
  {
    while (u[x] != x)
      x = u[x];
    return x;
  }

  private static bool Union(int[] u, int x, int y)
  {
    var px = Find(u, x);
    var py = Find(u, y);
    if (px == py)
      return false;
    u[px] = py;
    return true;
  }
}

[TestFixture]
public class UnionFindSolutionTests
{
  [Test]
  public void Test1()
  {
    new UnionFindSolution().FindRedundantConnection([[1, 2], [1, 3], [2, 3]]).Should().BeEquivalentTo([2, 3]);
  }

  [Test]
  public void Test2()
  {
    new UnionFindSolution().FindRedundantConnection([[1, 2], [2, 3], [3, 4], [1, 4], [1, 5]]).Should().BeEquivalentTo([1, 4]);
  }
}
