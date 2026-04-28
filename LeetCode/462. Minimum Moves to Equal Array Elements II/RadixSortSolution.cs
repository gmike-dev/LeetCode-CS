using LeetCode.Common;

namespace LeetCode._462._Minimum_Moves_to_Equal_Array_Elements_II;

/// <summary>
/// https://leetcode.com/problems/minimum-moves-to-equal-array-elements-ii/
/// </summary>
public class RadixSortSolution
{
  public int MinMoves2(int[] nums)
  {
    RadixSort(nums);
    int median = nums[nums.Length / 2];
    int ans = 0;
    foreach (int x in nums)
    {
      ans += Math.Abs(x - median);
    }
    return ans;
  }

  private static void RadixSort(int[] array)
  {
    int n = array.Length;
    uint[] unsigned = new uint[n];
    for (int i = 0; i < n; i++)
      unsigned[i] = (uint)(array[i] ^ 0x80000000);

    for (int shift = 0; shift < 32; shift += 8)
      CountingSortByByte(unsigned, shift);

    for (int i = 0; i < n; i++)
      array[i] = (int)(unsigned[i] ^ 0x80000000);
  }

  private static void CountingSortByByte(uint[] array, int shift)
  {
    int n = array.Length;
    uint[] output = new uint[n];
    int[] count = new int[256];

    for (int i = 0; i < n; i++)
      count[(array[i] >> shift) & 0xFF]++;

    for (int i = 1; i < 256; i++)
      count[i] += count[i - 1];

    for (int i = n - 1; i >= 0; i--)
    {
      uint bucket = (array[i] >> shift) & 0xFF;
      output[--count[bucket]] = array[i];
    }

    Array.Copy(output, array, n);
  }
}

[TestFixture]
public class RadixSortSolutionTests
{
  [TestCase("[1,2,3]", 2)]
  [TestCase("[1,10,2,9]", 16)]
  public void Test(string nums, int expected)
  {
    new RadixSortSolution().MinMoves2(nums.Array()).Should().Be(expected);
  }
}
