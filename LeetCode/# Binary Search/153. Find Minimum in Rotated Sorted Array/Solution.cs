namespace LeetCode.__Binary_Search._153._Find_Minimum_in_Rotated_Sorted_Array;

/// <summary>
/// https://leetcode.com/problems/find-minimum-in-rotated-sorted-array
/// </summary>
public class Solution
{
    public int FindMin(int[] nums)
    {
        int l = 0;
        int r = nums.Length - 1;
        while (l < r)
        {
            int m = l + (r - l) / 2;
            if (nums[m] > nums[r])
            {
                l = m + 1;
            }
            else
            {
                r = m;
            }
        }
        return nums[l];
    }
}

[TestFixture]
public class SolutionTests
{
    [TestCase("[3,4,5,1,2]", 1)]
    [TestCase("[4,5,6,7,0,1,2]", 0)]
    [TestCase("[11,13,15,17]", 11)]
    public void Test(string nums, int expected)
    {
        new Solution().FindMin(nums.Array()).Should().Be(expected);
    }
}
