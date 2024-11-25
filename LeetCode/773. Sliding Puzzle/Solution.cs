namespace LeetCode._773._Sliding_Puzzle;

public class Solution
{
  private static readonly int[] Dr = [1, -1, 0, 0];
  private static readonly int[] Dc = [0, 0, 1, -1];

  public int SlidingPuzzle(int[][] board)
  {
    var moves = 0;
    var used = new HashSet<string>();
    var q = new Queue<int[][]>();
    q.Enqueue(board);
    while (q.Count != 0)
    {
      var n = q.Count;
      for (var i = 0; i < n; i++)
      {
        var b = q.Dequeue();
        if (IsSolved(b))
          return moves;
        foreach (var next in GetNext(b))
        {
          var s = GetState(next);
          if (used.Add(s))
            q.Enqueue(next);
        }
      }
      moves++;
    }
    return -1;
  }

  private IEnumerable<int[][]> GetNext(int[][] board)
  {
    for (var i = 0; i < 2; i++)
    {
      for (var j = 0; j < 3; j++)
      {
        if (board[i][j] == 0)
        {
          for (var k = 0; k < 4; k++)
          {
            var r = i + Dr[k];
            var c = j + Dc[k];
            if (r >= 0 && c >= 0 && r < 2 && c < 3)
            {
              var item = new int[2][];
              for (var row = 0; row < 2; row++)
                item[row] = (int[])board[row].Clone();
              (item[i][j], item[r][c]) = (item[r][c], item[i][j]);
              yield return item;
            }
          }
          yield break;
        }
      }
    }
  }

  private static string GetState(int[][] board)
  {
    return string.Concat(board.SelectMany(c => c));
  }

  private static bool IsSolved(int[][] board)
  {
    return string.Equals(GetState(board), "123450", StringComparison.Ordinal);
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    new Solution().SlidingPuzzle([[1, 2, 3], [4, 0, 5]]).Should().Be(1);
  }

  [Test]
  public void Test2()
  {
    new Solution().SlidingPuzzle([[1, 2, 3], [5, 4, 0]]).Should().Be(-1);
  }

  [Test]
  public void Test3()
  {
    new Solution().SlidingPuzzle([[4, 1, 2], [5, 0, 3]]).Should().Be(5);
  }
}
