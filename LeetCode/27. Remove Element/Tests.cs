using NUnit.Framework;

namespace LeetCode._27._Remove_Element;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    var sln = new Solution();
    var nums = new[] { 3, 2, 2, 3 };
    var result = sln.RemoveElement(nums, 3);
    Assert.AreEqual(2, result);
    CollectionAssert.AreEqual(new[] { 2, 2, 2, 3 }, nums);
  }

  [Test]
  public void Test2()
  {
    var sln = new Solution();
    var nums = new[] { 0, 1, 2, 2, 3, 0, 4, 2 };
    var result = sln.RemoveElement(nums, 2);
    Assert.AreEqual(5, result);
    CollectionAssert.AreEqual(new[] { 0, 1, 3, 0, 4, 0, 4, 2 }, nums);
  }
}