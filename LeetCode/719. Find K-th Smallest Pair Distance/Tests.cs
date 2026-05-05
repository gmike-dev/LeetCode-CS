using System.IO;

namespace LeetCode._719._Find_K_th_Smallest_Pair_Distance;

[TestFixture]
public class Tests
{
    [TestCase(new[] { 1, 3, 1 }, 1, 0)]
    [TestCase(new[] { 1, 3, 1 }, 2, 2)]
    [TestCase(new[] { 1, 3, 1 }, 3, 2)]
    [TestCase(new[] { 1, 1, 1 }, 2, 0)]
    [TestCase(new[] { 1, 6, 1 }, 3, 5)]
    public void Test(int[] nums, int k, int expected)
    {
        new Solution().SmallestDistancePair(nums, k).Should().Be(expected);
        new BinarySearchSolution().SmallestDistancePair(nums, k).Should().Be(expected);
    }

    [TestCaseSource(nameof(GetTestCases))]
    public void TestLargeInput(string nums, int k, int expected)
    {
        new Solution().SmallestDistancePair(nums.Array(), k).Should().Be(expected);
        new BinarySearchSolution().SmallestDistancePair(nums.Array(), k).Should().Be(expected);
    }

    public static IEnumerable<object> GetTestCases()
    {
        string source = Path.Join(TestContext.CurrentContext.WorkDirectory,
            "719. Find K-th Smallest Pair Distance", "TestCases.txt");
        using var sr = new StreamReader(source);
        while (!sr.EndOfStream)
        {
            yield return new object[]
            {
                sr.ReadLine() ?? throw new InvalidOperationException(),
                int.Parse(sr.ReadLine() ?? throw new InvalidOperationException()),
                int.Parse(sr.ReadLine() ?? throw new InvalidOperationException())
            };
        }
    }
}
