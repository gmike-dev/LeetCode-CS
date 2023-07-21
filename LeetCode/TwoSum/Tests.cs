using NUnit.Framework;

namespace LeetCode.TwoSum;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    var sln = new Solution();
    var result = sln.TwoSum(new[] { -1, 2, 3, 4, 5 }, 5);
    Assert.That(result, Is.EqualTo(new[] { 1, 2 }));
  }
}