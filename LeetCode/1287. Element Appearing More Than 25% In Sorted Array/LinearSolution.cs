using System;

namespace LeetCode._1287._Element_Appearing_More_Than_25__In_Sorted_Array;

public class LinearSolution
{
  public int FindSpecialInteger(int[] arr)
  {
    var n = arr.Length;
    if (n == 1)
      return arr[0];
    var count = 1;
    for (var i = 1; i < n; i++)
    {
      if (arr[i - 1] == arr[i])
      {
        count++;
        if (4 * count > n)
          return arr[i];
      }
      else
        count = 1;
    }
    throw new InvalidOperationException();
  }
}