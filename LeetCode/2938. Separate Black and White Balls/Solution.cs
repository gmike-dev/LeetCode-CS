namespace LeetCode._2938._Separate_Black_and_White_Balls;

public class Solution
{
  public long MinimumSteps(string s)
  {
    var a = s.ToCharArray();
    var steps = 0L;
    for (int i = 0, j = 0; i < s.Length; i++)
    {
      if (a[i] == '1')
      {
        for (j = Math.Max(j, i + 1); j < s.Length; j++)
        {
          if (a[j] == '0')
          {
            (a[i], a[j]) = (a[j], a[i]);
            steps += j - i;
            break;
          }
        }
      }
    }
    return steps;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("101", 1)]
  [TestCase("100", 2)]
  [TestCase("0", 0)]
  [TestCase("1", 0)]
  [TestCase("10", 1)]
  [TestCase("010101", 3)]
  public void Test(string s, int expected)
  {
    new Solution().MinimumSteps(s).Should().Be(expected);
  }
}
