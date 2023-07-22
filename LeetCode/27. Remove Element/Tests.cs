using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._27._Remove_Element;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    var nums = new[] { 3, 2, 2, 3 };
    var result = new Solution().RemoveElement(nums, 3);
    result.Should().Be(2);
    nums.Should().BeEquivalentTo(new[] { 2, 2, 2, 3 });
  }

  [Test]
  public void Test2()
  {
    var nums = new[] { 0, 1, 2, 2, 3, 0, 4, 2 };
    var result = new Solution().RemoveElement(nums, 2);
    result.Should().Be(5);
    nums.Should().BeEquivalentTo(new[] { 0, 1, 3, 0, 4, 0, 4, 2 });
  }
}