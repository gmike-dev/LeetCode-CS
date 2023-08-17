using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._542._01_Matrix;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().UpdateMatrix(new[]
    {
      new[] { 0, 0, 0 },
      new[] { 0, 1, 0 },
      new[] { 0, 0, 0 }
    }).Should().BeEquivalentTo(new[]
    {
      new[] { 0, 0, 0 },
      new[] { 0, 1, 0 },
      new[] { 0, 0, 0 }
    });
  }

  [Test]
  public void Test2()
  {
    new Solution().UpdateMatrix(new[]
    {
      new[] { 0, 0, 0 },
      new[] { 0, 1, 0 },
      new[] { 1, 1, 1 }
    }).Should().BeEquivalentTo(new[]
    {
      new[] { 0, 0, 0 },
      new[] { 0, 1, 0 },
      new[] { 1, 2, 1 }
    });
  }

  [Test]
  public void Test3()
  {
    new Solution().UpdateMatrix(new[]
    {
      new[] { 0 },
      new[] { 0 },
      new[] { 0 },
      new[] { 0 },
      new[] { 0 }
    }).Should().BeEquivalentTo(new[]
    {
      new[] { 0 },
      new[] { 0 },
      new[] { 0 },
      new[] { 0 },
      new[] { 0 }
    });
  }
}