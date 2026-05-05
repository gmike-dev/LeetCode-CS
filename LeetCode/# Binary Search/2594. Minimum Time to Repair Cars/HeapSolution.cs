using System.IO;

namespace LeetCode.__Binary_Search._2594._Minimum_Time_to_Repair_Cars;

/// <summary>
/// <see href="https://leetcode.com/problems/minimum-time-to-repair-cars/"/>
/// </summary>
public class HeapSolution
{
    public long RepairCars(int[] ranks, int cars)
    {
        var rankFreq = new int[101];
        foreach (var rank in ranks)
            rankFreq[rank]++;

        var repairedByRank = new long[101];
        repairedByRank.AsSpan().Fill(1L);

        var heap = new PriorityQueue<int, long>();
        for (var rank = 1; rank <= 100; rank++)
        {
            if (rankFreq[rank] != 0)
                heap.Enqueue(rank, rank);
        }

        long minRepairTime = 0;
        long totalRepairedCars = 0;
        while (totalRepairedCars < cars)
        {
            heap.TryDequeue(out var rank, out minRepairTime);
            totalRepairedCars += rankFreq[rank];
            repairedByRank[rank]++;
            var nextRepairTime = rank * repairedByRank[rank] * repairedByRank[rank];
            heap.Enqueue(rank, nextRepairTime);
        }
        return minRepairTime;
    }
}

[TestFixture]
public class HeapSolutionTests
{
    [TestCase(new[] { 4, 2, 3, 1 }, 10, 16)]
    [TestCase(new[] { 5, 1, 8 }, 6, 16)]
    public void Test(int[] ranks, int cars, long expected)
    {
        new HeapSolution().RepairCars(ranks, cars).Should().Be(expected);
    }

    [TestCaseSource(nameof(GetTestCases))]
    public void TestLargeInput(string ranks, int cars, int expected)
    {
        new HeapSolution().RepairCars(ranks.Array(), cars).Should().Be(expected);
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
