namespace LeetCode._4._Median_of_Two_Sorted_Arrays;

/// <summary>
/// O(log (n)) solution.
/// </summary>
public class Solution
{
  public double FindMedianSortedArrays(int[] nums1, int[] nums2)
  {
    var n = nums1.Length + nums2.Length;
    var m = (nums1.Length + nums2.Length) / 2;
    if (n % 2 != 0)
      return Median(nums1, nums2, m);
    return (Median(nums1, nums2, m - 1) + Median(nums1, nums2, m)) / 2.0;
  }

  private static double Median(Span<int> a, Span<int> b, int k)
  {
    if (a.IsEmpty)
      return b[k];
    if (b.IsEmpty)
      return a[k];

    var ma = a.Length / 2;
    var mb = b.Length / 2;

    if (ma + mb < k)
    {
      if (a[ma] <= b[mb])
        return Median(a[(ma + 1)..], b, k - ma - 1);
      return Median(a, b[(mb + 1)..], k - mb - 1);
    }
    if (b[mb] > a[ma])
      return Median(a, b[..mb], k);
    return Median(a[..ma], b, k);
  }
}
