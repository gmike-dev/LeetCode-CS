namespace LeetCode.__LinkedLists._2326._Spiral_Matrix_IV;

public class Solution
{
  public int[][] SpiralMatrix(int m, int n, ListNode head)
  {
    var result = Enumerable.Range(0, m).Select(_ => new int[n]).ToArray();
    var dx = new[] { 1, 0, -1, 0 };
    var dy = new[] { 0, 1, 0, -1 };
    var dir = 0;
    var topLeftX = 0;
    var topLeftY = 0;
    var bottomRightX = n - 1;
    var bottomRightY = m - 1;
    var posX = 0;
    var posY = 0;
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

        switch (dir)
        {
          case 0 when posX == bottomRightX:
          case 1 when posY == bottomRightY:
          case 2 when posX == topLeftX:
            dir++;
            break;
          case 3 when posY == topLeftY + 1:
            dir = 0;
            topLeftX++;
            topLeftY++;
            bottomRightX--;
            bottomRightY--;
            break;
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
