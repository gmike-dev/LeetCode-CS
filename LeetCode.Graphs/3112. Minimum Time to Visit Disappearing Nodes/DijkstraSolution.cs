namespace LeetCode.Graphs._3112._Minimum_Time_to_Visit_Disappearing_Nodes;

public class DijkstraSolution
{
  public int[] MinimumTime(int n, int[][] edges, int[] disappear)
  {
    var g = new List<(int v, int len)>[n];
    for (var i = 0; i < n; i++)
      g[i] = [];
    foreach (var e in edges)
    {
      g[e[0]].Add((e[1], e[2]));
      g[e[1]].Add((e[0], e[2]));
    }

    var next = new PriorityQueue<int, int>();
    next.Enqueue(0, 0);

    var time = new int[n];
    Array.Fill(time, -1);
    time[0] = 0;

    while (next.TryDequeue(out var v, out var t))
    {
      if (t != time[v])
        continue;
      foreach (var to in g[v])
      {
        var arriveTime = t + to.len;
        if (arriveTime < disappear[to.v] && (time[to.v] == -1 || arriveTime < time[to.v]))
        {
          next.Enqueue(to.v, arriveTime);
          time[to.v] = arriveTime;
        }
      }
    }
    return time;
  }
}

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new DijkstraSolution()
      .MinimumTime(3, [[0, 1, 2], [1, 2, 1], [0, 2, 4]], [1, 1, 5])
      .Should()
      .BeEquivalentTo([0, -1, 4], o => o.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    new DijkstraSolution()
      .MinimumTime(3, [[0, 1, 2], [1, 2, 1], [0, 2, 4]], [1, 3, 5])
      .Should()
      .BeEquivalentTo([0, 2, 3], o => o.WithStrictOrdering());
  }

  [Test]
  public void Test3()
  {
    new DijkstraSolution()
      .MinimumTime(2, [[0, 1, 1]], [1, 1])
      .Should()
      .BeEquivalentTo([0, -1], o => o.WithStrictOrdering());
  }
}
