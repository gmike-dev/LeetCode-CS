namespace LeetCode._542._01_Matrix;

public class Solution
{
  private static readonly int[,] Dir = { { 0, -1 }, { 0, 1 }, { -1, 0 }, { 1, 0 } };

  public int[][] UpdateMatrix(int[][] mat)
  {
    var m = mat.Length;
    var n = mat[0].Length;
    var result = new int[m][];
    for (var i = 0; i < m; i++)
      result[i] = new int[n];
    var q = new Queue<(int, int)>();

    void ProcessCell(int r, int c)
    {
      for (var i = 0; i < 4; i++)
      {
        var nr = r + Dir[i, 0];
        var nc = c + Dir[i, 1];
        if (nr >= 0 && nr < m && nc >= 0 && nc < n &&
            mat[nr][nc] == 1 && result[nr][nc] == 0)
        {
          result[nr][nc] = result[r][c] + 1;
          q.Enqueue((nr, nc));
        }
      }
    }

    for (var r = 0; r < m; r++)
    for (var c = 0; c < n; c++)
    {
      if (mat[r][c] == 0)
        ProcessCell(r, c);
    }
    while (q.Count > 0)
    {
      var (r, c) = q.Dequeue();
      ProcessCell(r, c);
    }
    return result;
  }
}
