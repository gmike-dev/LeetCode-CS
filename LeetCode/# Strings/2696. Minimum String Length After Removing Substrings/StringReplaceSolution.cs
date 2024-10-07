namespace LeetCode.__Strings._2696._Minimum_String_Length_After_Removing_Substrings;

public class StringReplaceSolution
{
  public int MinLength(string s)
  {
    while (true)
    {
      var ss = s.Replace("AB", "").Replace("CD", "");
      if (ss.Length == s.Length)
        return ss.Length;
      s = ss;
    }
  }
}

[TestFixture]
public class StringReplaceSolutionTests
{
  [TestCase("ABFCACDB", 2)]
  [TestCase("ACBBD", 5)]
  public void Test(string s, int expected)
  {
    new StringReplaceSolution().MinLength(s).Should().Be(expected);
  }
}
