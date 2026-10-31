namespace LeetCode.DP._3665._Twisted_Mirror_Path_Count._2._Optimized;

public class Solution
{
    public int UniquePaths(int[][] grid)
    {
        int n = grid.Length;
        int m = grid[0].Length;
        const int mod = (int)1e9 + 7;
        int[,] dp = new int[m, 2];
        dp[0, 0] = 1;
        for (int j = 1; j < m; j++)
        {
            if (grid[0][j - 1] != 0)
            {
                break;
            }
            dp[j, 1] = 1;
        }
        for (int i = 1; i < n; i++)
        {
            if (grid[i - 1][0] != 0)
            {
                dp[0, 0] = 0;
            }
            for (int j = 1; j < m; j++)
            {
                if (grid[i - 1][j] == 0)
                {
                    dp[j, 0] = (dp[j, 0] + dp[j, 1]) % mod;
                }
                else
                {
                    dp[j, 0] = dp[j, 1];
                }
                if (grid[i][j - 1] == 0)
                {
                    dp[j, 1] = (dp[j - 1, 1] + dp[j - 1, 0]) % mod;
                }
                else
                {
                    dp[j, 1] = dp[j - 1, 0];
                }
            }
        }
        return (dp[m - 1, 0] + dp[m - 1, 1]) % mod;
    }
}

[TestFixture]
public class SolutionTests
{
    [TestCase("[[0,1,0],[0,0,1],[1,0,0]]", 5)]
    [TestCase("[[0,0],[0,0]]", 2)]
    [TestCase("[[0,1,1],[1,1,0]]", 1)]
    [TestCase("[[0,0,0],[1,1,0]]", 2)]
    [TestCase("[[0,0],[1,0],[0,0]]", 2)]
    public void Test(string grid, int expected)
    {
        new Solution().UniquePaths(grid.Array2()).Should().Be(expected);
    }
}
