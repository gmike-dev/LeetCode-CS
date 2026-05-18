namespace LeetCode.Graphs._1306._Jump_Game_III.Dfs;

/// <summary>
/// https://leetcode.com/problems/jump-game-iii/
/// </summary>
public class Solution
{
    public bool CanReach(int[] a, int start)
    {
        int n = a.Length;
        Span<bool> used = stackalloc bool[n];
        return Dfs(used, start);

        bool Dfs(Span<bool> used, int i)
        {
            if (i < 0 || i >= n || used[i])
            {
                return false;
            }
            if (a[i] == 0)
            {
                return true;
            }
            used[i] = true;
            return Dfs(used, i - a[i]) || Dfs(used, i + a[i]);
        }
    }
}

[TestFixture]
public class SolutionTests
{
    [TestCase("[4,2,3,0,3,1,2]", 5, true)]
    [TestCase("[4,2,3,0,3,1,2]", 0, true)]
    [TestCase("[3,0,2,1,2]", 2, false)]
    public void Test(string arr, int start, bool expected)
    {
        new Solution().CanReach(arr.Array(), start).Should().Be(expected);
    }
}
