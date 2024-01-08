using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._120._Triangle;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().MinimumTotal(new IList<int>[]
    {
      new[] { 2 },
      new[] { 3, 4 },
      new[] { 6, 5, 7 },
      new[] { 4, 1, 8, 3 }
    }).Should().Be(11);
  }

  [Test]
  public void Test2()
  {
    new Solution().MinimumTotal(new IList<int>[]
    {
      new[] { -10 }
    }).Should().Be(-10);
  }
}