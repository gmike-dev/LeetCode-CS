namespace LeetCode.__Binary_Search._154._Find_Minimum_in_Rotated_Sorted_Array_II;

/// <summary>
/// https://leetcode.com/problems/find-minimum-in-rotated-sorted-array-ii
/// </summary>
public class Solution1
{
    public int FindMin(int[] nums)
    {
        return F(0, nums.Length - 1);

        int F(int l, int r)
        {
            if (l == r || nums[l] < nums[r])
            {
                return nums[l];
            }
            int m = l + (r - l) / 2;
            return Math.Min(F(l, m), F(m + 1, r));
        }
    }
}

[TestFixture]
public class Solution1Tests
{
    [TestCase("[1,3,5]", 1)]
    [TestCase("[2,2,2,0,1]", 0)]
    [TestCase("[1]", 1)]
    [TestCase("[1,3,3]", 1)]
    public void Test(string nums, int expected)
    {
        new Solution1().FindMin(nums.Array()).Should().Be(expected);
    }
}
