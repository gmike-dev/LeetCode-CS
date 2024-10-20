namespace LeetCode.DP._2369._Check_if_There_is_a_Valid_Partition_For_The_Array;

public class SolutionUsingDp
{
  public bool ValidPartition(int[] nums)
  {
    if (nums.Length < 2)
      return false;
    var dp = new bool[nums.Length + 1];
    dp[0] = true;
    dp[2] = nums[0] == nums[1];
    for (var len = 3; len <= nums.Length; len++)
    {
      dp[len] = dp[len - 2] && nums[len - 2] == nums[len - 1] ||
                dp[len - 3] && (nums[len - 3] == nums[len - 2] && nums[len - 2] == nums[len - 1] ||
                                nums[len - 3] + 1 == nums[len - 2] && nums[len - 2] + 1 == nums[len - 1]);
    }
    return dp[nums.Length];
  }
}