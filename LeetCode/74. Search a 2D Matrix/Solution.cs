using System;

namespace LeetCode._74._Search_a_2D_Matrix;

public class Solution
{
  public bool SearchMatrix(int[][] matrix, int target)
  {
    var startRow = 0;
    var endRow = matrix.Length - 1;
    while (startRow <= endRow)
    {
      var mid = startRow + (endRow - startRow) / 2;
      if (matrix[mid][0] < target)
        startRow = mid + 1;
      else if (matrix[mid][0] > target)
        endRow = mid - 1;
      else
        return true;
    }

    return endRow >= 0 && Array.BinarySearch(matrix[endRow], target) >= 0;
  }
}