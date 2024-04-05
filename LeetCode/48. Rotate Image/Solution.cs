namespace LeetCode._48._Rotate_Image;

public class Solution
{
  public void Rotate(int[][] matrix)
  {
    Array.Reverse(matrix);
    var n = matrix.Length;
    for (var i = 0; i < n - 1; i++)
    for (var j = i + 1; j < n; j++)
      (matrix[i][j], matrix[j][i]) = (matrix[j][i], matrix[i][j]);
  }

  public void Rotate2(int[][] matrix)
  {
    foreach (var row in matrix)
      Array.Reverse(row);
    var n = matrix.Length;
    for (var i = 0; i < n - 1; i++)
    for (var j = 0; j < n - i - 1; j++)
      (matrix[i][j], matrix[n - j - 1][n - i - 1]) = (matrix[n - j - 1][n - i - 1], matrix[i][j]);
  }
}
