using LeetCode.Common;

namespace LeetCode._396._Rotate_Function;

/// <summary>
/// https://leetcode.com/problems/rotate-function
/// </summary>
public class Solution
{
  public int MaxRotateFunction(int[] nums)
  {
    int n = nums.Length;
    int totalSum = 0;
    int funcResult = 0;
    for (int i = 0; i < n; i++)
    {
      totalSum += nums[i];
      funcResult += i * nums[i];
    }
    int maxResult = funcResult;
    for (int i = 1; i < n; i++)
    {
      funcResult += totalSum - n * nums[n - i];
      maxResult = Math.Max(maxResult, funcResult);
    }
    return maxResult;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("[4,3,2,6]", 26)]
  [TestCase("[100]", 0)]
  public void Test(string nums, int expected)
  {
    new Solution().MaxRotateFunction(nums.Array()).Should().Be(expected);
  }
}
