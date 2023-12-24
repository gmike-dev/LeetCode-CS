using System;

namespace LeetCode._2972._Count_the_Number_of_Incremovable_Subarrays_II;

public class Solution
{
  public long IncremovableSubarrayCount(int[] a)
  {
    var n = a.Length;
    if (IsIncrease(a))
      return (long)n * (n + 1) / 2;

    var left = 0;
    while (a[left] < a[left + 1])
      left++;

    var right = a.Length - 1;
    while (a[right - 1] < a[right])
      right--;

    if (a[left] < a[right])
    {
      var leftLen = left + 1;
      var rightLen = a.Length - right;
      return (long)(leftLen + 1) * (rightLen + 1);
    }

    long count = a.Length - right + 1;
    for (var i = 0; i <= left; i++)
    {
      var pos = Array.BinarySearch(a, right, a.Length - right, a[i] + 1);
      if (pos < 0)
        pos = ~pos;
      if (pos == n)
        count++;
      else
        count += n - pos + 1;
    }
    return count;
  }

  private static bool IsIncrease(Span<int> a)
  {
    for (var i = 1; i < a.Length; i++)
    {
      if (a[i - 1] >= a[i])
        return false;
    }
    return true;
  }
}