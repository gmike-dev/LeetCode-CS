using System;
using System.Collections.Generic;

namespace LeetCode._1380._Lucky_Numbers_in_a_Matrix;

public class Solution
{
  public IList<int> LuckyNumbers(int[][] matrix)
  {
    var m = matrix.Length;
    var n = matrix[0].Length;
    var rowMin = new int[m];
    rowMin.AsSpan().Fill(int.MaxValue);
    var colMax = new int[n];
    for (var i = 0; i < m; i++)
    {
      var row = matrix[i];
      for (var j = 0; j < n; j++)
      {
        var value = row[j];
        rowMin[i] = Math.Min(rowMin[i], value);
        colMax[j] = Math.Max(colMax[j], value);
      }
    }
    var lucky = new List<int>();
    for (var i = 0; i < m; i++)
    {
      var row = matrix[i];
      for (var j = 0; j < n; j++)
      {
        var value = row[j];
        if (value == rowMin[i] && value == colMax[j])
        {
          lucky.Add(value);
        }
      }
    }
    return lucky;
  }
}