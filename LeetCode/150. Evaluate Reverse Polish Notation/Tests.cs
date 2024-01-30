using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._150._Evaluate_Reverse_Polish_Notation;

[TestFixture]
public class Tests
{
  [TestCase(new[] { "2", "1", "+", "3", "*" }, 9)]
  [TestCase(new[] { "4", "13", "5", "/", "+" }, 6)]
  [TestCase(new[] { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" }, 22)]
  public void Test(string[] tokens, int expected)
  {
    new RecursiveSolution().EvalRPN(tokens).Should().Be(expected);
    new StackSolution().EvalRPN(tokens).Should().Be(expected);
  }
}