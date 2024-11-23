namespace LeetCode._1861._Rotating_the_Box;

public class Solution2
{
  public char[][] RotateTheBox(char[][] box)
  {
    var m = box.Length;
    var n = box[0].Length;
    var result = new char[n][];
    for (var i = 0; i < n; i++)
    {
      result[i] = new char[m];
      result[i].AsSpan().Fill('.');
    }
    for (var i = 0; i < m; i++)
    {
      var lowestEmptyRow = n - 1;
      for (var j = n - 1; j >= 0; j--)
      {
        switch (box[i][j])
        {
          case '#':
            result[lowestEmptyRow--][m - i - 1] = '#';
            break;
          case '*':
            result[j][m - i - 1] = '*';
            lowestEmptyRow = j - 1;
            break;
        }
      }
    }
    return result;
  }
}

[TestFixture]
public class Solution2Tests
{
  [Test]
  public void Test1()
  {
    new Solution2().RotateTheBox([['#', '.', '#']]).Should().BeEquivalentTo(new char[][]
    {
      ['.'],
      ['#'],
      ['#']
    }, o => o.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    new Solution2().RotateTheBox([
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
    new Solution2().RotateTheBox([
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
