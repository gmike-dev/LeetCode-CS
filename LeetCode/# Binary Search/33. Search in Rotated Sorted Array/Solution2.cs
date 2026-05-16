namespace LeetCode.__Binary_Search._33._Search_in_Rotated_Sorted_Array;

/// <summary>
/// https://leetcode.com/problems/search-in-rotated-sorted-array/
/// </summary>
public class Solution2
{
    public int Search(int[] nums, int target)
    {
        int l = 0;
        int r = nums.Length - 1;
        while (l <= r)
        {
            int m = l + (r - l) / 2;
            if (nums[m] == target)
            {
                return m;
            }
            if (nums[m] > nums[r])
            {
                if (target < nums[l] || target > nums[m])
                {
                    l = m + 1;
                }
                else
                {
                    r = m - 1;
                }
            }
            else
            {
                if (target < nums[m] || target > nums[r])
                {
                    r = m - 1;
                }
                else
                {
                    l = m + 1;
                }
            }
        }
        return -1;
    }
}

[TestFixture]
public class Solution2Tests
{
    [TestCase("[4,5,6,7,0,1,2]", 0, 4)]
    [TestCase("[4,5,6,7,0,1,2]", 3, -1)]
    [TestCase("[1]", 0, -1)]
    public void Test(string nums, int target, int expected)
    {
        new Solution2().Search(nums.Array(), target).Should().Be(expected);
    }
}
