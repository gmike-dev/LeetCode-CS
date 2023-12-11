using System.Linq;

namespace LeetCode._1287._Element_Appearing_More_Than_25__In_Sorted_Array;

public class BinarySearchSolution
{
  public int FindSpecialInteger(int[] a)
  {
    var n = a.Length;
    return new[] { a[n / 4], a[n / 2], a[3 * n / 4] }.FirstOrDefault(value => IsSpecialInteger(a, value));
  }

  private static bool IsSpecialInteger(int[] a, int value)
  {
    var n = a.Length;
    var lowerBound = LowerBound(a, 0, n, value);
    var upperBound = UpperBound(a, 0, n, value);
    return upperBound - lowerBound > n / 4;
  }

  private static int LowerBound(int[] a, int beginIndex, int endIndex, int value)
  {
    if (beginIndex >= endIndex)
      return endIndex;
    var l = beginIndex;
    var r = endIndex - 1;
    while (l < r)
    {
      var m = l + (r - l) / 2;
      if (a[m] < value)
        l = m + 1;
      else
        r = m;
    }
    return a[l] < value ? endIndex : l;
  }

  private static int UpperBound(int[] a, int beginIndex, int endIndex, int value)
  {
    if (beginIndex >= endIndex)
      return endIndex;
    var l = beginIndex;
    var r = endIndex - 1;
    while (l < r)
    {
      var m = l + (r - l) / 2;
      if (a[m] <= value)
        l = m + 1;
      else
        r = m;
    }
    return a[l] <= value ? endIndex : l;
  }
}