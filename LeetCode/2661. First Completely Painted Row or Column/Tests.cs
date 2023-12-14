using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._2661._First_Completely_Painted_Row_or_Column;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().FirstCompleteIndex(new[] { 1, 3, 4, 2 },
      new[]
      {
        new[] { 1, 4 },
        new[] { 2, 3 }
      }).Should().Be(2);
  }

  [Test]
  public void Test2()
  {
    new Solution().FirstCompleteIndex(new[] { 2, 8, 7, 4, 1, 3, 5, 6, 9 },
      new[]
      {
        new[] { 3, 2, 5 },
        new[] { 1, 4, 6 },
        new[] { 8, 7, 9 }
      }).Should().Be(3);
  }
}