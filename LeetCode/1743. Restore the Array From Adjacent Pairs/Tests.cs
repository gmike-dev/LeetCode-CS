using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._1743._Restore_the_Array_From_Adjacent_Pairs;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().RestoreArray(new[]
      {
        new[] { 2, 1 }, new[] { 3, 4 }, new[] { 3, 2 }
      })
      .Should()
      .BeEquivalentTo(new[] { 1, 2, 3, 4 }, o => o.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    new Solution().RestoreArray(new[]
      {
        new[] { 4, -2 }, new[] { 1, 4 }, new[] { -3, 1 }
      })
      .Should()
      .BeEquivalentTo(new[] { -2, 4, 1, -3 }, o => o.WithStrictOrdering());
  }

  [Test]
  public void Test3()
  {
    new Solution().RestoreArray(new[]
      {
        new[] { 100000, -100000 }
      })
      .Should()
      .BeEquivalentTo(new[] { 100000, -100000 }, o => o.WithStrictOrdering());
  }
}