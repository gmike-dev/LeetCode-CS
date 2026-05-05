using System.IO;

namespace LeetCode._1072._Flip_Columns_For_Maximum_Number_of_Equal_Rows;

public class LinearSolution2
{
    public int MaxEqualRowsAfterFlips(int[][] matrix)
    {
        return matrix.GroupBy(row => string.Join("", row.Select(x => x == row[0] ? '1' : '0'))).Max(g => g.Count());
    }
}

[TestFixture]
public class LinearSolution2Tests
{
    [Test]
    public void Test1()
    {
        new LinearSolution2().MaxEqualRowsAfterFlips([[0, 1], [1, 1]]).Should().Be(1);
    }

    [Test]
    public void Test2()
    {
        new LinearSolution2().MaxEqualRowsAfterFlips([[0, 1], [1, 0]]).Should().Be(2);
    }

    [Test]
    public void Test3()
    {
        new LinearSolution2().MaxEqualRowsAfterFlips([[0, 0, 0], [0, 0, 1], [1, 1, 0]]).Should().Be(2);
    }

    [Test]
    public void Test4()
    {
        new LinearSolution2().MaxEqualRowsAfterFlips([
            [0, 0, 0],
            [0, 0, 0],
            [1, 1, 1],
            [1, 1, 1]
        ]).Should().Be(4);
    }

    [Test]
    public void Test5()
    {
        new LinearSolution2().MaxEqualRowsAfterFlips([
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
        new LinearSolution2().MaxEqualRowsAfterFlips([
            [0],
            [1]
        ]).Should().Be(2);
    }

    [Test]
    public void Test7()
    {
        new LinearSolution2().MaxEqualRowsAfterFlips([
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
        new LinearSolution2().MaxEqualRowsAfterFlips(matrix.Array2()).Should().Be(expected);
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
