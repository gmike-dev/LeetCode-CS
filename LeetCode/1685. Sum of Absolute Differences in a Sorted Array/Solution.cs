namespace LeetCode._1685._Sum_of_Absolute_Differences_in_a_Sorted_Array;

public class Solution
{
  public int[] GetSumAbsoluteDifferences(int[] nums)
  {
    var n = nums.Length;
    var sr = nums.Sum();
    var sl = 0;
    for (var i = 0; i < n; i++)
    {
      var val = nums[i];
      nums[i] = (2 * i - n) * val + sr - sl;
      sr -= val;
      sl += val;
    }
    return nums;
  }
}
