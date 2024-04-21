namespace LeetCode.__DP._3122._Minimum_Number_of_Operations_to_Satisfy_Conditions;

public class MemoizationSolution
{
  public int MinimumOperations(int[][] grid)
  {
    var n = grid.Length;
    var m = grid[0].Length;
    var count = new int[m, 10];
    for (var i = 0; i < n; i++)
    for (var j = 0; j < m; j++)
      count[j, grid[i][j]]++;

    var cache = new Dictionary<(int, int), int>();
    return F(m - 1, -1);

    int F(int col, int right)
    {
      if (col < 0)
        return 0;

      var key = (col, right);
      if (cache.TryGetValue(key, out var result))
        return result;

      result = int.MaxValue;
      for (var d = 0; d <= 9; d++)
      {
        if (d != right)
        {
          result = Math.Min(result, F(col - 1, d) + n - count[col, d]);
        }
      }
      cache[key] = result;
      return result;
    }
  }
}

[TestFixture]
public class MemoizationSolutionTests
{
  [Test]
  public void Test1()
  {
    new MemoizationSolution().MinimumOperations(
    [
      [1, 0, 2],
      [1, 0, 2]
    ]).Should().Be(0);
  }

  [Test]
  public void Test2()
  {
    new MemoizationSolution().MinimumOperations(
    [
      [1, 1, 1],
      [0, 0, 0]
    ]).Should().Be(3);
  }

  [Test]
  public void Test3()
  {
    new MemoizationSolution().MinimumOperations(
    [
      [1],
      [2],
      [3]
    ]).Should().Be(2);
  }

  [Test]
  public void Test4()
  {
    new MemoizationSolution().MinimumOperations(
    [
      [1, 1],
      [1, 1],
      [1, 0],
      [0, 0],
      [1, 1],
    ]).Should().Be(4);
  }

  [Test]
  public void Test5()
  {
    new MemoizationSolution().MinimumOperations(
    [
      [8, 8],
      [8, 7]
    ]).Should().Be(1);
  }
}
