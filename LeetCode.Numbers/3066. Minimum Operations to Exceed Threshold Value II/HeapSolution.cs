namespace LeetCode.Numbers._3066._Minimum_Operations_to_Exceed_Threshold_Value_II;

public class HeapSolution
{
  public int MinOperations(int[] nums, int k)
  {
    BuildHeap(nums);
    var n = nums.Length;
    var count = 0;
    while (nums[0] < k)
    {
      var x = nums[0];
      nums[0] = nums[--n];
      PushDown(nums, n, 0);
      var y = nums[0];
      nums[0] = nums[--n];
      PushDown(nums, n, 0);
      nums[n++] = (int)Math.Min(int.MaxValue, x * 2L + y);
      PushUp(nums, n - 1);
      count++;
    }
    return count;
  }

  private static void BuildHeap(int[] a)
  {
    for (var i = a.Length / 2 - 1; i >= 0; i--)
      PushDown(a, a.Length, i);
  }

  private static void PushDown(int[] a, int n, int i)
  {
    while (true)
    {
      var min = i;
      var l = (i << 1) + 1;
      var r = (i + 1) << 1;
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

  private static void PushUp(int[] a, int i)
  {
    while (i > 0)
    {
      var p = (i - 1) >> 1;
      if (a[p] <= a[i])
        break;
      (a[p], a[i]) = (a[i], a[p]);
      i = p;
    }
  }
}

[TestFixture]
public class HeapSolutionTests
{
  [TestCase(new[] { 2, 11, 10, 1, 3 }, 10, 2)]
  [TestCase(new[] { 1, 1, 2, 4, 9 }, 20, 4)]
  [TestCase(new[] { 999999999, 999999999, 999999999 }, 1000000000, 2)]
  public void Test(int[] nums, int k, int expected)
  {
    new HeapSolution().MinOperations(nums, k).Should().Be(expected);
  }
}
