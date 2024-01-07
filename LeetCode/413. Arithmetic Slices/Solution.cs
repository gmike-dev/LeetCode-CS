namespace LeetCode._413._Arithmetic_Slices;

public class Solution
{
  public int NumberOfArithmeticSlices(int[] a)
  {
    var n = a.Length;
    var count = 0;
    var current = 0;
    for (var i = 2; i < n; i++)
    {
      if (a[i - 2] - a[i - 1] == a[i - 1] - a[i])
        count += ++current;
      else
        current = 0;
    }
    return count;
  }
}