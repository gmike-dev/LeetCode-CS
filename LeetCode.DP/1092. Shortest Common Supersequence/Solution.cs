namespace LeetCode.DP._1092._Shortest_Common_Supersequence;

public class Solution
{
  public string ShortestCommonSupersequence(string str1, string str2)
  {
    var m = str1.Length;
    var n = str2.Length;
    var dp = new int[m + 1][];
    for (var i = 0; i <= m; i++)
      dp[i] = new int[n + 1];
    for (var i = 0; i <= m; i++)
      dp[i][0] = i;
    for (var j = 0; j <= n; j++)
      dp[0][j] = j;
    for (var i = 1; i <= m; i++)
    {
      for (var j = 1; j <= n; j++)
      {
        if (str1[i - 1] == str2[j - 1])
          dp[i][j] = dp[i - 1][j - 1] + 1;
        else
          dp[i][j] = Math.Min(dp[i - 1][j], dp[i][j - 1]) + 1;
      }
    }
    var s = new Stack<char>();
    int x = m, y = n;
    while (x > 0 && y > 0)
    {
      if (str1[x - 1] == str2[y - 1])
      {
        x--;
        y--;
        s.Push(str1[x]);
      }
      else
      {
        s.Push(dp[x - 1][y] < dp[x][y - 1] ? str1[--x] : str2[--y]);
      }
    }
    while (x > 0)
      s.Push(str1[--x]);
    while (y > 0)
      s.Push(str2[--y]);
    return new string(s.ToArray());
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("abac", "cab", "cabac")]
  [TestCase("aaaaaaaa", "aaaaaaaa", "aaaaaaaa")]
  [TestCase("bcaaacbbbcbdcaddadcacbdddcdcccdadadcbabaccbccdcdcbcaccacbbdcbabb",
    "dddbbdcbccaccbababaacbcbacdddcdabadcacddbacadabdabcdbaaabaccbdaa",
    "dddbbdcaabccaccbababaacbdcbacddadcdacbdddcadccacdadbadcbabdaccbccdabcdcbcaccacbabdaccbdabba")]
  public void Test(string str1, string str2, string expected)
  {
    new Solution().ShortestCommonSupersequence(str1, str2).Should().Be(expected);
  }
}
