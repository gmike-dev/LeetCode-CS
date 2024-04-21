namespace LeetCode.__Graphs._1971._Find_if_Path_Exists_in_Graph;

public class BfsSolution
{
  public bool ValidPath(int n, int[][] edges, int source, int destination)
  {
    if (source == destination)
      return true;
    var g = new List<int>[n];
    foreach (var e in edges)
    {
      (g[e[0]] ??= []).Add(e[1]);
      (g[e[1]] ??= []).Add(e[0]);
    }
    var q = new Queue<int>();
    var used = new bool[n];
    q.Enqueue(source);
    used[source] = true;
    while (q.Count > 0)
    {
      var v = q.Dequeue();
      if (g[v] == null)
        continue;
      foreach (var to in g[v])
      {
        if (to == destination)
          return true;
        if (!used[to])
        {
          q.Enqueue(to);
          used[to] = true;
        }
      }
    }
    return false;
  }
}

[TestFixture]
public class BfsSolutionTests
{
  [Test]
  public void Test1()
  {
    new BfsSolution().ValidPath(3, [[0, 1], [1, 2], [2, 0]], 0, 2).Should().BeTrue();
  }

  [Test]
  public void Test2()
  {
    new BfsSolution().ValidPath(6, [[0, 1], [0, 2], [3, 5], [5, 4], [4, 3]], 0, 5).Should().BeFalse();
  }

  [Test]
  public void Test3()
  {
    new BfsSolution().ValidPath(1, [], 0, 0).Should().BeTrue();
  }
}
