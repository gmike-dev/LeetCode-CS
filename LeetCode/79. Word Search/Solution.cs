namespace LeetCode._79._Word_Search;

public class Solution
{
  public bool Exist(char[][] board, string word)
  {
    var m = board.Length;
    var n = board[0].Length;
    var used = new bool[m][];
    for (var i = 0; i < m; i++)
      used[i] = new bool[n];
    for (var i = 0; i < m; i++)
    {
      for (var j = 0; j < n; j++)
      {
        if (Find(i, j, 0))
          return true;
      }
    }
    return false;

    bool Find(int row, int col, int pos)
    {
      if (pos == word.Length)
        return true;

      if (row < 0 || row >= m || col < 0 || col >= n || used[row][col] || board[row][col] != word[pos])
        return false;

      used[row][col] = true;
      var result = Find(row - 1, col, pos + 1) || Find(row + 1, col, pos + 1) ||
                   Find(row, col - 1, pos + 1) || Find(row, col + 1, pos + 1);
      used[row][col] = false;
      return result;
    }
  }
}

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().Exist(new[]
    {
      new[] { 'A', 'B', 'C', 'E' },
      new[] { 'S', 'F', 'C', 'S' },
      new[] { 'A', 'D', 'E', 'E' }
    }, "ABCCED").Should().BeTrue();
  }

  [Test]
  public void Test2()
  {
    new Solution().Exist(new[]
      {
        new[] { 'A', 'B', 'C', 'E' },
        new[] { 'S', 'F', 'C', 'S' },
        new[] { 'A', 'D', 'E', 'E' }
      }
      , "SEE").Should().BeTrue();
  }

  [Test]
  public void Test3()
  {
    new Solution().Exist(new[]
      {
        new[] { 'A', 'B', 'C', 'E' },
        new[] { 'S', 'F', 'C', 'S' },
        new[] { 'A', 'D', 'E', 'E' }
      }
      , "ABCB").Should().BeFalse();
  }
}
