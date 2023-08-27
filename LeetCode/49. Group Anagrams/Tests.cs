using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._49._Group_Anagrams;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().GroupAnagrams(new[] { "eat", "tea", "tan", "ate", "nat", "bat" }).Should().BeEquivalentTo(new[]
    {
      new[] { "bat" }, new[] { "nat", "tan" }, new[] { "ate", "eat", "tea" }
    });
  }

  [Test]
  public void Test2()
  {
    new Solution().GroupAnagrams(new[] { "" }).Should().BeEquivalentTo(new[]
    {
      new[] { "" }
    });
  }

  [Test]
  public void Test3()
  {
    new Solution().GroupAnagrams(new[] { "a" }).Should().BeEquivalentTo(new[]
    {
      new[] { "a" }
    });
  }
}