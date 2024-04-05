namespace LeetCode._62._Unique_Paths;

public class SolutionUsingDp
{
  public int UniquePaths(int m, int n)
  {
    var s = new int[n];
    Array.Fill(s, 1);
    for (var i = 1; i < m; i++)
    {
      for (var j = 1; j < n; j++)
        s[j] += s[j - 1];
    }
    return s[^1];
  }
}
