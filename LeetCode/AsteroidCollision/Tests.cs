using System;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.AsteroidCollision;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    var sln = new Solution();
    var result = sln.AsteroidCollision(new[] { 5, 10, -5 });
    result.Should().BeEquivalentTo(new[] { 5, 10 });
  }

  [Test]
  public void Test2()
  {
    var sln = new Solution();
    var result = sln.AsteroidCollision(new[] { 8, -8 });
    result.Should().BeEmpty();
  }

  [Test]
  public void Test3()
  {
    var sln = new Solution();
    var result = sln.AsteroidCollision(new[] { 10, 2, -5 });
    result.Should().BeEquivalentTo(new[] { 10 });
  }
}