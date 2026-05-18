using System.IO;

namespace LeetCode.Graphs._1345._Jump_Game_IV;

/// <summary>
/// https://leetcode.com/problems/jump-game-iv/
/// </summary>
public class Solution
{
    public int MinJumps(int[] arr)
    {
        int n = arr.Length;
        Dictionary<int, List<int>> indexes = [];
        for (int i = 0; i < n; i++)
        {
            if (indexes.TryGetValue(arr[i], out List<int> list))
            {
                list.Add(i);
            }
            else
            {
                indexes[arr[i]] = [i];
            }
        }
        Span<bool> visited = stackalloc bool[n];
        Queue<int> q = new();
        q.Enqueue(0);
        visited[0] = true;
        int jumps = 0;
        while (q.Count > 0)
        {
            int count = q.Count;
            for (int i = 0; i < count; i++)
            {
                int u = q.Dequeue();
                if (u == n - 1)
                {
                    return jumps;
                }
                foreach (int v in indexes[arr[u]])
                {
                    if (!visited[v])
                    {
                        q.Enqueue(v);
                        visited[v] = true;
                    }
                }
                indexes[arr[u]].Clear();
                int left = u - 1;
                int right = u + 1;
                if (left >= 0 && !visited[left])
                {
                    q.Enqueue(left);
                    visited[left] = true;
                }
                if (right < n && !visited[right])
                {
                    q.Enqueue(right);
                    visited[right] = true;
                }
            }
            jumps++;
        }
        return jumps;
    }
}

[TestFixture]
public class SolutionTests
{
    [TestCase("[100,-23,-23,404,100,23,23,23,3,404]", 3)]
    [TestCase("[7]", 0)]
    [TestCase("[7,6,9,6,9,6,9,7]", 1)]
    public void Test(string arr, int expected)
    {
        new Solution().MinJumps(arr.Array()).Should().Be(expected);
    }

    [Test]
    public void TestLarge()
    {
        using var sr = new StreamReader(Path.Join(
            TestContext.CurrentContext.WorkDirectory, "1345. Jump Game IV", "TestCases.txt"));
        for (int testCase = 1; !sr.EndOfStream; testCase++)
        {
            string arr = sr.ReadLine() ?? throw new InvalidOperationException();
            int expected = int.Parse(sr.ReadLine() ?? throw new InvalidOperationException());
            new Solution().MinJumps(arr.Array()).Should().Be(expected, "Test case #{0}", testCase);
        }
    }
}
