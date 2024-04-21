namespace LeetCode.__DP._3122._Minimum_Number_of_Operations_to_Satisfy_Conditions;

public class OptimizedDpSolution
{
  public int MinimumOperations(int[][] grid)
  {
    var n = grid.Length;
    var m = grid[0].Length;

    var count = new int[10];
    var prev = new int[10];
    var curr = new int[10];

    for (var j = 0; j < n; j++)
      count[grid[j][0]]++;

    for (var i = 0; i < 10; i++)
      curr[i] = n - count[i];

    for (var j = 1; j < m; j++)
    {
      (prev, curr) = (curr, prev);

      count.AsSpan().Clear();
      for (var i = 0; i < n; i++)
        count[grid[i][j]]++;

      for (var d = 0; d < 10; d++)
      {
        var min = int.MaxValue;
        for (var i = 0; i < 10; i++)
        {
          if (i != d)
            min = Math.Min(min, prev[i]);
        }
        curr[d] = min + n - count[d];
      }
    }

    return curr.Min();
  }
}

[TestFixture]
public class OptimizedDpSolutionTests
{
  [Test]
  public void Test1()
  {
    new OptimizedDpSolution().MinimumOperations(
    [
      [1, 0, 2],
      [1, 0, 2]
    ]).Should().Be(0);
  }

  [Test]
  public void Test2()
  {
    new OptimizedDpSolution().MinimumOperations(
    [
      [1, 1, 1],
      [0, 0, 0]
    ]).Should().Be(3);
  }

  [Test]
  public void Test3()
  {
    new OptimizedDpSolution().MinimumOperations(
    [
      [1],
      [2],
      [3]
    ]).Should().Be(2);
  }

  [Test]
  public void Test4()
  {
    new OptimizedDpSolution().MinimumOperations(
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
    new OptimizedDpSolution().MinimumOperations(
    [
      [8, 8],
      [8, 7]
    ]).Should().Be(1);
  }
}
