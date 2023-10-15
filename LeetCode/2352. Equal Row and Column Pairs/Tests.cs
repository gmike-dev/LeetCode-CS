using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._2352._Equal_Row_and_Column_Pairs;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().EqualPairs(new[]
    {
      new[] { 3, 2, 1 },
      new[] { 1, 7, 6 },
      new[] { 2, 7, 7 }
    }).Should().Be(1);
  }

  [Test]
  public void Test2()
  {
    new Solution().EqualPairs(new[]
    {
      new[] { 3, 1, 2, 2 }, 
      new[] { 1, 4, 4, 5 }, 
      new[] { 2, 4, 2, 2 }, 
      new[] { 2, 4, 2, 2 }
    }).Should().Be(3);
  }
}