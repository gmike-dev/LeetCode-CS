using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._37._Sudoku_Solver;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    var board = new[]
    {
      new[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
      new[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
      new[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
      new[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
      new[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
      new[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
      new[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
      new[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
      new[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
    };

    new Solution().SolveSudoku(board);

    ToString(board).Should().Be(
      "5 3 4 6 7 8 9 1 2\n" +
      "6 7 2 1 9 5 3 4 8\n" +
      "1 9 8 3 4 2 5 6 7\n" +
      "8 5 9 7 6 1 4 2 3\n" +
      "4 2 6 8 5 3 7 9 1\n" +
      "7 1 3 9 2 4 8 5 6\n" +
      "9 6 1 5 3 7 2 8 4\n" +
      "2 8 7 4 1 9 6 3 5\n" +
      "3 4 5 2 8 6 1 7 9");
  }

  private string ToString(char[][] board)
  {
    return string.Join(Environment.NewLine, board.Select(row => string.Join(" ", row)));
  }
}