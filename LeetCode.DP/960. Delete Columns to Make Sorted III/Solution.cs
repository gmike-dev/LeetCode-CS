namespace LeetCode.DP._960._Delete_Columns_to_Make_Sorted_III;

public class Solution
{
  public int MinDeletionSize(string[] strs)
  {
    var n = strs.Length;
    var m = strs[0].Length;
    Span<int> dp = stackalloc int[m];
    dp.Fill(1);
    var maxLen = 1;
    for (var i = 1; i < m; i++)
    {
      for (var j = 0; j < i; j++)
      {
        var ok = true;
        for (var k = 0; k < n; k++)
        {
          if (strs[k][j] > strs[k][i])
          {
            ok = false;
            break;
          }
        }
        if (ok)
        {
          dp[i] = Math.Max(dp[i], dp[j] + 1);
        }
      }
      maxLen = Math.Max(maxLen, dp[i]);
    }
    return m - maxLen;
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    new Solution().MinDeletionSize(["babca", "bbazb"]).Should().Be(3);
  }

  [Test]
  public void Test2()
  {
    new Solution().MinDeletionSize(["edcba"]).Should().Be(4);
  }

  [Test]
  public void Test3()
  {
    new Solution().MinDeletionSize(["ghi", "def", "abc"]).Should().Be(0);
  }
}
