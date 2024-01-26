using System;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._576._Out_of_Boundary_Paths;

public class RecursiveSolution
{
  public int FindPaths(int m, int n, int maxMove, int startRow, int startColumn)
  {
    const int mod = (int)1e9 + 7;
    var cache = new int[maxMove + 1][][];
    for (var i = 0; i < maxMove + 1; i++)
    {
      cache[i] = new int[m][];
      for (var j = 0; j < m; j++)
      {
        cache[i][j] = new int[n];
        Array.Fill(cache[i][j], -1);
      }
    }
    return F(maxMove, startRow, startColumn);

    int F(int moves, int row, int col)
    {
      if (row < 0 || col < 0 || row == m || col == n)
        return 1;
      if (moves == 0)
        return 0;
      var result = cache[moves][row][col];
      if (result < 0)
      {
        result = (((F(moves - 1, row - 1, col) + F(moves - 1, row, col - 1)) % mod +
                   F(moves - 1, row, col + 1)) % mod + F(moves - 1, row + 1, col)) % mod;
        cache[moves][row][col] = result;
      }
      return result;
    }
  }
}

[TestFixture]
public class RecursiveSolutionTests
{
  [TestCase(2, 2, 2, 0, 0, 6)]
  [TestCase(1, 3, 3, 0, 1, 12)]
  [TestCase(45, 35, 47, 20, 31, 951853874)]
  public void Test(int m, int n, int maxMove, int startRow, int startColumn, int expected)
  {
    new RecursiveSolution().FindPaths(m, n, maxMove, startRow, startColumn).Should().Be(expected);
  }
}