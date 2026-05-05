using System.IO;

namespace LeetCode.__Binary_Search._2594._Minimum_Time_to_Repair_Cars;

/// <summary>
/// <see href="https://leetcode.com/problems/minimum-time-to-repair-cars/"/>
/// </summary>
public class Solution2
{
    public long RepairCars(int[] ranks, int cars)
    {
        var minRank = ranks[0];
        var maxRank = ranks[0];
        var rankFreq = new int[101];
        foreach (var rank in ranks)
        {
            rankFreq[rank]++;
            if (rank > maxRank)
                maxRank = rank;
            else if (rank < minRank)
                minRank = rank;
        }
        long minTime = 0;
        long maxTime = (long)ranks.Max() * cars * cars;
        while (minTime < maxTime)
        {
            var time = minTime + (maxTime - minTime) / 2;
            if (CanRepair(time))
                maxTime = time;
            else
                minTime = time + 1;
        }
        return maxTime;

        bool CanRepair(long time)
        {
            long repaired = 0;
            for (var rank = minRank; rank <= maxRank; rank++)
                repaired += rankFreq[rank] * (long)Math.Sqrt((double)time / rank);
            return repaired >= cars;
        }
    }
}

[TestFixture]
public class Solution2Tests
{
    [TestCase(new[] { 4, 2, 3, 1 }, 10, 16)]
    [TestCase(new[] { 5, 1, 8 }, 6, 16)]
    public void Test(int[] ranks, int cars, long expected)
    {
        new Solution2().RepairCars(ranks, cars).Should().Be(expected);
    }

    [TestCaseSource(nameof(GetTestCases))]
    public void TestLargeInput(string ranks, int cars, int expected)
    {
        new Solution2().RepairCars(ranks.Array(), cars).Should().Be(expected);
    }

    public static IEnumerable<object> GetTestCases()
    {
        string source = Path.Join(TestContext.CurrentContext.WorkDirectory,
            "# Binary Search", "2594. Minimum Time to Repair Cars", "TestCases.txt");
        using var sr = new StreamReader(source);
        while (!sr.EndOfStream)
        {
            yield return new object[]
            {
                sr.ReadLine(),
                int.Parse(sr.ReadLine()),
                int.Parse(sr.ReadLine())
            };
        }
    }
}
