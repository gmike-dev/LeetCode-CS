namespace LeetCode._912._Sort_an_Array;

public class RadixSortSolution
{
  public int[] SortArray(int[] nums)
  {
    const int m = 50000;
    for (var i = 0; i < nums.Length; i++)
      nums[i] += m;
    var startBit = 0;
    for (var i = 0; i < nums.Length; i++)
      startBit = Math.Max(startBit, MostSignificantBit(nums[i]));
    RadixSort(nums, startBit);
    for (var i = 0; i < nums.Length; i++)
      nums[i] -= m;
    return nums;
  }

  private static int MostSignificantBit(int n)
  {
    return n == 0 ? 0 : BitOperations.Log2((uint)n);
  }

  private void RadixSort(Span<int> nums, int bit)
  {
    if (nums.Length < 2)
      return;
    var l = 0;
    var r = nums.Length;
    while (r - l > 1)
    {
      if (((nums[l] >> bit) & 1) == 1)
      {
        (nums[l], nums[r - 1]) = (nums[r - 1], nums[l]);
        r--;
      }
      else
      {
        l++;
      }
    }
    if (((nums[l] >> bit) & 1) == 1)
      r--;
    if (bit > 0)
    {
      RadixSort(nums[..r], bit - 1);
      RadixSort(nums[r..], bit - 1);
    }
  }
}
