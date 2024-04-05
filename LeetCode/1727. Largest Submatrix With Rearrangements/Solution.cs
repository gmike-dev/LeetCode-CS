namespace LeetCode._1727._Largest_Submatrix_With_Rearrangements;

public class Solution
{
  public int LargestSubmatrix(int[][] matrix)
  {
    var m = matrix.Length;
    var n = matrix[0].Length;
    var currH = new int[n];
    var h = new int[n];
    var sq = 0;
    for (var i = 0; i < m; i++)
    {
      for (var j = 0; j < n; j++)
      {
        if (matrix[i][j] == 1)
          currH[j]++;
        else
          currH[j] = 0;
      }
      currH.AsSpan().CopyTo(h);
      h.AsSpan().Sort((x,y) => y.CompareTo(x));
      for (var w = 0; w < n && h[w] != 0; w++)
        sq = Math.Max(sq, (w + 1) * h[w]);
    }
    return sq;
  }
}
