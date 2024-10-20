namespace LeetCode.SlidingWindow._2779._Maximum_Beauty_of_an_Array;

public class Solution
{
  public int MaximumBeauty(int[] nums, int k)
  {
    Array.Sort(nums);
    var maxBeauty = 1;
    for (int left = 0, right = 0; right < nums.Length; left++)
    {
      var target = nums[left] + 2 * k;
      while (right < nums.Length && nums[right] <= target)
        right++;
      maxBeauty = Math.Max(maxBeauty, right - left);
    }
    return maxBeauty;
  }
}
