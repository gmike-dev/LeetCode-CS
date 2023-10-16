using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._119._Pascal_s_Triangle_II;

[TestFixture]
public class Tests
{
  [TestCase(0, new[] { 1 })]
  [TestCase(1, new[] { 1, 1 })]
  [TestCase(2, new[] { 1, 2, 1 })]
  [TestCase(3, new[] { 1, 3, 3, 1 })]
  [TestCase(4, new[] { 1, 4, 6, 4, 1 })]
  [TestCase(5, new[] { 1, 5, 10, 10, 5, 1 })]
  public void Test(int rowIndex, int[] expected)
  {
    new Solution().GetRow(rowIndex).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}