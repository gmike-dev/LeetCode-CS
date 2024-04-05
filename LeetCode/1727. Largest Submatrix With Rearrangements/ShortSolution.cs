namespace LeetCode._1727._Largest_Submatrix_With_Rearrangements;

public class ShortSolution
{
  public int LargestSubmatrix(int[][] matrix)
  {
    var m = matrix.Length;
    var n = matrix[0].Length;
    for (var i = 1; i < m; i++)
    for (var j = 0; j < n; j++)
    {
      if (matrix[i][j] == 1)
        matrix[i][j] += matrix[i - 1][j];
    }
    var sq = 0;
    for (var i = 0; i < m; i++)
    {
      matrix[i].AsSpan().Sort((x,y) => y.CompareTo(x));
      for (var j = 0; j < n; j++)
        sq = Math.Max(sq, (j + 1) * matrix[i][j]);
    }
    return sq;
  }
}
