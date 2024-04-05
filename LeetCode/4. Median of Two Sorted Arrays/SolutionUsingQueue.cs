namespace LeetCode._4._Median_of_Two_Sorted_Arrays;

/// <summary>
/// O(n * log (n)) solution.
/// </summary>
public class SolutionUsingQueue
{
  public double FindMedianSortedArrays(int[] nums1, int[] nums2)
  {
    var m = nums1.Length;
    var n = nums2.Length;
    var h = (m + n) / 2 + 1;
    var q = new PriorityQueue<int, int>(h);
    foreach (var num in nums1.Concat(nums2))
    {
      if (q.Count < h)
        q.Enqueue(num, num);
      else
        q.EnqueueDequeue(num, num);
    }
    if ((m + n) % 2 == 0)
    {
      var mid1 = q.Dequeue();
      var mid2 = q.Dequeue();
      return (mid1 + mid2) / 2.0;
    }
    return q.Dequeue();
  }
}
