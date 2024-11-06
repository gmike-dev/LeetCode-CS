namespace LeetCode._3011._Find_if_Array_Can_Be_Sorted;

public class BubbleSortSolution
{
  public bool CanSortArray(int[] nums)
  {
    var n = nums.Length;
    var nextIteration = true;
    for (var i = 0; i < n && nextIteration; i++)
    {
      nextIteration = false;
      for (var j = 0; j < n - 1; j++)
      {
        if (nums[j] > nums[j + 1])
        {
          if (BitOperations.PopCount((uint)nums[j]) != BitOperations.PopCount((uint)nums[j + 1]))
            return false;
          (nums[j], nums[j + 1]) = (nums[j + 1], nums[j]);
          nextIteration = true;
        }
      }
    }
    return true;
  }
}

[TestFixture]
public class BubbleSortSolutionTests
{
  [TestCase(new[] { 8, 4, 2, 30, 15 }, true)]
  [TestCase(new[] { 1, 2, 3, 4, 5 }, true)]
  [TestCase(new[] { 3, 16, 8, 4, 2 }, false)]
  public void Test(int[] nums, bool expected)
  {
    new BubbleSortSolution().CanSortArray(nums).Should().Be(expected);
  }
}
