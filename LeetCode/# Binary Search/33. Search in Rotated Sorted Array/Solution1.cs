namespace LeetCode.__Binary_Search._33._Search_in_Rotated_Sorted_Array;

/// <summary>
/// https://leetcode.com/problems/search-in-rotated-sorted-array/
/// </summary>
public class Solution1
{
    public int Search(int[] nums, int target)
    {
        int l = 0;
        int n = nums.Length;
        int r = n - 1;
        while (l <= r)
        {
            int m = l + (r - l) / 2;
            if (nums[m] > nums[^1])
            {
                l = m + 1;
            }
            else
            {
                r = m - 1;
            }
        }
        int start = l;
        int result = start > 0 && target >= nums[0]
            ? Array.BinarySearch(nums, 0, start, target)
            : Array.BinarySearch(nums, start, n - start, target);
        return result >= 0 ? result : -1;
    }
}

[TestFixture]
public class Solution1Tests
{
    [TestCase("[4,5,6,7,0,1,2]", 0, 4)]
    [TestCase("[4,5,6,7,0,1,2]", 3, -1)]
    [TestCase("[1]", 0, -1)]
    public void Test(string nums, int target, int expected)
    {
        new Solution1().Search(nums.Array(), target).Should().Be(expected);
    }
}
