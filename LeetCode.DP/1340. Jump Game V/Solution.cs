namespace LeetCode.DP._1340._Jump_Game_V;

/// <summary>
/// https://leetcode.com/problems/jump-game-v
/// </summary>
public class Solution
{
    public int MaxJumps(int[] arr, int d)
    {
        int n = arr.Length;
        int[] dp = new int[n];
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            ans = Math.Max(ans, Dfs(i));
        }
        return ans;

        int Dfs(int i)
        {
            if (dp[i] > 0)
            {
                return dp[i];
            }
            dp[i] = 1;
            int l = i - 1;
            while (l >= 0 && i - l <= d && arr[l] < arr[i])
            {
                dp[i] = Math.Max(dp[i], Dfs(l) + 1);
                l--;
            }
            int r = i + 1;
            while (r < n && r - i <= d && arr[r] < arr[i])
            {
                dp[i] = Math.Max(dp[i], Dfs(r) + 1);
                r++;
            }
            return dp[i];
        }
    }
}

[TestFixture]
public class SolutionTests
{
    [TestCase("[6,4,14,6,8,13,9,7,10,6,12]", 2, 4)]
    [TestCase("[3,3,3,3,3]", 3, 1)]
    [TestCase("[7,6,5,4,3,2,1]", 1, 7)]
    [TestCase("[22,29,52,97,29,75,78,2,92,70,90,12,43,17,97,18,58,100,41,32]", 17, 6)]
    [TestCase("[59,8,74,27,92,36,95,78,73,54,75,37,42,15,59,84,66,25,35,61,97,16,6,52,49,18,22,70,5,59,92,85]", 20, 8)]
    [TestCase(
        "[83,11,83,70,75,45,96,11,80,75,67,83,6,51,71,64,64,42,70,23,11,24,95,65,1,54,31,50,18,16,11,86,2,48,37,34,65,67,4,17,33,70,16,73,57,96,30,26,56,1,16,74,82,77,82,62,32,90,94,33,58,23,23,65,70,12,85,27,38,100,93,49,96,96,77,37,69,71,62,34,4,14,25,37,70,3,67,88,20,30]",
        29, 12)]
    public void Test(string arr, int d, int expected)
    {
        new Solution().MaxJumps(arr.Array(), d).Should().Be(expected);
    }
}
