namespace LeetCode._48._Rotate_Image;

public class Solution
{
  public void Rotate(int[][] matrix)
  {
    Array.Reverse(matrix);
    int n = matrix.Length;
    for (int i = 0; i < n - 1; i++)
    for (int j = i + 1; j < n; j++)
    {
      (matrix[i][j], matrix[j][i]) = (matrix[j][i], matrix[i][j]);
    }
  }

  public void Rotate2(int[][] matrix)
  {
    foreach (int[] row in matrix)
    {
      Array.Reverse(row);
    }
    int n = matrix.Length;
    for (int i = 0; i < n - 1; i++)
    for (int j = 0; j < n - i - 1; j++)
    {
      (matrix[i][j], matrix[n - j - 1][n - i - 1]) = (matrix[n - j - 1][n - i - 1], matrix[i][j]);
    }
  }

  public void Rotate3(int[][] matrix)
  {
    int n = matrix.Length;
    for (int i = n / 2 - 1; i >= 0; i--)
    {
      for (int j = (n + 1) / 2 - 1; j >= 0; j--)
      {
        (matrix[i][j], matrix[j][n - i - 1], matrix[n - i - 1][n - j - 1], matrix[n - j - 1][i]) =
          (matrix[n - j - 1][i], matrix[i][j], matrix[j][n - i - 1], matrix[n - i - 1][n - j - 1]);
      }
    }
  }
}
