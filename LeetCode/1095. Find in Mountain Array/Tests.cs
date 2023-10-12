using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._1095._Find_in_Mountain_Array;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().FindInMountainArray(3, new MountainArray(new[] { 1, 2, 3, 4, 5, 3, 1 })).Should().Be(2);
  }

  [Test]
  public void Test2()
  {
    new Solution().FindInMountainArray(3, new MountainArray(new[] { 0, 1, 2, 4, 2, 1 })).Should().Be(-1);
  }

  [Test]
  public void Test3()
  {
    new Solution().FindInMountainArray(3, new MountainArray(new[] { 0, 1, 2 })).Should().Be(-1);
  }

  [Test]
  public void Test75()
  {
    new Solution().FindInMountainArray(3, new MountainArray(new[] { 0, 5, 3, 1 })).Should().Be(2);
  }

  [Test]
  public void Test77()
  {
    new Solution().FindInMountainArray(1, new MountainArray(new[] { 0, 5, 3, 1 })).Should().Be(3);
  }
}