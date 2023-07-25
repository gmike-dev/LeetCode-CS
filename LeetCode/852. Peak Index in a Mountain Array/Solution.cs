namespace LeetCode._852._Peak_Index_in_a_Mountain_Array;

public class Solution
{
  public int PeakIndexInMountainArray(int[] a)
  {
    var i = 0;
    while (a[i] < a[i + 1])
      i++;
    return i;
  }
  
  public int PeakIndexInMountainArray_TernarySearch(int[] arr)
  {
    var n = arr.Length;
    var l = 0;
    var r = n - 1;
    while (r - l > 1)
    {
      var d = (r - l + 1) / 3;
      var m1 = l + d;
      var m2 = r - d;
      if (arr[m1] <= arr[m2])
        l = m1;
      else
        r = m2;
    }
    return arr[l] >= arr[r] ? l : r;
  }
  
  public int PeakIndexInMountainArray_BinarySearch(int[] a)
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