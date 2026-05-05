using System.IO;

namespace LeetCode._1072._Flip_Columns_For_Maximum_Number_of_Equal_Rows;

public class Solution
{
    public int MaxEqualRowsAfterFlips(int[][] matrix)
    {
        var n = matrix.Length;
        var m = matrix[0].Length;
        var used = new bool[n];
        var count = 0;
        for (var i = 0; i < n - 1; i++)
        {
            if (used[i])
                continue;
            var equalRows = 0;
            for (var j = i + 1; j < n; j++)
            {
                var d = 0;
                for (var k = 0; k < m; k++)
                    d += matrix[i][k] ^ matrix[j][k];
                if (d == 0 || d == m)
                {
                    used[j] = true;
                    equalRows++;
                }
            }
            if (equalRows > 0)
                count = Math.Max(count, equalRows + 1);
        }
        return Math.Max(1, count);
    }
}

[TestFixture]
public class SolutionTests
{
    [Test]
    public void Test1()
    {
        new Solution().MaxEqualRowsAfterFlips([[0, 1], [1, 1]]).Should().Be(1);
    }

    [Test]
    public void Test2()
    {
        new Solution().MaxEqualRowsAfterFlips([[0, 1], [1, 0]]).Should().Be(2);
    }

    [Test]
    public void Test3()
    {
        new Solution().MaxEqualRowsAfterFlips([[0, 0, 0], [0, 0, 1], [1, 1, 0]]).Should().Be(2);
    }

    [Test]
    public void Test4()
    {
        new Solution().MaxEqualRowsAfterFlips([
            [0, 0, 0],
            [0, 0, 0],
            [1, 1, 1],
            [1, 1, 1]
        ]).Should().Be(4);
    }

    [Test]
    public void Test5()
    {
        new Solution().MaxEqualRowsAfterFlips([
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
        new Solution().MaxEqualRowsAfterFlips([
            [0],
            [1]
        ]).Should().Be(2);
    }

    [Test]
    public void Test7()
    {
        new Solution().MaxEqualRowsAfterFlips([
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
        new Solution().MaxEqualRowsAfterFlips(matrix.Array2()).Should().Be(expected);
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
