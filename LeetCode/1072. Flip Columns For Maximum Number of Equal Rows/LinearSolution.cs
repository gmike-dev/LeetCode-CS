using System.IO;

namespace LeetCode._1072._Flip_Columns_For_Maximum_Number_of_Equal_Rows;

public class LinearSolution
{
    public int MaxEqualRowsAfterFlips(int[][] matrix)
    {
        var counter = new Dictionary<string, int>();
        foreach (var row in matrix)
        {
            var origStr = string.Join("", row);
            var invertedStr = string.Join("", row.Select(x => 1 - x));
            counter[origStr] = counter.GetValueOrDefault(origStr) + 1;
            counter[invertedStr] = counter.GetValueOrDefault(invertedStr) + 1;
        }
        return counter.Values.Max();
    }
}

[TestFixture]
public class LinearSolutionTests
{
    [Test]
    public void Test1()
    {
        new LinearSolution().MaxEqualRowsAfterFlips([[0, 1], [1, 1]]).Should().Be(1);
    }

    [Test]
    public void Test2()
    {
        new LinearSolution().MaxEqualRowsAfterFlips([[0, 1], [1, 0]]).Should().Be(2);
    }

    [Test]
    public void Test3()
    {
        new LinearSolution().MaxEqualRowsAfterFlips([[0, 0, 0], [0, 0, 1], [1, 1, 0]]).Should().Be(2);
    }

    [Test]
    public void Test4()
    {
        new LinearSolution().MaxEqualRowsAfterFlips([
            [0, 0, 0],
            [0, 0, 0],
            [1, 1, 1],
            [1, 1, 1]
        ]).Should().Be(4);
    }

    [Test]
    public void Test5()
    {
        new LinearSolution().MaxEqualRowsAfterFlips([
            [0, 1, 0],
            [0, 1, 0],
            [1, 1, 0],
            [1, 1, 1],
            [1, 1, 0],
            [0, 0, 1]
        ]).Should().Be(3);
    }

    [Test]
    public void Test6()
    {
        new LinearSolution().MaxEqualRowsAfterFlips([
            [0],
            [1]
        ]).Should().Be(2);
    }

    [Test]
    public void Test7()
    {
        new LinearSolution().MaxEqualRowsAfterFlips([
            [1, 0, 0, 0, 1, 1, 1, 0, 1, 1, 1],
            [1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0],
            [1, 0, 0, 0, 1, 1, 1, 0, 1, 1, 1],
            [1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0],
            [1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1]
        ]).Should().Be(2);
    }

    [TestCaseSource(nameof(GetTestCases))]
    public void TestLargeInput(string matrix, int expected)
    {
        new LinearSolution().MaxEqualRowsAfterFlips(matrix.Array2()).Should().Be(expected);
    }

    public static IEnumerable<object> GetTestCases()
    {
        string source = Path.Join(TestContext.CurrentContext.WorkDirectory,
            "1072. Flip Columns For Maximum Number of Equal Rows", "TestCases.txt");
        using var sr = new StreamReader(source);
        while (!sr.EndOfStream)
        {
            yield return new object[]
            {
                sr.ReadLine() ?? throw new InvalidOperationException(),
                int.Parse(sr.ReadLine() ?? throw new InvalidOperationException())
            };
        }
    }
}
