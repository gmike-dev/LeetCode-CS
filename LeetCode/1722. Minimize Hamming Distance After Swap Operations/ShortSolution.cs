using System.IO;

namespace LeetCode._1722._Minimize_Hamming_Distance_After_Swap_Operations;

/// <summary>
/// https://leetcode.com/problems/minimize-hamming-distance-after-swap-operations/
/// </summary>
public class ShortSolution
{
    public int MinimumHammingDistance(int[] source, int[] target, int[][] allowedSwaps)
    {
        int n = source.Length;
        UnionFind uf = new UnionFind(n);
        foreach (int[] swap in allowedSwaps)
        {
            (int a, int b) = (swap[0], swap[1]);
            uf.Union(a, b);
        }
        int ans = 0;
        Dictionary<int, List<int>> groups = [];
        for (int i = 0; i < n; i++)
        {
            int g = uf.Find(i);
            if (groups.TryGetValue(g, out var group))
            {
                group.Add(i);
            }
            else
            {
                groups[g] = [i];
            }
        }
        foreach (List<int> g in groups.Values)
        {
            Dictionary<int, int> itemCount = [];
            foreach (int i in g)
            {
                itemCount[source[i]] = itemCount.GetValueOrDefault(source[i]) + 1;
            }
            foreach (int i in g)
            {
                if (itemCount.GetValueOrDefault(target[i]) > 0)
                {
                    itemCount[target[i]]--;
                }
                else
                {
                    ans++;
                }
            }
        }
        return ans;
    }

    private class UnionFind
    {
        private readonly int[] parent;
        private readonly int[] size;

        public UnionFind(int n)
        {
            parent = new int[n];
            size = new int[n];
            for (int i = 0; i < n; i++)
            {
                parent[i] = i;
                size[i] = 1;
            }
        }

        public int Find(int x)
        {
            while (parent[x] != x)
            {
                parent[x] = parent[parent[x]];
                x = parent[x];
            }
            return x;
        }

        public void Union(int x, int y)
        {
            x = Find(x);
            y = Find(y);
            if (x != y)
            {
                if (size[x] < size[y])
                    (x, y) = (y, x);
                parent[y] = x;
                size[x] += size[y];
            }
        }
    }
}

[TestFixture]
public class ShortSolutionTests
{
    [TestCase("[1,2,3,4]", "[2,1,4,5]", "[[0,1],[2,3]]", 1)]
    [TestCase("[1,2,3,4]", "[1,3,2,4]", "[]", 2)]
    [TestCase("[5,1,2,4,3]", "[1,5,4,2,3]", "[[0,4],[4,2],[1,3],[1,4]]", 0)]
    public void Test(string source, string target, string allowedSwaps, int expected)
    {
        new ShortSolution().MinimumHammingDistance(source.Array(), target.Array(), allowedSwaps.Array2())
            .Should()
            .Be(expected);
    }

    [TestCaseSource(nameof(GetTestCases))]
    public void TestLargeInput(string source, string target, string allowedSwaps, int expected)
    {
        new ShortSolution().MinimumHammingDistance(source.Array(), target.Array(), allowedSwaps.Array2())
            .Should()
            .Be(expected);
    }

    public static IEnumerable<object> GetTestCases()
    {
        string source = Path.Join(TestContext.CurrentContext.WorkDirectory,
            "1722. Minimize Hamming Distance After Swap Operations", "TestCases.txt");
        using var sr = new StreamReader(source);
        while (!sr.EndOfStream)
        {
            yield return new object[]
            {
                sr.ReadLine() ?? throw new InvalidOperationException(),
                sr.ReadLine() ?? throw new InvalidOperationException(),
                sr.ReadLine() ?? throw new InvalidOperationException(),
                int.Parse(sr.ReadLine() ?? throw new InvalidOperationException())
            };
        }
    }
}
