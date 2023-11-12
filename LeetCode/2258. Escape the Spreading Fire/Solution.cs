using System;
using System.Collections.Generic;

namespace LeetCode._2258._Escape_the_Spreading_Fire;

public class Solution
{
  public int MaximumMinutes(int[][] grid)
  {
    var m = grid.Length;
    var n = grid[0].Length;

    var humanCells = new List<(int, int)> { (0, 0) };
    var fireCells = new List<(int, int)>();
    for (var i = 0; i < m; i++)
    for (var j = 0; j < n; j++)
    {
      if (grid[i][j] == 1)
        fireCells.Add((i, j));
    }

    var fireTime = Bfs(grid, fireCells);
    var humanTime = Bfs(grid, humanCells);

    if (humanTime[^1][^1] == -1)
      return -1;
    if (fireTime[^1][^1] == -1)
      return (int)1e9;
    var advance = fireTime[^1][^1] - humanTime[^1][^1];
    if (advance < 0)
      return -1;
    var humanPrevTop = humanTime[^2][^1];
    var humanPrevLeft = humanTime[^1][^2];
    var firePrevTop = fireTime[^2][^1];
    var firePrevLeft = fireTime[^1][^2];
    if (humanPrevTop != -1 && humanPrevLeft != -1 &&
        (firePrevTop - humanPrevTop > advance || firePrevLeft - humanPrevLeft > advance))
      return advance;
    return advance - 1;
  }

  private static int[][] Bfs(int[][] grid, List<(int row, int col)> startPoints)
  {
    var m = grid.Length;
    var n = grid[0].Length;
    var time = CreateGrid(m, n, -1);
    var q = new Queue<(int row, int col)>(startPoints);
    foreach (var point in startPoints)
      time[point.row][point.col] = 0;
    (int, int)[] d = { (-1, 0), (0, -1), (0, 1), (1, 0) };
    while (q.Count > 0)
    {
      var (row, col) = q.Dequeue();
      foreach (var (dr, dc) in d)
      {
        var (r, c) = (row + dr, col + dc);
        if (r < 0 || c < 0 || r >= m || c >= n || grid[r][c] != 0 || time[r][c] != -1)
          continue;
        time[r][c] = time[row][col] + 1;
        q.Enqueue((r, c));
      }
    }
    return time;
  }

  private static T[][] CreateGrid<T>(int m, int n, T fillValue)
  {
    var grid = new T[m][];
    for (var i = 0; i < m; i++)
    {
      grid[i] = new T[n];
      Array.Fill(grid[i], fillValue);
    }
    return grid;
  }
}