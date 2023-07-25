namespace LeetCode._162._Find_Peak_Element;

public class Solution
{
  public int FindPeakElement(int[] a)
  {
    var n = a.Length;
    var l = 0;
    var r = n - 1;
    while (l < r)
    {
      var m = l + (r - l) / 2;
      if (a[m] < a[m + 1])
        l = m + 1;
      else
        r = m;
    }
    return l;
  }
}