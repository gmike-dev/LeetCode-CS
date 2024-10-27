namespace LeetCode.DP._1277._Count_Square_Submatrices_with_All_Ones;

using static System.Math;

public class Solution2
{
  public int CountSquares(int[][] matrix)
  {
    var m = matrix.Length;
    var n = matrix[0].Length;
    var prev = new int[n + 1];
    var curr = new int[n + 1];
    var count = 0;
    for (var i = 0; i < m; i++)
    {
      for (var j = 0; j < n; j++)
      {
        var val = matrix[i][j] == 0 ? 0 : Min(curr[j], Min(prev[j], prev[j + 1])) + 1;
        curr[j + 1] = val;
        count += val;
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
