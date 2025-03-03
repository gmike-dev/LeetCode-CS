namespace LeetCode._2161._Partition_Array_According_to_Given_Pivot;

public class Solution
{
  public int[] PivotArray(int[] nums, int pivot)
  {
    var lessThanPivot = new List<int>();
    var greaterThanPivot = new List<int>();
    foreach (var num in nums)
    {
      if (num < pivot)
        lessThanPivot.Add(num);
      else if (num > pivot)
        greaterThanPivot.Add(num);
    }
    var index = 0;
    foreach (var num in lessThanPivot)
      nums[index++] = num;
    for (var i = 0; i < nums.Length - lessThanPivot.Count - greaterThanPivot.Count; i++)
      nums[index++] = pivot;
    foreach (var num in greaterThanPivot)
      nums[index++] = num;
    return nums;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { 9, 12, 5, 10, 14, 3, 10 }, 10, new[] { 9, 5, 3, 10, 10, 12, 14 })]
  [TestCase(new[] { -3, 4, 3, 2 }, 2, new[] { -3, 2, 4, 3 })]
  public void Test(int[] nums, int pivot, int[] expected)
  {
    new Solution().PivotArray(nums, pivot).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
