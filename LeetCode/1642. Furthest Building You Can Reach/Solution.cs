using System.IO;

namespace LeetCode._1642._Furthest_Building_You_Can_Reach;

public class Solution
{
    public int FurthestBuilding(int[] heights, int bricks, int ladders)
    {
        var n = heights.Length;
        var q = new PriorityQueue<int, int>();
        for (var i = 1; i < n; i++)
        {
            var d = heights[i] - heights[i - 1];
            if (d > 0)
            {
                q.Enqueue(d, d);
                if (q.Count > ladders)
                {
                    bricks -= q.Dequeue();
                    if (bricks < 0)
                        return i - 1;
                }
            }
        }
        return n - 1;
    }
}

[TestFixture]
public class Tests
{
    [TestCase(new[] { 4, 2, 7, 6, 9, 14, 12 }, 5, 1, 4)]
    [TestCase(new[] { 4, 12, 2, 7, 3, 18, 20, 3, 19 }, 10, 2, 7)]
    [TestCase(new[] { 14, 3, 19, 3 }, 17, 0, 3)]
    [TestCase(new[] { 2 }, 1, 0, 0)]
    public void Test(int[] heights, int bricks, int ladders, int expected)
    {
        new Solution().FurthestBuilding(heights, bricks, ladders).Should().Be(expected);
    }

    [TestCaseSource(nameof(GetTestCases))]
    public void TestLargeInput(string heights, int bricks, int ladders, int expected)
    {
        new Solution().FurthestBuilding(heights.Array(), bricks, ladders).Should().Be(expected);
    }

    public static IEnumerable<object> GetTestCases()
    {
        string source = Path.Join(TestContext.CurrentContext.WorkDirectory,
            "1642. Furthest Building You Can Reach", "TestCases.txt");
        using var sr = new StreamReader(source);
        while (!sr.EndOfStream)
        {
            yield return new object[]
            {
                sr.ReadLine() ?? throw new InvalidOperationException(),
                int.Parse(sr.ReadLine() ?? throw new InvalidOperationException()),
                int.Parse(sr.ReadLine() ?? throw new InvalidOperationException()),
                int.Parse(sr.ReadLine() ?? throw new InvalidOperationException())
            };
        }
    }
}
