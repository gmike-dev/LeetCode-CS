using System.Collections.Generic;

namespace LeetCode._847._Shortest_Path_Visiting_All_Nodes;

public class Solution
{
  public int ShortestPathLength(int[][] graph)
  {
    var n = graph.Length;
    var q = new Queue<(int state, int v, int dist)>();
    var used = new HashSet<(int, int)>();
    for (var i = 0; i < n; i++)
      q.Enqueue((1 << i, i, 0));
    while (q.Count > 0)
    {
      var (state, v, dist) = q.Dequeue();
      if (state == (1 << n) - 1)
        return dist;
      for (var i = 0; i < graph[v].Length; i++)
      {
        var next = graph[v][i];
        var nextState = state | (1 << next);
        if (!used.Contains((nextState, next)))
        {
          used.Add((nextState, next));
          q.Enqueue((nextState, next, dist + 1));
        }
      }
    }
    return -1;
  }
}