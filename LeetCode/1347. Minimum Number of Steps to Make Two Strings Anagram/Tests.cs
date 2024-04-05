namespace LeetCode._1347._Minimum_Number_of_Steps_to_Make_Two_Strings_Anagram;

[TestFixture]
public class Tests
{
  [TestCase("bab", "aba", 1)]
  [TestCase("leetcode", "practice", 5)]
  [TestCase("anagram", "mangaar", 0)]
  public void Test(string s, string t, int expected)
  {
    new SolutionV1().MinSteps(s, t).Should().Be(expected);
    new SolutionV2().MinSteps(s, t).Should().Be(expected);
  }
}
