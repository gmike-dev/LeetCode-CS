namespace LeetCode._1861._Rotating_the_Box;

public class Solution
{
  public char[][] RotateTheBox(char[][] box)
  {
    var m = box.Length;
    var n = box[0].Length;
    var shiftedBox = new char[m][];
    for (var i = 0; i < m; i++)
    {
      shiftedBox[i] = new char[n];
      shiftedBox[i].AsSpan().Fill('.');
    }
    for (var i = 0; i < box.Length; i++)
    {
      var stones = 0;
      for (var j = 0; j < n; j++)
      {
        if (box[i][j] == '#')
        {
          stones++;
        }
        else if (box[i][j] == '*')
        {
          shiftedBox[i][j] = '*';
          shiftedBox[i].AsSpan(j - stones, stones).Fill('#');
          stones = 0;
        }
      }
      shiftedBox[i].AsSpan(n - stones, stones).Fill('#');
    }
    var result = new char[n][];
    for (var i = 0; i < n; i++)
      result[i] = new char[m];
    for (var j = 0; j < n; j++)
    {
      for (var i = 0; i < m; i++)
        result[j][m - i - 1] = shiftedBox[i][j];
    }
    return result;
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    new Solution().RotateTheBox([['#', '.', '#']]).Should().BeEquivalentTo(new char[][]
    {
      ['.'],
      ['#'],
      ['#']
    }, o => o.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    new Solution().RotateTheBox([
      ['#', '.', '*', '.'],
      ['#', '#', '*', '.']
    ]).Should().BeEquivalentTo(new char[][]
    {
      ['#', '.'],
      ['#', '#'],
      ['*', '*'],
      ['.', '.']
    }, o => o.WithStrictOrdering());
  }

  [Test]
  public void Test3()
  {
    new Solution().RotateTheBox([
      ['#', '#', '*', '.', '*', '.'],
      ['#', '#', '#', '*', '.', '.'],
      ['#', '#', '#', '.', '#', '.']
    ]).Should().BeEquivalentTo(new char[][]
    {
      ['.', '#', '#'],
      ['.', '#', '#'],
      ['#', '#', '*'],
      ['#', '*', '.'],
      ['#', '.', '*'],
      ['#', '.', '.']
    }, o => o.WithStrictOrdering());
  }
}
