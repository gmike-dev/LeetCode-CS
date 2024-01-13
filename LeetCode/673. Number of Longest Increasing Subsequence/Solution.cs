using System;
using System.Linq;

namespace LeetCode.NumberOfLongestIncreasingSubsequence;

public class Solution
{
  public int FindNumberOfLIS(int[] nums)
  {
    var n = nums.Length;
    var length = new int[n];
    var count = new int[n];
    Array.Fill(length, 1);
    Array.Fill(count, 1);
    for (var i = 1; i < n; i++)
    {
      for (var j = 0; j < i; j++)
      {
        if (nums[j] < nums[i])
        {
          if (length[j] + 1 > length[i])
          {
            length[i] = Math.Max(length[i], length[j] + 1);
            count[i] = 0;
          }
          if (length[j] + 1 == length[i])
            count[i] += count[j];
        }
      }
    }
    var maxLength = length.Max();
    var numberOfLis = 0;
    for (var i = 0; i < n; i++)
    {
      if (length[i] == maxLength)
        numberOfLis += count[i];
    }
    return numberOfLis;
  }
}