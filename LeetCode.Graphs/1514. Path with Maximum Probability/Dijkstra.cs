namespace LeetCode.Graphs._1514._Path_with_Maximum_Probability;

public class Solution
{
  public double MaxProbability(int n, int[][] edges, double[] succProb, int startNode, int endNode)
  {
    var g = new List<(int, double)>[n];
    for (var i = 0; i < n; i++)
      g[i] = [];
    for (var i = 0; i < edges.Length; i++)
    {
      var edge = edges[i];
      g[edge[0]].Add((edge[1], succProb[i]));
      g[edge[1]].Add((edge[0], succProb[i]));
    }
    var maxProbability = new double[n];
    maxProbability[startNode] = 1.0;
    var q = new PriorityQueue<int, double>();
    q.Enqueue(startNode, 1.0);
    while (q.TryDequeue(out var node, out var prob) && node != endNode)
    {
      foreach (var (nextNode, nextProb) in g[node])
      {
        var probability = Math.Abs(prob) * nextProb;
        if (probability > maxProbability[nextNode])
        {
          maxProbability[nextNode] = probability;
          q.Enqueue(nextNode, -probability);
        }
      }
    }
    return maxProbability[endNode];
  }
}

[TestFixture]
public class DijkstraTests
{
  [Test]
  public void Test1()
  {
    new Solution()
      .MaxProbability(3, [[0, 1], [1, 2], [0, 2]], [0.5, 0.5, 0.3], 0, 2)
      .Should().Be(0.3);
  }

  [Test]
  public void Test2()
  {
    new Solution()
      .MaxProbability(3, [[0,1]], [0.5], 0, 2)
      .Should().Be(0.0);
  }
}
