namespace LeetCode.Graphs._3286._Find_a_Safe_Walk_Through_a_Grid.Bfs;

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
        var q = new LinkedList<int>();
        Span<int> d = [1, 0, -1, 0, 1];
        healths[0, 0] = health - grid[0][0];
        q.AddFirst(0);
        while (q.Count > 0)
        {
            int point = q.First.Value;
            if (point == finalPoint)
            {
                return true;
            }
            q.RemoveFirst();
            int r = point >> 6;
            int c = point & 0b111111;
            for (int i = 0; i < 4; i++)
            {
                int nr = r + d[i];
                int nc = c + d[i + 1];
                if (nr < 0 || nc < 0 || nr >= n || nc >= m)
                {
                    continue;
                }
                int h = healths[r, c] - grid[nr][nc];
                if (h > healths[nr, nc])
                {
                    healths[nr, nc] = h;
                    if (grid[nr][nc] == 0)
                    {
                        q.AddFirst((nr << 6) | nc);
                    }
                    else
                    {
                        q.AddLast((nr << 6) | nc);
                    }
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
