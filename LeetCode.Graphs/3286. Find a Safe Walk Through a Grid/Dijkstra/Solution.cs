namespace LeetCode.Graphs._3286._Find_a_Safe_Walk_Through_a_Grid.Dijkstra;

public class Solution
{
    public bool FindSafeWalk(IList<IList<int>> grid, int health)
    {
        if (health - grid[0][0] <= 0)
        {
            return false;
        }
        int n = grid.Count;
        int m = grid[0].Count;
        int[,] healths = new int[n, m];
        int finalPoint = ((n - 1) << 6) | (m - 1);
        var q = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y - x));
        Span<int> d = [1, 0, -1, 0, 1];
        healths[0, 0] = health - grid[0][0];
        q.Enqueue(0, healths[0, 0]);
        while (q.TryDequeue(out int point, out int currentHealth))
        {
            if (point == finalPoint)
            {
                return true;
            }
            int r = point >> 6;
            int c = point & 0b111111;
            if (healths[r, c] != currentHealth)
            {
                continue;
            }
            for (int i = 0; i < 4; i++)
            {
                int nr = r + d[i];
                int nc = c + d[i + 1];
                if (nr >= 0 && nc >= 0 && nr < n && nc < m && currentHealth - grid[nr][nc] > healths[nr, nc])
                {
                    q.Enqueue((nr << 6) | nc, currentHealth - grid[nr][nc]);
                    healths[nr, nc] = currentHealth - grid[nr][nc];
                }
            }
        }
        return false;
    }
}

[TestFixture]
public class SolutionTests
{
    [TestCase("[[0,1,0,0,0],[0,1,0,1,0],[0,0,0,1,0]]", 1, true)]
    [TestCase("[[0,1,1,0,0,0],[1,0,1,0,0,0],[0,1,1,1,0,1],[0,0,1,0,1,0]]", 3, false)]
    [TestCase("[[1,1,1],[1,0,1],[1,1,1]]", 5, true)]
    public void Test(string grid, int health, bool expected)
    {
        new Solution().FindSafeWalk(grid.Array2(), health).Should().Be(expected);
    }
}
