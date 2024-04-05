namespace LeetCode._844._Backspace_String_Compare;

[TestFixture]
public class Tests
{
  [TestCase("ab#c", "ad#c", true)]
  [TestCase("ab##", "c#d#", true)]
  [TestCase("a#c", "b", false)]
  [TestCase("##", "#", true)]
  public void Test(string s, string t, bool expected)
  {
    new BuildStringSolution().BackspaceCompare(s, t).Should().Be(expected);
  }
}
