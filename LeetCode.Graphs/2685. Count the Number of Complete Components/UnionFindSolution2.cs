namespace LeetCode.Graphs._2685._Count_the_Number_of_Complete_Components;

public class UnionFindSolution2
{
  public int CountCompleteComponents(int n, int[][] edges)
  {
    Span<int> parent = stackalloc int[n];
    Span<int> size = stackalloc int[n];
    var uf = new UnionFind(parent, size);
    foreach (var e in edges)
    {
      var u = e[0];
      var v = e[1];
      uf.Union(u, v);
    }
    var componentEdges = new Dictionary<int, int>();
    foreach (var e in edges)
    {
      var component = uf.Find(e[0]);
      componentEdges[component] = componentEdges.GetValueOrDefault(component) + 1;
    }
    var completeComponentsCount = 0;
    for (var i = 0; i < n; i++)
    {
      if (uf.Find(i) == i)
      {
        var componentSize = uf.Size(i);
        var edgesCount = componentEdges.GetValueOrDefault(i);
        var expectedCount = componentSize * (componentSize - 1) / 2;
        if (edgesCount == expectedCount)
          completeComponentsCount++;
      }
    }
    return completeComponentsCount;
  }

  private readonly ref struct UnionFind
  {
    private readonly Span<int> parent;
    private readonly Span<int> size;

    public UnionFind(Span<int> parent, Span<int> size)
    {
      this.parent = parent;
      this.size = size;
      for (var i = 0; i < size.Length; i++)
        MakeSet(i);
    }

    private void MakeSet(int x)
    {
      parent[x] = x;
      size[x] = 1;
    }

    public int Size(int x)
    {
      return size[x];
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
public class UnionFindSolution2Tests
{
  [Test]
  public void Test1()
  {
    new UnionFindSolution2()
      .CountCompleteComponents(6, [[0, 1], [0, 2], [1, 2], [3, 4]])
      .Should().Be(3);
  }

  [Test]
  public void Test2()
  {
    new UnionFindSolution2()
      .CountCompleteComponents(6, [[0, 1], [0, 2], [1, 2], [3, 4], [3, 5]])
      .Should().Be(1);
  }

  [Test]
  public void Test3()
  {
    new UnionFindSolution2()
      .CountCompleteComponents(4, [[1, 0], [2, 0], [3, 1], [3, 2]])
      .Should().Be(0);
  }
}
