namespace LeetCode._26._Remove_Duplicates_from_Sorted_Array;

public class Tests
{
  [Test]
  public void Test1()
  {
    var nums = new[] { 1, 1, 2 };
    var result = new Solution().RemoveDuplicates(nums);
    result.Should().Be(2);
    nums.Should().BeEquivalentTo(new[] { 1, 2, 2 });
  }

  [Test]
  public void Test2()
  {
    var nums = new[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
    var result = new Solution().RemoveDuplicates(nums);
    result.Should().Be(5);
    nums.Should().BeEquivalentTo(new[] { 0, 1, 2, 3, 4, 2, 2, 3, 3, 4 });
  }
}
