namespace LeetCode._85._Maximal_Rectangle;

public class SpaceOptimizedSolution
{
  public int MaximalRectangle(char[][] matrix)
  {
    var n = matrix.Length;
    var m = matrix[0].Length;
    var height = new int[m];

    var result = 0;
    for (var i = 0; i < n; i++)
    {
      for (var j = 0; j < m; j++)
      {
        if (matrix[i][j] == '1')
        {
          height[j]++;
          var h = height[j];
          var w = 1;
          var s = h;
          for (var k = j - 1; k >= 0 && matrix[i][k] == '1'; k--)
          {
            w++;
            h = Math.Min(h, height[k]);
            s = Math.Max(s, w * h);
          }
          result = Math.Max(result, s);
        }
        else
        {
          height[j] = 0;
        }
      }
    }
    return result;
  }
}

[TestFixture]
public class SpaceOptimizedSolutionTests
{
  [Test]
  public void Test1()
  {
    new SpaceOptimizedSolution().MaximalRectangle(
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
    new SpaceOptimizedSolution().MaximalRectangle([['0']]).Should().Be(0);
  }

  [Test]
  public void Test3()
  {
    new SpaceOptimizedSolution().MaximalRectangle([['1']]).Should().Be(1);
  }

  [Test]
  public void Test4()
  {
    new SpaceOptimizedSolution().MaximalRectangle([['0', '1']]).Should().Be(1);
  }

  [Test]
  public void Test37()
  {
    new SpaceOptimizedSolution().MaximalRectangle(
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
