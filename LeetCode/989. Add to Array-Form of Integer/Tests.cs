using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._989._Add_to_Array_Form_of_Integer;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 1, 2, 0, 0 }, 34, new[] { 1, 2, 3, 4 })]
  [TestCase(new[] { 2, 7, 4 }, 181, new[] { 4, 5, 5 })]
  [TestCase(new[] { 2, 1, 5 }, 806, new[] { 1, 0, 2, 1 })]
  public void Test(int[] num, int k, int[] expected)
  {
    new Solution().AddToArrayForm(num, k).Should().BeEquivalentTo(expected);
  }
}