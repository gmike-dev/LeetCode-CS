namespace LeetCode.__LinkedLists._2326._Spiral_Matrix_IV;

public class Solution
{
  public int[][] SpiralMatrix(int m, int n, ListNode head)
  {
    var dx = new[] { 1, 0, -1, 0 };
    var dy = new[] { 0, 1, 0, -1 };
    var dir = 0;

    var result = Enumerable.Range(0, m).Select(_ => new int[n]).ToArray();
    var topLeftX = 0;
    var topLeftY = 0;
    var posX = 0;
    var posY = 0;
    var width = n;
    var height = m;
    for (var i = 0; i < m; i++)
    {
      for (var j = 0; j < n; j++)
      {
        if (head == null)
        {
          result[posY][posX] = -1;
        }
        else
        {
          result[posY][posX] = head.val;
          head = head.next;
        }

        if (dir == 0)
        {
          if (posX == topLeftX + width - 1)
            dir = 1;
        }
        else if (dir == 1)
        {
          if (posY == topLeftY + height - 1)
            dir = 2;
        }
        else if (dir == 2)
        {
          if (posX == topLeftX)
            dir = 3;
        }
        else if (dir == 3)
        {
          if (posY == topLeftY + 1)
          {
            dir = 0;
            topLeftX++;
            topLeftY++;
            width -= 2;
            height -= 2;
          }
        }

        posX += dx[dir];
        posY += dy[dir];
      }
    }
    return result;
  }
}

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    int[][] expected =
    [
      [3, 0, 2, 6, 8],
      [5, 0, -1, -1, 1],
      [5, 2, 4, 9, 7]
    ];
    new Solution().SpiralMatrix(3, 5, ListNode.FromString("[3,0,2,6,8,1,7,9,4,2,5,5,0]"))
      .Should()
      .BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    int[][] expected = [[0, 1, 2, -1]];
    new Solution().SpiralMatrix(1, 4, ListNode.FromString("[0,1,2]"))
      .Should()
      .BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }

  [Test]
  public void Test3()
  {
    int[][] expected = [[1]];
    new Solution().SpiralMatrix(1, 1, ListNode.FromString("[1,2,3]"))
      .Should()
      .BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }

  [Test]
  public void Test4()
  {
    int[][] expected = [[-1]];
    new Solution().SpiralMatrix(1, 1, ListNode.FromString("[]"))
      .Should()
      .BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }

  [Test]
  public void Test5()
  {
    int[][] expected = [[-1], [-1], [-1]];
    new Solution().SpiralMatrix(3, 1, ListNode.FromString("[]"))
      .Should()
      .BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }

  [Test]
  public void Test6()
  {
    int[][] expected = [[1], [2], [3]];
    new Solution().SpiralMatrix(3, 1, ListNode.FromString("[1,2,3]"))
      .Should()
      .BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
