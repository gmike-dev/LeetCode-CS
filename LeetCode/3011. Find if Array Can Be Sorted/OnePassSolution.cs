namespace LeetCode._3011._Find_if_Array_Can_Be_Sorted;

public class OnePassSolution
{
  public bool CanSortArray(int[] nums)
  {
    var n = nums.Length;
    var segMin = nums[0];
    var segMax = nums[0];
    var prevSegMax = 0;
    var segPopCount = BitOperations.PopCount((uint)nums[0]);
    for (var i = 1; i < n; i++)
    {
      var popCount = BitOperations.PopCount((uint)nums[i]);
      if (popCount == segPopCount)
      {
        segMin = Math.Min(segMin, nums[i]);
        segMax = Math.Max(segMax, nums[i]);
      }
      else
      {
        prevSegMax = segMax;
        segMin = nums[i];
        segMax = nums[i];
        segPopCount = popCount;
      }
      if (segMin < prevSegMax)
        return false;
    }
    return true;
  }
}

[TestFixture]
public class OnePassSolutionTests
{
  [TestCase(new[] { 8, 4, 2, 30, 15 }, true)]
  [TestCase(new[] { 1, 2, 3, 4, 5 }, true)]
  [TestCase(new[] { 3, 16, 8, 4, 2 }, false)]
  public void Test(int[] nums, bool expected)
  {
    new OnePassSolution().CanSortArray(nums).Should().Be(expected);
  }
}
