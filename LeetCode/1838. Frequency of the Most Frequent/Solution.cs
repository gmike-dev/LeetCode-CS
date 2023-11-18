using System;

namespace LeetCode._1838._Frequency_of_the_Most_Frequent;

public class Solution
{
  public int MaxFrequency(int[] nums, int k)
  {
    Array.Sort(nums);
    var count = 1;
    int j = 0;
    var sum = 0;
    for (var i = 1; i < nums.Length; i++)
    {
      sum += (nums[i] - nums[i - 1]) * (i - j);
      while (sum > k)
      {
        sum -= nums[i] - nums[j];
        j++;
      }
      count = Math.Max(count, i - j + 1);
    }
    return count;
  }
}