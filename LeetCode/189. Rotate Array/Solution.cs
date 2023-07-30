using System;

namespace LeetCode._189._Rotate_Array;

public class Solution
{
  public void Rotate(int[] nums, int k)
  {
    var n = nums.Length;
    k %= n;
    if (k == 0)
      return;
    Array.Reverse(nums);
    Array.Reverse(nums, 0, k);
    Array.Reverse(nums, k, n - k);
  }
  
  public void Rotate_UseTempArray(int[] nums, int k)
  {
    var n = nums.Length;
    k %= n;
    if (k == 0)
    {
      return;
    }
    var tmp = GC.AllocateUninitializedArray<int>(n);
    nums.AsSpan(0, n - k).CopyTo(tmp.AsSpan(k));
    nums.AsSpan(n - k, k).CopyTo(tmp.AsSpan(0, k));
    tmp.AsSpan().CopyTo(nums);
  }
}