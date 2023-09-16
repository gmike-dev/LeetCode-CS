using System;
using System.Collections.Generic;

namespace LeetCode._1631._Path_With_Minimum_Effort;

public class DijkstraSolution
{
  public int MinimumEffortPath(int[][] heights)
  {
    var dir = new (int x, int y)[] { (-1, 0), (1, 0), (0, 1), (0, -1) };
    var n = heights.Length;
    var m = heights[0].Length;
    var effort = new int[n][];
    for (var i = 0; i < n; i++)
    {
      effort[i] = new int[m];
      effort[i].AsSpan().Fill(int.MaxValue);
    }
    effort[0][0] = 0;
    
    var used = new bool[n][];
    for (var i = 0; i < n; i++)
      used[i] = new bool[m];
    
    var next = new PriorityQueue<(int x, int y), int>();
    next.Enqueue((0, 0), 0);
    while (next.TryDequeue(out var p, out var e))
    {
      var (x, y) = p;
      if (e != effort[x][y])
        continue;
      if (x == n - 1 && y == m - 1)
        break;
      used[x][y] = true;
      foreach (var (dr, dc) in dir)
      {
        var (nx, ny) = (x + dr, y + dc);
        if (nx >= 0 && nx < n && ny >= 0 && ny < m && !used[nx][ny])
        {
          var ne = Math.Max(effort[x][y], Math.Abs(heights[nx][ny] - heights[x][y]));
          if (ne < effort[nx][ny])
          {
            next.Enqueue((nx, ny), ne);
            effort[nx][ny] = ne;
          }
        }
      }
    }
    return effort[n - 1][m - 1];
  }
}