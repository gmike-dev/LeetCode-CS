using System;
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
    Assert.That(result, Is.EquivalentTo(new[] { 5, 10 }));
  }

  [Test]
  public void Test2()
  {
    var sln = new Solution();
    var result = sln.AsteroidCollision(new[] { 8, -8 });
    Assert.That(result, Is.EquivalentTo(Array.Empty<int>()));
  }

  [Test]
  public void Test3()
  {
    var sln = new Solution();
    var result = sln.AsteroidCollision(new[] { 10, 2, -5 });
    Assert.That(result, Is.EquivalentTo(new[] { 10 }));
  }
}