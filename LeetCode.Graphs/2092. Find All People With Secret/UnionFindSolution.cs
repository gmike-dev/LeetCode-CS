namespace LeetCode.Graphs._2092._Find_All_People_With_Secret;

public class UnionFindSolution
{
  public IList<int> FindAllPeople(int n, int[][] meetings, int firstPerson)
  {
    Array.Sort(meetings, (x, y) => x[2] - y[2]);

    var uf = new UnionFind(n);
    uf.Union(0, firstPerson);

    for (var i = 0; i < meetings.Length;)
    {
      var time = meetings[i][2];
      var shares = new HashSet<int>();
      while (i < meetings.Length)
      {
        var m = meetings[i];
        var (u, v, t) = (m[0], m[1], m[2]);
        if (t != time)
          break;
        shares.Add(u);
        shares.Add(v);
        uf.Union(u, v);
        i++;
      }
      var root = uf.Find(0);
      foreach (var x in shares)
      {
        if (uf.Find(x) != root)
          uf.MakeSet(x);
      }
    }
    var result = new List<int>();
    var r = uf.Find(0);
    for (var i = 0; i < n; i++)
    {
      if (uf.Find(i) == r)
        result.Add(i);
    }
    return result;
  }

  private class UnionFind
  {
    private readonly int[] parent;
    private readonly int[] size;

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

    public void MakeSet(int i)
    {
      parent[i] = i;
      size[i] = 1;
    }

    public UnionFind(int n)
    {
      parent = new int[n];
      size = new int[n];
      for (var i = 0; i < n; i++)
        MakeSet(i);
    }
  }
}

[TestFixture]
public class UnionFindSolutionTests
{
  [Test]
  public void Test1()
  {
    new UnionFindSolution().FindAllPeople(6, [
        [1, 2, 5], [2, 3, 8], [1, 5, 10]
      ], 1)
      .Should().BeEquivalentTo([0, 1, 2, 3, 5]);
  }

  [Test]
  public void Test2()
  {
    new UnionFindSolution().FindAllPeople(4, [
        [3, 1, 3], [1, 2, 2], [0, 3, 3]
      ], 3)
      .Should().BeEquivalentTo([0, 1, 3]);
  }

  [Test]
  public void Test32()
  {
    new UnionFindSolution().FindAllPeople(6, [
        [0, 2, 1], [1, 3, 1], [4, 5, 1]
      ], 1)
      .Should().BeEquivalentTo([0, 1, 2, 3]);
  }

  [Test]
  public void Test39()
  {
    new UnionFindSolution().FindAllPeople(5, [
        [1, 4, 3], [0, 4, 3]
      ], 3)
      .Should().BeEquivalentTo([0, 1, 3, 4]);
  }
}
