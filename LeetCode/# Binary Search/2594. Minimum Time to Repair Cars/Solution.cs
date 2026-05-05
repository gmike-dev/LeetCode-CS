using System.IO;

namespace LeetCode.__Binary_Search._2594._Minimum_Time_to_Repair_Cars;

/// <summary>
/// <see href="https://leetcode.com/problems/minimum-time-to-repair-cars/"/>
/// </summary>
public class Solution
{
    public long RepairCars(int[] ranks, int cars)
    {
        long minTime = 0;
        long maxTime = (long)ranks.Max() * cars * cars;
        while (minTime < maxTime)
        {
            var time = minTime + (maxTime - minTime) / 2;
            var carsRepaired = ranks.Sum(rank => (long)Math.Sqrt((double)time / rank));
            if (carsRepaired >= cars)
                maxTime = time;
            else
                minTime = time + 1;
        }
        return maxTime;
    }
}

[TestFixture]
public class SolutionTests
{
    [TestCase(new[] { 4, 2, 3, 1 }, 10, 16)]
    [TestCase(new[] { 5, 1, 8 }, 6, 16)]
    public void Test(int[] ranks, int cars, long expected)
    {
        new Solution().RepairCars(ranks, cars).Should().Be(expected);
    }

    [TestCaseSource(nameof(GetTestCases))]
    public void TestLargeInput(string ranks, int cars, int expected)
    {
        new Solution().RepairCars(ranks.Array(), cars).Should().Be(expected);
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
