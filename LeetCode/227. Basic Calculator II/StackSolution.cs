namespace LeetCode._227._Basic_Calculator_II;

public class StackSolution
{
  public int Calculate(string s)
  {
    var stack = new Stack<int>();
    var val = 0;
    var op = '+';
    foreach (var c in s)
    {
      if (c == ' ')
        continue;
      if (char.IsDigit(c))
      {
        val = val * 10 + c - '0';
      }
      else
      {
        stack.Push(Calc());
        op = c;
        val = 0;
      }
    }
    stack.Push(Calc());
    var result = 0;
    while (stack.Count != 0)
      result += stack.Pop();
    return result;

    int Calc() => op switch
    {
      '*' => val * stack.Pop(),
      '/' => stack.Pop() / val,
      '-' => -val,
      _ => val
    };
  }
}

[TestFixture]
public class StackSolutionTests
{
  [TestCase("3+2*2", 7)]
  [TestCase(" 3/2 ", 1)]
  [TestCase(" 3+5 / 2 ", 5)]
  [TestCase("  1 ", 1)]
  [TestCase("  1 /2/2", 0)]
  public void Test(string s, int expected)
  {
    new StackSolution().Calculate(s).Should().Be(expected);
  }
}
