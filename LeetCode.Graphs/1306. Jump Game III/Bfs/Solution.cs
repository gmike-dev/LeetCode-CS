namespace LeetCode.Graphs._1306._Jump_Game_III.Bfs;

/// <summary>
/// https://leetcode.com/problems/jump-game-iii/
/// </summary>
public class Solution
{
    public bool CanReach(int[] a, int start)
    {
        int n = a.Length;
        Span<bool> used = stackalloc bool[n];
        Queue<int> q = new();
        q.Enqueue(start);
        used[start] = true;
        while (q.Count > 0)
        {
            int i = q.Dequeue();
            if (a[i] == 0)
            {
                return true;
            }
            int right = i + a[i];
            if (right < n && !used[right])
            {
                q.Enqueue(right);
                used[right] = true;
            }
            int left = i - a[i];
            if (left >= 0 && !used[left])
            {
                q.Enqueue(left);
                used[left] = true;
            }
        }
        return false;
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
