using System;
using System.Linq;

namespace LeetCode.LongestIncreasingSubsequence;

public class BitSolution
{
  private class MaxBit
  {
    private readonly int[] bit;
    
    public MaxBit(int n) => bit = new int[n + 1];

    public int Max(int r)
    {
      var max = int.MinValue;
      for (r++; r > 0; r = Parent(r))
        max = Math.Max(max, bit[r]);
      return max;
    }

    public void Update(int index, int value)
    {
      // Bit is 1-indexed.
      for (index++; index < bit.Length; index = Next(index))
        bit[index] = Math.Max(bit[index], value);
    }

    private static int Lso(int n) => n & -n;

    private static int Parent(int i) => i - Lso(i);

    private static int Next(int i) => i + Lso(i);
  }

  public int LengthOfLIS(int[] nums)
  {
    var minVal = nums.Min() - 1;
    var maxVal = nums.Max() - minVal;
    var bit = new MaxBit(maxVal + 1);
    foreach (var x in nums)
    {
      var value = x - minVal;
      var longestSeq = bit.Max(value - 1);
      bit.Update(value, longestSeq + 1);
    }
    return bit.Max(maxVal);
  }
}