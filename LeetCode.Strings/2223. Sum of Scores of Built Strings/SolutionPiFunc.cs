namespace LeetCode.Strings._2223._Sum_of_Scores_of_Built_Strings;

public class SolutionPiFunc
{
  public long SumScores(string s)
  {
    int[] pi = PiFunc(s);
    int n = s.Length;
    int[] count = new int[n];
    for (var i = 0; i < n; i++)
    {
      if (pi[i] > 0)
      {
        count[i] = count[pi[i] - 1] + 1;
      }
    }
    long sum = n;
    foreach (var c in count)
    {
      sum += c;
    }
    return sum;
  }

  private int[] PiFunc(string s)
  {
    int n = s.Length;
    int[] pi = new int[n];
    int i = 1;
    int len = 0;
    while (i < n)
    {
      if (s[i] == s[len])
      {
        len++;
        pi[i] = len;
        i++;
      }
      else if (len > 0)
      {
        len = pi[len - 1];
      }
      else
      {
        i++;
      }
    }
    return pi;
  }
}

[TestFixture]
public class SolutionPiFuncTests
{
  [TestCase("babab", 9)]
  [TestCase("azbazbzaz", 14)]
  public void Test(string s, int expected)
  {
    new SolutionPiFunc().SumScores(s).Should().Be(expected);
  }
}
