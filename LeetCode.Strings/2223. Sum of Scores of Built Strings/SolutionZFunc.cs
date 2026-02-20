namespace LeetCode.Strings._2223._Sum_of_Scores_of_Built_Strings;

public class SolutionZFunc
{
  public long SumScores(string s)
  {
    int[] z = ZFunc(s);
    long sum = s.Length;
    foreach (var c in z)
    {
      sum += c;
    }
    return sum;
  }

  private static int[] ZFunc(string s)
  {
    if (s.Length == 0)
      return [];
    int n = s.Length;
    int[] z = new int[n];
    int l = 0;
    int r = 0;
    for (int i = 1; i < n; ++i)
    {
      if (i <= r)
        z[i] = Math.Min(r - i + 1, z[i - l]);
      while (i + z[i] < n && s[z[i]] == s[i + z[i]])
        ++z[i];
      if (i + z[i] - 1 > r)
      {
        l = i;
        r = i + z[i] - 1;
      }
    }

    return z;
  }
}

[TestFixture]
public class SolutionZFuncTests
{
  [TestCase("babab", 9)]
  [TestCase("azbazbzaz", 14)]
  public void Test(string s, int expected)
  {
    new SolutionZFunc().SumScores(s).Should().Be(expected);
  }
}
