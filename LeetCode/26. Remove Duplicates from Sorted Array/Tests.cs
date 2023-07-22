using NUnit.Framework;

namespace LeetCode._26._Remove_Duplicates_from_Sorted_Array;

public class Tests
{
  [Test]
  public void Test1()
  {
    var sln = new Solution();
    var nums = new[] { 1, 1, 2 };
    var result = sln.RemoveDuplicates(nums);
    Assert.That(result, Is.EqualTo(2));
    Assert.That(nums, Is.EquivalentTo(new[] { 1, 2, 2 }));
  }

  [Test]
  public void Test2()
  {
    var sln = new Solution();
    var nums = new[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
    var result = sln.RemoveDuplicates(nums);
    Assert.That(result, Is.EqualTo(5));
    Assert.That(nums, Is.EquivalentTo(new[] { 0, 1, 2, 3, 4, 2, 2, 3, 3, 4 }));
  }
}