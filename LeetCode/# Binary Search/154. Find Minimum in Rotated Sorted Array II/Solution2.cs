namespace LeetCode.__Binary_Search._154._Find_Minimum_in_Rotated_Sorted_Array_II;

/// <summary>
/// https://leetcode.com/problems/find-minimum-in-rotated-sorted-array-ii
/// </summary>
public class Solution2
{
    public int FindMin(int[] nums)
    {
        int l = 0;
        int r = nums.Length - 1;
        while (l < r && nums[l] == nums[r])
        {
            l++;
        }
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
public class Solution2Tests
{
    [TestCase("[1,3,5]", 1)]
    [TestCase("[2,2,2,0,1]", 0)]
    [TestCase("[1]", 1)]
    [TestCase("[1,3,3]", 1)]
    public void Test(string nums, int expected)
    {
        new Solution2().FindMin(nums.Array()).Should().Be(expected);
    }
}
