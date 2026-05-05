namespace LeetCode._3919._Minimum_Cost_to_Move_Between_Indices;

/// <summary>
/// https://leetcode.com/problems/minimum-cost-to-move-between-indices
/// </summary>
public class Solution
{
    public int[] MinCost(int[] nums, int[][] queries)
    {
        int n = nums.Length;
        Span<int> prefix1 = stackalloc int[n];
        Span<int> prefix2 = stackalloc int[n];
        prefix1[1] = 1;
        for (int i = 2; i < n; i++)
        {
            int left = nums[i - 1] - nums[i - 2];
            int right = nums[i] - nums[i - 1];
            if (left <= right)
            {
                prefix1[i] = prefix1[i - 1] + right;
            }
            else
            {
                prefix1[i] = prefix1[i - 1] + 1;
            }
        }
        prefix2[n - 2] = 1;
        for (int i = n - 3; i >= 0; i--)
        {
            int left = nums[i + 1] - nums[i];
            int right = nums[i + 2] - nums[i + 1];
            if (left > right)
            {
                prefix2[i] = prefix2[i + 1] + left;
            }
            else
            {
                prefix2[i] = prefix2[i + 1] + 1;
            }
        }
        int m = queries.Length;
        int[] answer = new int[m];
        for (int i = 0; i < m; i++)
        {
            int[] q = queries[i];
            int l = q[0];
            int r = q[1];
            if (l <= r)
            {
                answer[i] = prefix1[r] - prefix1[l];
            }
            else
            {
                answer[i] = prefix2[r] - prefix2[l];
            }
        }
        return answer;
    }
}

[TestFixture]
public class SolutionTests
{
    [TestCase("[-5,-2,3]", "[[0,2],[2,0],[1,2]]", "[6,2,5]")]
    [TestCase("[0,2,3,9]", "[[3,0],[1,2],[2,0]]", "[4,1,3]")]
    public void Test(string nums, string queries, string expected)
    {
        new Solution().MinCost(nums.Array(), queries.Array2()).Should()
            .BeEquivalentTo(expected.Array(), o => o.WithStrictOrdering());
    }
}
