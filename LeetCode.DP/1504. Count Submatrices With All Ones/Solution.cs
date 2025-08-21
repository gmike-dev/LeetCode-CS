using LeetCode.Common;

namespace LeetCode.DP._1504._Count_Submatrices_With_All_Ones;

public class Solution
{
  public int NumSubmat(int[][] a)
  {
    var n = a.Length;
    var m = a[0].Length;
    Span<int> cnt = stackalloc int[m];
    var result = 0;
    for (var i = 0; i < n; i++)
    {
      for (var j = 0; j < m; j++)
      {
        if (a[i][j] == 0)
        {
          cnt[j] = 0;
        }
        else
        {
          cnt[j]++;
          var c = cnt[j];
          for (var k = j; k >= 0 && cnt[k] != 0; k--)
          {
            c = Math.Min(c, cnt[k]);
            result += c;
          }
        }
      }
    }
    return result;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("[[1,0,1],[1,1,0],[1,1,0]]", 13)]
  [TestCase("[[0,1,1,0],[0,1,1,1],[1,1,1,0]]", 24)]
  public void Test(string a, int expected)
  {
    new Solution().NumSubmat(a.Array2()).Should().Be(expected);
  }
}
