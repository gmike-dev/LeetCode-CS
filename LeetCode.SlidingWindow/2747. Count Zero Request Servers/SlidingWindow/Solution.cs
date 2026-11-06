namespace LeetCode.SlidingWindow._2747._Count_Zero_Request_Servers.SlidingWindow;

/// <summary>
/// https://leetcode.com/problems/count-zero-request-servers
/// </summary>
public class Solution
{
    public int[] CountServers(int n, int[][] logs, int x, int[] queries)
    {
        (int Time, int ServerId)[] sortedLogs = new ValueTuple<int, int>[logs.Length];
        for (int i = 0; i < sortedLogs.Length; i++)
        {
            int time = logs[i][0];
            int serverId = logs[i][1];
            sortedLogs[i] = (serverId, time);
        }
        Array.Sort(sortedLogs);
        int m = queries.Length;
        (int Time, int Index)[] sortedQueries = new (int, int)[m];
        for (int i = 0; i < m; i++)
        {
            sortedQueries[i] = (queries[i], i);
        }
        Array.Sort(sortedQueries);
        int left = 0;
        int right = 0;
        Dictionary<int, int> servers = [];
        int activeServers = 0;
        int[] result = new int[m];
        for (int i = 0; i < m; i++)
        {
            while (right < sortedLogs.Length && sortedLogs[right].Time <= sortedQueries[i].Time)
            {
                var serverId = sortedLogs[right].ServerId;
                if (servers.TryGetValue(serverId, out var count) && count > 0)
                {
                    servers[serverId] = count + 1;
                }
                else
                {
                    servers[serverId] = 1;
                    activeServers++;
                }
                right++;
            }
            while (left < sortedLogs.Length && sortedLogs[left].Time < sortedQueries[i].Time - x)
            {
                var serverId = sortedLogs[left].ServerId;
                if (--servers[serverId] == 0)
                {
                    activeServers--;
                }
                left++;
            }
            result[sortedQueries[i].Index] = n - activeServers;
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
