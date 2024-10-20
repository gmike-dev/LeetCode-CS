namespace LeetCode.SlidingWindow._1838._Frequency_of_the_Most_Frequent;

public class Solution
{
  public int MaxFrequency(int[] nums, int k)
  {
    Array.Sort(nums);
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
}
