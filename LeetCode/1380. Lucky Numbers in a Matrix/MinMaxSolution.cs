namespace LeetCode._1380._Lucky_Numbers_in_a_Matrix;

public class MinMaxSolution
{
  public IList<int> LuckyNumbers(int[][] matrix)
  {
    var rowMaxMin = 0;
    var colMinMax = int.MaxValue;
    var m = matrix.Length;
    var n = matrix[0].Length;
    for (var i = 0; i < m; i++)
    {
      var rowMin = int.MaxValue;
      for (var j = 0; j < n; j++)
        rowMin = Math.Min(rowMin, matrix[i][j]);
      rowMaxMin = Math.Max(rowMaxMin, rowMin);
    }
    for (var j = 0; j < n; j++)
    {
      var colMax = 0;
      for (var i = 0; i < m; i++)
        colMax = Math.Max(colMax, matrix[i][j]);
      colMinMax = Math.Min(colMinMax, colMax);
    }
    return colMinMax == rowMaxMin ? new[] { colMinMax } : Array.Empty<int>();
  }
}
