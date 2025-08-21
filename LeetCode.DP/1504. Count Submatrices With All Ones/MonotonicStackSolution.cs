using LeetCode.Common;

namespace LeetCode.DP._1504._Count_Submatrices_With_All_Ones;

public class MonotonicStackSolution
{
  private struct StackItem(int val, int count, int sum)
  {
    public readonly int Val = val;
    public readonly int Count = count;
    public readonly int Sum = sum;
  }

  public int NumSubmat(int[][] a)
  {
    var n = a.Length;
    var m = a[0].Length;
    Span<int> cnt = stackalloc int[m];
    var s = new Stack<StackItem>(m);
    var result = 0;
    for (var i = 0; i < n; i++)
    {
      for (var j = 0; j < m; j++)
      {
        if (a[i][j] == 0)
        {
          cnt[j] = 0;
          s.Clear();
        }
        else
        {
          cnt[j]++;
          var val = cnt[j];
          var count = 1;
          StackItem top;
          while (s.TryPeek(out top) && top.Val >= val)
          {
            count += top.Count;
            s.Pop();
          }
          top = new StackItem(val, count, top.Sum + count * val);
          s.Push(top);
          result += top.Sum;
        }
      }
      s.Clear();
    }
    return result;
  }
}

[TestFixture]
public class MonotonicStackSolutionTests
{
  [TestCase("[[1,0,1],[1,1,0],[1,1,0]]", 13)]
  [TestCase("[[0,1,1,0],[0,1,1,1],[1,1,1,0]]", 24)]
  public void Test(string a, int expected)
  {
    new MonotonicStackSolution().NumSubmat(a.Array2()).Should().Be(expected);
  }
}
