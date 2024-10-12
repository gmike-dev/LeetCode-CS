namespace LeetCode.BinaryTrees._1905._Count_Sub_Islands;

public class Solution
{
  public int CountSubIslands(int[][] grid1, int[][] grid2)
  {
    int n = grid1.Length;
    int m = grid1[0].Length;
    bool[][] used = new bool[n][];
    for (var i = 0; i < n; i++)
      used[i] = new bool[m];
    int count = 0;
    for (var i = 0; i < n; i++)
    {
      for (var j = 0; j < m; j++)
      {
        if (grid2[i][j] != 0 && !used[i][j] && IsSubIsland(i, j))
          count++;
      }
    }
    return count;

    bool IsSubIsland(int i, int j)
    {
      if (i < 0 || i >= n || j < 0 || j >= m || grid2[i][j] == 0 || used[i][j])
        return true;
      used[i][j] = true;
      var up = IsSubIsland(i - 1, j);
      var down = IsSubIsland(i + 1, j);
      var left = IsSubIsland(i, j - 1);
      var right = IsSubIsland(i, j + 1);
      return grid1[i][j] != 0 && up && down && left && right;
    }
  }
}

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().CountSubIslands(
      [[1, 1, 1, 0, 0], [0, 1, 1, 1, 1], [0, 0, 0, 0, 0], [1, 0, 0, 0, 0], [1, 1, 0, 1, 1]],
      [[1, 1, 1, 0, 0], [0, 0, 1, 1, 1], [0, 1, 0, 0, 0], [1, 0, 1, 1, 0], [0, 1, 0, 1, 0]]).Should().Be(3);
  }

  [Test]
  public void Test2()
  {
    new Solution().CountSubIslands(
      [[1, 0, 1, 0, 1], [1, 1, 1, 1, 1], [0, 0, 0, 0, 0], [1, 1, 1, 1, 1], [1, 0, 1, 0, 1]],
      [[0, 0, 0, 0, 0], [1, 1, 1, 1, 1], [0, 1, 0, 1, 0], [0, 1, 0, 1, 0], [1, 0, 0, 0, 1]]).Should().Be(2);
  }
}
