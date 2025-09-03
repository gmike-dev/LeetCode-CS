namespace LeetCode._36._Valid_Sudoku;

public class Solution2
{
  public bool IsValidSudoku(char[][] board)
  {
    var rowNums = new BitArray[9];
    var colNums = new BitArray[9];
    var blockNums = new BitArray[9];
    for (var i = 0; i < 9; i++)
    {
      rowNums[i] = new BitArray(9);
      colNums[i] = new BitArray(9);
      blockNums[i] = new BitArray(9);
    }
    for (var i = 0; i < 9; i++)
    for (var j = 0; j < 9; j++)
    {
      if (board[i][j] == '.')
        continue;
      var val = board[i][j] - '1';
      var k = 3 * (i / 3) + j / 3;
      if (rowNums[i][val] || colNums[j][val] || blockNums[k][val])
        return false;
      rowNums[i][val] = colNums[j][val] = blockNums[k][val] = true;
    }
    return true;
  }
}

[TestFixture]
public class Solution2Tests
{
  [Test]
  public void Test1()
  {
    new Solution2().IsValidSudoku([
      ['5', '3', '.', '.', '7', '.', '.', '.', '.'],
      ['6', '.', '.', '1', '9', '5', '.', '.', '.'],
      ['.', '9', '8', '.', '.', '.', '.', '6', '.'],
      ['8', '.', '.', '.', '6', '.', '.', '.', '3'],
      ['4', '.', '.', '8', '.', '3', '.', '.', '1'],
      ['7', '.', '.', '.', '2', '.', '.', '.', '6'],
      ['.', '6', '.', '.', '.', '.', '2', '8', '.'],
      ['.', '.', '.', '4', '1', '9', '.', '.', '5'],
      ['.', '.', '.', '.', '8', '.', '.', '7', '9']
    ]).Should().BeTrue();
  }

  [Test]
  public void Test2()
  {
    new Solution2().IsValidSudoku([
      ['8', '3', '.', '.', '7', '.', '.', '.', '.'],
      ['6', '.', '.', '1', '9', '5', '.', '.', '.'],
      ['.', '9', '8', '.', '.', '.', '.', '6', '.'],
      ['8', '.', '.', '.', '6', '.', '.', '.', '3'],
      ['4', '.', '.', '8', '.', '3', '.', '.', '1'],
      ['7', '.', '.', '.', '2', '.', '.', '.', '6'],
      ['.', '6', '.', '.', '.', '.', '2', '8', '.'],
      ['.', '.', '.', '4', '1', '9', '.', '.', '5'],
      ['.', '.', '.', '.', '8', '.', '.', '7', '9']
    ]).Should().BeFalse();
  }
}
