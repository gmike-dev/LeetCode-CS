using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._678._Valid_Parenthesis_String;

[TestFixture]
public class Tests
{
  [TestCase("()", true)]
  [TestCase("(*)", true)]
  [TestCase("(*))", true)]
  [TestCase("((*)", true)]
  [TestCase("(((*))", true)]
  [TestCase("*(((*))()", true)]
  [TestCase("*(((*))(", false)]
  [TestCase("*(((*))(*", true)]
  [TestCase("*(((*))*(", false)]
  [TestCase("****", true)]
  [TestCase(")***", false)]
  [TestCase("*", true)]
  [TestCase("(((", false)]
  [TestCase("***(((", false)]
  [TestCase("(**)", true)]
  [TestCase("((((()(()()()*()(((((*)()*(**(())))))(())()())(((())())())))))))(((((())*)))()))(()((*()*(*)))(*)", true)]
  public void Test(string s, bool expected)
  {
    new Solution().CheckValidString(s).Should().Be(expected);
  }
}