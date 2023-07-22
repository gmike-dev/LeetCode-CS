using NUnit.Framework;

namespace LeetCode._66._Plus_One;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    var sln = new Solution();
    CollectionAssert.AreEqual(new[] { 1, 2, 4 }, sln.PlusOne(new[] { 1, 2, 3 }));
    CollectionAssert.AreEqual(new[] { 1, 0, 0, 0 }, sln.PlusOne(new[] { 9, 9, 9 }));
    CollectionAssert.AreEqual(new[] { 1, 0 }, sln.PlusOne(new[] { 9 }));
  }
}