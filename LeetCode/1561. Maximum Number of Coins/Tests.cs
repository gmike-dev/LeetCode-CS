using System.IO;

namespace LeetCode._1561._Maximum_Number_of_Coins;

[TestFixture]
public class Tests
{
    [TestCase(new[] { 1, 1, 1 }, 1)]
    [TestCase(new[] { 2, 3, 3 }, 3)]
    [TestCase(new[] { 1, 1, 1, 2, 2, 4 }, 3)]
    [TestCase(new[] { 2, 4, 1, 2, 7, 8 }, 9)]
    [TestCase(new[] { 2, 4, 5 }, 4)]
    [TestCase(new[] { 9, 8, 7, 6, 5, 1, 2, 3, 4 }, 18)]
    [TestCase(new[] { 7, 5, 7, 7, 8, 8, 5, 10, 7 }, 22)]
    public void Test(int[] piles, int expected)
    {
        new SortSolution().MaxCoins(piles).Should().Be(expected);
        new LinearSolution().MaxCoins(piles).Should().Be(expected);
        new CountingSortSolution().MaxCoins(piles).Should().Be(expected);
    }

    [TestCaseSource(nameof(GetTestCases))]
    public void TestLargeInput(string piles, int expected)
    {
        new SortSolution().MaxCoins(piles.Array()).Should().Be(expected);
        new LinearSolution().MaxCoins(piles.Array()).Should().Be(expected);
        new CountingSortSolution().MaxCoins(piles.Array()).Should().Be(expected);
    }

    public static IEnumerable<object> GetTestCases()
    {
        string source = Path.Join(TestContext.CurrentContext.WorkDirectory,
            "1561. Maximum Number of Coins", "TestCases.txt");
        using var sr = new StreamReader(source);
        while (!sr.EndOfStream)
        {
            yield return new object[]
            {
                sr.ReadLine(),
                int.Parse(sr.ReadLine())
            };
        }
    }
}
