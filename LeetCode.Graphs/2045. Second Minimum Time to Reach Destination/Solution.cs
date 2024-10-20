namespace LeetCode.Graphs._2045._Second_Minimum_Time_to_Reach_Destination;

public class Solution
{
  public int SecondMinimum(int n, int[][] edges, int time, int change)
  {
    var g = new List<int>[n + 1];
    for (var i = 0; i < n + 1; i++)
      g[i] = [];
    foreach (var edge in edges)
    {
      g[edge[0]].Add(edge[1]);
      g[edge[1]].Add(edge[0]);
    }
    var q = new Queue<(int, int)>();
    var minDist = new int[n + 1];
    var secondDist = new int[n + 1];
    minDist.AsSpan().Fill(-1);
    secondDist.AsSpan().Fill(-1);
    q.Enqueue((1, 1));
    minDist[1] = 0;
    while (q.Count != 0)
    {
      var (v, freq) = q.Dequeue();
      var dist = freq == 1 ? minDist[v] : secondDist[v];
      if (dist / change % 2 == 0)
        dist += time;
      else
        dist = change * (dist / change + 1) + time;
      foreach (var next in g[v])
      {
        if (minDist[next] == -1)
        {
          minDist[next] = dist;
          q.Enqueue((next, 1));
        }
        else if (secondDist[next] == -1 && dist != minDist[next])
        {
          if (next == n)
            return dist;
          secondDist[next] = dist;
          q.Enqueue((next, 2));
        }
      }
    }
    return 0;
  }
}

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().SecondMinimum(5, [[1, 2], [1, 3], [1, 4], [3, 4], [4, 5]], 3, 5).Should().Be(13);
  }

  [Test]
  public void Test2()
  {
    new Solution().SecondMinimum(2, [[1, 2]], 3, 2).Should().Be(11);
  }

  [Test]
  public void Test3()
  {
    new Solution().SecondMinimum(6, [[1, 2], [1, 3], [2, 4], [3, 5], [5, 4], [4, 6]], 3, 100).Should().Be(12);
  }

  [Test]
  public void Test4()
  {
    new Solution().SecondMinimum(2, [[1, 2]], 1, 2).Should().Be(5);
  }
}
