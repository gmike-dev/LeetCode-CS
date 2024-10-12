namespace LeetCode.Strings._2696._Minimum_String_Length_After_Removing_Substrings;

public class StackSolution
{
  public int MinLength(string s)
  {
    var stack = new Stack<char>();
    foreach (var c in s)
    {
      if (stack.TryPeek(out var sc) && (sc == 'A' && c == 'B' || sc == 'C' && c == 'D'))
        stack.Pop();
      else
        stack.Push(c);
    }
    return stack.Count;
  }
}

[TestFixture]
public class StackSolutionTests
{
  [TestCase("ABFCACDB", 2)]
  [TestCase("ACBBD", 5)]
  public void Test(string s, int expected)
  {
    new StackSolution().MinLength(s).Should().Be(expected);
  }
}
