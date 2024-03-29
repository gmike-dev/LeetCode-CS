using System;

namespace LeetCode.__Sliding_Window._1838._Frequency_of_the_Most_Frequent;

public class CountingSortSolution
{
  public int MaxFrequency(int[] nums, int k)
  {
    CountingSort(nums);
    var count = 1;
    var left = 0;
    var sum = 0;
    for (var right = 1; right < nums.Length; right++)
    {
      sum += (nums[right] - nums[right - 1]) * (right - left);
      if (sum > k)
      {
        sum -= nums[right] - nums[left];
        left++;
      }
      else
      {
        count = Math.Max(count, right - left + 1);
      }
    }
    return count;
  }

  private static void CountingSort(int[] nums)
  {
    var cnt = new int[100001];
    foreach (var num in nums)
      cnt[num]++;
    var len = 0;
    for (var i = 1; len < nums.Length; i++)
    {
      for (var j = cnt[i]; j > 0; j--)
        nums[len++] = i;
    }
  }
}
