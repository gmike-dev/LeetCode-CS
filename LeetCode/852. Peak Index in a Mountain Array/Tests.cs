using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._852._Peak_Index_in_a_Mountain_Array;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().PeakIndexInMountainArray(new[] { 0, 1, 0 }).Should().Be(1);
    new Solution().PeakIndexInMountainArray(new[] { 0, 2, 1, 0 }).Should().Be(1);
    new Solution().PeakIndexInMountainArray(new[] { 0, 10, 5, 2 }).Should().Be(1);
  }
}