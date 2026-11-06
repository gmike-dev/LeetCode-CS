namespace LeetCode.SlidingWindow._2747._Count_Zero_Request_Servers.SlidingWindowV2;

/// <summary>
/// https://leetcode.com/problems/count-zero-request-servers
/// </summary>
public class Solution
{
    public int[] CountServers(int n, int[][] logs, int x, int[] queries)
    {
        Array.Sort(logs, (l1, l2) => l1[1] - l2[1]);
        int m = queries.Length;
        Span<int> p = stackalloc int[m];
        for (int i = 0; i < m; i++)
        {
            p[i] = i;
        }
        p.Sort((p1, p2) => queries[p1] - queries[p2]);
        int left = 0;
        int right = 0;
        Span<int> count = stackalloc int[n + 1];
        int activeServers = 0;
        int[] result = new int[m];
        foreach (int i in p)
        {
            while (right < logs.Length && logs[right][1] <= queries[i])
            {
                int serverId = logs[right][0];
                if (count[serverId]++ == 0)
                {
                    activeServers++;
                }
                right++;
            }
            while (left < logs.Length && logs[left][1] < queries[i] - x)
            {
                int serverId = logs[left][0];
                if (--count[serverId] == 0)
                {
                    activeServers--;
                }
                left++;
            }
            result[i] = n - activeServers;
        }
        return result;
    }
}

[TestFixture]
public class SolutionTests
{
    [TestCase(3, "[[1,3],[2,6],[1,5]]", 5, "[10,11]", "[1,2]")]
    [TestCase(3, "[[2,4],[2,1],[1,2],[3,1]]", 2, "[3,4]", "[0,1]")]
    [TestCase(3, "[]", 2, "[3,4]", "[3,3]")]
    [TestCase(3, "[[1,35],[1,32],[1,11],[1,39],[2,29]]", 8, "[38,30,23,33,15,31,34,22,11,14]", "[2,2,3,1,2,2,1,3,2,2]")]
    public void Test(int n, string logs, int x, string queries, string expected)
    {
        new Solution().CountServers(n, logs.Array2(), x, queries.Array()).Should()
            .BeEquivalentTo(expected.Array(), o => o.WithStrictOrdering());
    }
}
