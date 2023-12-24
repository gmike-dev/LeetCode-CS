namespace LeetCode._2972._Count_the_Number_of_Incremovable_Subarrays_II;

public class Solution
{
  public long IncremovableSubarrayCount(int[] a)
  {
    var n = a.Length;

    var left = 0;
    while (left + 1 < n && a[left] < a[left + 1])
      left++;
    
    if (left == n - 1)
      return (long)n * (n + 1) / 2;

    var right = n - 1;
    while (a[right - 1] < a[right])
      right--;

    if (a[left] < a[right])
    {
      var leftLen = left + 1;
      var rightLen = n - right;
      return (long)(leftLen + 1) * (rightLen + 1);
    }

    long count = n - right + 1;
    for (int i = 0, j = right; i <= left; i++)
    {
      while (j < n && a[j] <= a[i])
        j++;
      count += n - j + 1;
    }
    return count;
  }
}