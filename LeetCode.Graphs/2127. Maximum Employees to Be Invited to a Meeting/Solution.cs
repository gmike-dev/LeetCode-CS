namespace LeetCode.Graphs._2127._Maximum_Employees_to_Be_Invited_to_a_Meeting;

public class Solution
{
  public int MaximumInvitations(int[] favorite)
  {
    var n = favorite.Length;
    var g = new List<int>[n];
    for (var i = 0; i < n; i++)
      g[i] = [];
    for (var i = 0; i < n; i++)
      g[favorite[i]].Add(i);

    var maxCycleLength = 0;
    var longestChainLength = 0;
    Span<bool> visited = stackalloc bool[n];
    for (var i = 0; i < n; i++)
    {
      if (visited[i])
        continue;
      Dictionary<int, int> chainLength = new() { [i] = 1 };
      for (var v = i; !visited[v]; v = favorite[v])
      {
        visited[v] = true;
        if (chainLength.ContainsKey(favorite[v]))
        {
          var cycleLength = chainLength[v] - chainLength[favorite[v]] + 1;
          maxCycleLength = Math.Max(maxCycleLength, cycleLength);
          if (cycleLength == 2)
          {
            HashSet<int> visitedOutOfCycle = [v, favorite[v]];
            longestChainLength += 2 + MaxDepth(v, visitedOutOfCycle) + MaxDepth(favorite[v], visitedOutOfCycle);
          }
          break;
        }
        chainLength[favorite[v]] = chainLength[v] + 1;
      }
    }
    return Math.Max(maxCycleLength, longestChainLength);

    int MaxDepth(int start, HashSet<int> visited)
    {
      var q = new Queue<int>();
      q.Enqueue(start);
      var depth = -1;
      while (q.Count != 0)
      {
        var initialCount = q.Count;
        for (var i = 0; i < initialCount; i++)
        {
          var v = q.Dequeue();
          foreach (var nv in g[v])
          {
            if (visited.Add(nv))
              q.Enqueue(nv);
          }
        }
        depth++;
      }
      return depth;
    }
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { 2, 2, 1, 2 }, 3)]
  [TestCase(new[] { 1, 2, 0 }, 3)]
  [TestCase(new[] { 3, 0, 1, 4, 1 }, 4)]
  [TestCase(new[] { 1, 0 }, 2)]
  [TestCase(new[] { 1, 2, 3, 4, 5, 6, 3, 8, 9, 10, 11, 8 }, 4)]
  [TestCase(new[] { 1, 0, 3, 2, 5, 6, 7, 4, 9, 8, 11, 10, 11, 12, 10 }, 11)]
  public void Test(int[] favorite, int expected)
  {
    new Solution().MaximumInvitations(favorite).Should().Be(expected);
  }
}
