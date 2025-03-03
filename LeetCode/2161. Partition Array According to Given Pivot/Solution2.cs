namespace LeetCode._2161._Partition_Array_According_to_Given_Pivot;

public class Solution2
{
  public int[] PivotArray(int[] nums, int pivot)
  {
    var n = nums.Length;
    Span<int> less = stackalloc int[n];
    Span<int> greater = stackalloc int[n];
    var lessCount = 0;
    var greaterCount = 0;
    foreach (var num in nums)
    {
      if (num < pivot)
        less[lessCount++] = num;
      else if (num > pivot)
        greater[greaterCount++] = num;
    }
    less[..lessCount].CopyTo(nums.AsSpan(0, lessCount));
    var pivotCount = nums.Length - lessCount - greaterCount;
    nums.AsSpan(lessCount, pivotCount).Fill(pivot);
    greater[..greaterCount].CopyTo(nums.AsSpan()[(lessCount + pivotCount)..]);
    return nums;
  }
}

[TestFixture]
public class Solution2Tests
{
  [TestCase(new[] { 9, 12, 5, 10, 14, 3, 10 }, 10, new[] { 9, 5, 3, 10, 10, 12, 14 })]
  [TestCase(new[] { -3, 4, 3, 2 }, 2, new[] { -3, 2, 4, 3 })]
  public void Test(int[] nums, int pivot, int[] expected)
  {
    new Solution2().PivotArray(nums, pivot).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
