namespace LeetCode._85._Maximal_Rectangle;

public class Solution
{
  public int MaximalRectangle(char[][] matrix)
  {
    var n = matrix.Length;
    var m = matrix[0].Length;
    var width = new int[n, m];
    var height = new int[n, m];

    for (var i = 0; i < n; i++)
    {
      width[i, 0] = matrix[i][0] - '0';
      for (var j = 1; j < m; j++)
      {
        if (matrix[i][j] == '1')
          width[i, j] = width[i, j - 1] + 1;
      }
    }
    for (var j = 0; j < m; j++)
    {
      height[0, j] = matrix[0][j] - '0';
      for (var i = 1; i < n; i++)
      {
        if (matrix[i][j] == '1')
          height[i, j] = height[i - 1, j] + 1;
      }
    }

    var result = 0;
    for (var i = 0; i < n; i++)
    {
      for (var j = 0; j < m; j++)
      {
        var mh = int.MaxValue;
        var s = 0;
        for (var w = 0; w < width[i, j]; w++)
        {
          mh = Math.Min(mh, height[i, j - w]);
          s = Math.Max(s, mh * (w + 1));
        }
        result = Math.Max(result, s);
      }
    }
    return result;
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    new Solution().MaximalRectangle(
      [
        ['1', '0', '1', '0', '0'],
        ['1', '0', '1', '1', '1'],
        ['1', '1', '1', '1', '1'],
        ['1', '0', '0', '1', '0']
      ])
      .Should().Be(6);
  }

  [Test]
  public void Test2()
  {
    new Solution().MaximalRectangle([['0']]).Should().Be(0);
  }

  [Test]
  public void Test3()
  {
    new Solution().MaximalRectangle([['1']]).Should().Be(1);
  }

  [Test]
  public void Test4()
  {
    new Solution().MaximalRectangle([['0', '1']]).Should().Be(1);
  }

  [Test]
  public void Test37()
  {
    new Solution().MaximalRectangle(
      [
        ['1', '0', '1', '1', '1'],
        ['0', '1', '0', '1', '0'],
        ['1', '1', '0', '1', '1'],
        ['1', '1', '0', '1', '1'],
        ['0', '1', '1', '1', '1']
      ])
      .Should().Be(6);
  }
}
