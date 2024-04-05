namespace LeetCode._1071._Greatest_Common_Divisor_of_Strings;

[TestFixture]
public class Tests
{
  [TestCase("ABCABC", "ABC", "ABC")]
  [TestCase("ABABAB", "ABAB", "AB")]
  [TestCase("LEET", "CODE", "")]
  [TestCase("TAUXXTAUXXTAUXXTAUXXTAUXX", "TAUXXTAUXXTAUXXTAUXXTAUXXTAUXXTAUXXTAUXXTAUXX", "TAUXX")]
  public void Test(string s1, string s2, string result)
  {
    new Solution().GcdOfStrings(s1, s2).Should().Be(result);
    new Solution().GcdOfStrings_Bruteforce(s1, s2).Should().Be(result);
  }
}
