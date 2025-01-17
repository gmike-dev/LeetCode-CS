using System.Runtime.InteropServices;

namespace LeetCode.Numbers._2425._Bitwise_XOR_of_All_Pairings;

public class Solution3
{
  public int XorAllNums(int[] nums1, int[] nums2)
  {
    var xor1 = 0;
    if (nums2.Length % 2 != 0)
      xor1 = FastXorArray(nums1);
    var xor2 = 0;
    if (nums1.Length % 2 != 0)
      xor2 = FastXorArray(nums2);
    return xor1 ^ xor2;
  }

  private static int FastXorArray(int[] a)
  {
    var n = a.Length;
    var s = a.AsSpan(0, n - n % 2);
    var longArray = MemoryMarshal.Cast<int, ulong>(s);
    ulong longXor = 0;
    foreach (var x in longArray)
      longXor ^= x;
    var xor = (int)((longXor >> 32) ^ (longXor & ((1ul << 32) - 1)));
    if (n % 2 != 0)
      xor ^= a[^1];
    return xor;
  }
}

[TestFixture]
public class Solution3Tests
{
  [TestCase(new[] { 2, 1, 3 }, new[] { 10, 2, 5, 0 }, 13)]
  [TestCase(new[] { 1, 2 }, new[] { 3, 4 }, 0)]
  [TestCase(new[] { 8, 6, 29, 2, 26, 16, 15, 29 }, new[] { 24, 12, 12 }, 9)]
  [TestCase(new[] { 8, 6, 29, 2, 26, 16, 15, 29, 19, 1, 2, 3, 4, 5, 6, 7, 8 },
    new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21 }, 19)]
  public void Test(int[] nums1, int[] nums2, int expected)
  {
    new Solution3().XorAllNums(nums1, nums2).Should().Be(expected);
  }
}
