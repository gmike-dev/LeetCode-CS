using System.Linq;

namespace LeetCode._2233._Maximum_Product_After_K_Increments;

public class HeapSolution
{
  public int MaximumProduct(int[] nums, int k)
  {
    BuildHeap(nums);
    while (k > 0)
    {
      nums[0]++;
      PushDown(nums, 0);
      k--;
    }
    return (int)nums.Aggregate(1L, (p, num) => p * num % 1000000007);
  }

  private static void BuildHeap(int[] a)
  {
    for (var i = a.Length / 2 - 1; i >= 0; i--)
      PushDown(a, i);
  }

  private static void PushDown(int[] a, int i)
  {
    var n = a.Length;
    while (true)
    {
      var min = i;
      var l = (i << 1) + 1; /* 2*id + 1 */
      var r = (i + 1) << 1; /* 2*id + 2 */
      if (l < n && a[l] < a[min])
        min = l;
      if (r < n && a[r] < a[min])
        min = r;
      if (min == i)
        break;
      (a[min], a[i]) = (a[i], a[min]);
      i = min;
    }
  }
}