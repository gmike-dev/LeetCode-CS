using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._37._Sudoku_Solver;

[TestFixture]
public class Tests
{
  private static IEnumerable<object> _testCases = new[]
  {
    new[]
    {
      // Board
      "5 3 . . 7 . . . .\n" +
      "6 . . 1 9 5 . . .\n" +
      ". 9 8 . . . . 6 .\n" +
      "8 . . . 6 . . . 3\n" +
      "4 . . 8 . 3 . . 1\n" +
      "7 . . . 2 . . . 6\n" +
      ". 6 . . . . 2 8 .\n" +
      ". . . 4 1 9 . . 5\n" +
      ". . . . 8 . . 7 9",
      // Expected result
      "5 3 4 6 7 8 9 1 2\n" +
      "6 7 2 1 9 5 3 4 8\n" +
      "1 9 8 3 4 2 5 6 7\n" +
      "8 5 9 7 6 1 4 2 3\n" +
      "4 2 6 8 5 3 7 9 1\n" +
      "7 1 3 9 2 4 8 5 6\n" +
      "9 6 1 5 3 7 2 8 4\n" +
      "2 8 7 4 1 9 6 3 5\n" +
      "3 4 5 2 8 6 1 7 9"
    }
  };

  [TestCaseSource(nameof(_testCases))]
  public void SolveSudoku(string board, string expected)
  {
    var realBoard = FromString(board);
    new Solution().SolveSudoku(realBoard);
    ToString(realBoard).Should().Be(expected);
  }

  [TestCaseSource(nameof(_testCases))]
  public void SolveSudoku_SimpleRecursion(string board, string expected)
  {
    var realBoard = FromString(board);
    new Solution().SolveSudoku_SimpleRecursion(realBoard);
    ToString(realBoard).Should().Be(expected);
  }

  [TestCaseSource(nameof(_testCases))]
  public void SolveSudoku_Bitmasks(string board, string expected)
  {
    var realBoard = FromString(board);
    new Solution().SolveSudoku_Bitmasks(realBoard);
    ToString(realBoard).Should().Be(expected);
  }

  private static char[][] FromString(string board)
  {
    return board
      .Split('\n')
      .Select(s => s.Split(' ').Select(c => c[0]).ToArray())
      .ToArray();
  }

  private static string ToString(char[][] board)
  {
    return string.Join('\n', board.Select(row => string.Join(" ", row)));
  }
}