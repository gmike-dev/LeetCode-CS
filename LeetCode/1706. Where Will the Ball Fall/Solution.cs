using System.Linq;

namespace LeetCode._1706._Where_Will_the_Ball_Fall;

public class Solution
{
  public int[] FindBall(int[][] grid)
  {
    var n = grid[0].Length;
    return Enumerable.Range(0, n).Select(CalcPos).ToArray();

    int CalcPos(int pos)
    {
      foreach (var row in grid)
      {
        var newPos = pos + row[pos];
        if (newPos < 0 || newPos == n || newPos + row[newPos] == pos)
          return -1;
        pos = newPos;
      }
      return pos;
    }
  }
}