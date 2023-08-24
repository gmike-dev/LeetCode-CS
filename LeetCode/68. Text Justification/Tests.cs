using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._68._Text_Justification;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().FullJustify(new[]
      {
        "This", "is", "an", "example", "of", "text", "justification."
      }, 16)
      .Should().BeEquivalentTo(new[]
      {
        "This    is    an",
        "example  of text",
        "justification.  "
      });
  }

  [Test]
  public void Test2()
  {
    new Solution().FullJustify(new[]
      {
        "What", "must", "be", "acknowledgment", "shall", "be"
      }, 16)
      .Should().BeEquivalentTo(new[]
      {
        "What   must   be",
        "acknowledgment  ",
        "shall be        "
      });
  }

  [Test]
  public void Test3()
  {
    new Solution().FullJustify(new[]
      {
        "Science", "is", "what", "we", "understand", "well", "enough", 
        "to", "explain", "to", "a", "computer.", "Art",
        "is", "everything", "else", "we", "do"
      }, 20)
      .Should().BeEquivalentTo(new[]
      {
        "Science  is  what we",
        "understand      well",
        "enough to explain to",
        "a  computer.  Art is",
        "everything  else  we",
        "do                  "
      });
  }
}