namespace LeetCode.DP._1277._Count_Square_Submatrices_with_All_Ones;

public class Solution2
{
  public int CountSquares(int[][] matrix)
  {
    var m = matrix.Length;
    var n = matrix[0].Length;
    var prev = new int[n];
    var curr = new int[n];
    var count = 0;
    for (var j = 0; j < n; j++)
    {
      prev[j] = matrix[0][j];
      count += matrix[0][j];
    }
    for (var i = 1; i < m; i++)
    {
      curr[0] = matrix[i][0];
      count += matrix[i][0];
      for (var j = 1; j < n; j++)
      {
        if (matrix[i][j] == 0)
        {
          curr[j] = 0;
        }
        else
        {
          curr[j] = Math.Min(curr[j - 1], Math.Min(prev[j - 1], prev[j])) + 1;
          count += curr[j];
        }
      }
      (prev, curr) = (curr, prev);
    }
    return count;
  }
}

[TestFixture]
public class Solution2Tests
{
  [Test]
  public void Test1()
  {
    new Solution2().CountSquares([
      [0, 1, 1, 1],
      [1, 1, 1, 1],
      [0, 1, 1, 1]
    ]).Should().Be(15);
  }

  [Test]
  public void Test2()
  {
    new Solution2().CountSquares([
      [1, 0, 1],
      [1, 1, 0],
      [1, 1, 0]
    ]).Should().Be(7);
  }
}
