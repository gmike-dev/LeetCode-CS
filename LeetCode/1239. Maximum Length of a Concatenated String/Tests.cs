namespace LeetCode._1239._Maximum_Length_of_a_Concatenated_String;

[TestFixture]
public class Tests
{
  [TestCase(new[] { "un", "iq", "ue" }, 4)]
  [TestCase(new[] { "cha", "r", "act", "ers" }, 6)]
  [TestCase(new[] { "abcdefghijklmnopqrstuvwxyz" }, 26)]
  public void Test1(string[] arr, int expected)
  {
    new BitmaskSolution().MaxLength(arr).Should().Be(expected);
  }
}
