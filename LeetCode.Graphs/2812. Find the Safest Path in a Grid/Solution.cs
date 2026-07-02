namespace LeetCode.Graphs._2812._Find_the_Safest_Path_in_a_Grid;

/// <summary>
/// https://leetcode.com/problems/find-the-safest-path-in-a-grid/
/// </summary>
public class Solution
{
    private static readonly int[] D = [-1, 0, 1, 0, -1];

    public int MaximumSafenessFactor(IList<IList<int>> grid)
    {
        int n = grid.Count;
        int[,] factor = Bfs(grid);
        bool[,] used = new bool[n, n];
        var q = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y - x));
        q.Enqueue(0, factor[0, 0]);
        used[0, 0] = true;
        while (q.Count > 0)
        {
            q.TryDequeue(out int p, out int f);
            int r = p / n;
            int c = p % n;
            if (r == n - 1 && c == n - 1)
            {
                return f;
            }
            for (int i = 0; i < 4; i++)
            {
                int nr = r + D[i];
                int nc = c + D[i + 1];
                if (nr >= 0 && nc >= 0 && nr < n && nc < n && !used[nr, nc])
                {
                    q.Enqueue(n * nr + nc, Math.Min(f, factor[nr, nc]));
                    used[nr, nc] = true;
                }
            }
        }
        return -1;
    }

    private static int[,] Bfs(IList<IList<int>> grid)
    {
        int n = grid.Count;
        int[,] factor = new int[n, n];
        var q = new Queue<int>();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] != 0)
                {
                    q.Enqueue(n * i + j);
                }
                else
                {
                    factor[i, j] = -1;
                }
            }
        }
        while (q.Count > 0)
        {
            int p = q.Dequeue();
            int r = p / n;
            int c = p % n;
            for (int j = 0; j < 4; j++)
            {
                int nr = r + D[j];
                int nc = c + D[j + 1];
                if (nr >= 0 && nc >= 0 && nr < n && nc < n && factor[nr, nc] == -1)
                {
                    factor[nr, nc] = factor[r, c] + 1;
                    q.Enqueue(n * nr + nc);
                }
            }
        }
        return factor;
    }
}

[TestFixture]
public class SolutionTests
{
    [TestCase("[[1,0,0],[0,0,0],[0,0,1]]", 0)]
    [TestCase("[[0,0,1],[0,0,0],[0,0,0]]", 2)]
    [TestCase("[[0,0,0,1],[0,0,0,0],[0,0,0,0],[1,0,0,0]]", 2)]
    public void Test(string grid, int expected)
    {
        new Solution().MaximumSafenessFactor(grid.Array2()).Should().Be(expected);
    }
}
