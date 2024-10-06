namespace LeetCode.__Numbers._3309._Maximum_Possible_Number_by_Binary_Concatenation;

public class Solution
{
  public int MaxGoodNumber(int[] nums)
  {
    return new[]
    {
      Concat(nums[0], nums[1], nums[2]),
      Concat(nums[0], nums[2], nums[1]),
      Concat(nums[1], nums[0], nums[2]),
      Concat(nums[1], nums[2], nums[0]),
      Concat(nums[2], nums[0], nums[1]),
      Concat(nums[2], nums[1], nums[0])
    }.Max();
  }

  private static int Concat(int a, int b, int c)
  {
    var shiftA = BitOperations.Log2((uint)b) + 1;
    var shiftB = BitOperations.Log2((uint)c) + 1;
    return (((a << shiftA) + b) << shiftB) + c;
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    new Solution().MaxGoodNumber([1, 2, 3]).Should().Be(30);
  }

  [Test]
  public void Test2()
  {
    new Solution().MaxGoodNumber([2, 8, 16]).Should().Be(1296);
  }
}
