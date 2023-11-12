using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._815._Bus_Routes;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().NumBusesToDestination(new[]
    {
      new[] { 1, 2, 7 },
      new[] { 3, 6, 7 }
    }, 1, 6).Should().Be(2);
  }

  [Test]
  public void Test2()
  {
    new Solution().NumBusesToDestination(new[]
    {
      new[] { 7, 12 }, new[] { 4, 5, 15 }, new[] { 6 }, new[] { 15, 19 }, new[] { 9, 12, 13 }
    }, 15, 12).Should().Be(-1);
  }

  [Test]
  public void Test3()
  {
    new Solution().NumBusesToDestination(new[]
    {
      new[] { 1, 2, 3, 4, 5 },
      new[] { 1, 6, 7 },
      new[] { 7, 5, 8 }
    }, 1, 5).Should().Be(1);
  }

  [Test]
  public void Test4()
  {
    new Solution().NumBusesToDestination(new[]
    {
      new[] { 1, 5, 4 },
      new[] { 5, 3, 4 },
      new[] { 3, 5, 1, 2 }
    }, 1, 3).Should().Be(1);
  }

  [Test]
  public void Test5()
  {
    new Solution().NumBusesToDestination(new[]
    {
      new[] { 1, 2, 3 },
      new[] { 2, 4, 3 },
      new[] { 1, 2, 5, 4 }
    }, 1, 4).Should().Be(1);
  }

  [Test]
  public void Test6()
  {
    new Solution().NumBusesToDestination(new[]
    {
      new[] { 1, 2, 3 }
    }, 1, 3).Should().Be(1);
  }

  [Test]
  public void Test7()
  {
    new Solution().NumBusesToDestination(new[]
    {
      new[] { 1, 2, 3 }
    }, 3, 3).Should().Be(0);
  }
  
  
  [Test]
  public void Test8()
  {
    new Solution().NumBusesToDestination(new[]
    {
      new[] { 1, 2, 3 }
    }, 4, 4).Should().Be(-1);
  }
}