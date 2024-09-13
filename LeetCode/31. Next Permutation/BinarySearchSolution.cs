namespace LeetCode._31._Next_Permutation;

public class BinarySearchSolution
{
  public void NextPermutation(int[] nums)
  {
    var i = nums.Length - 2;
    while (i >= 0 && nums[i] >= nums[i + 1])
      i--;

    if (i >= 0)
    {
      var l = i + 1;
      var r = nums.Length;
      while (l < r)
      {
        var m = l + (r - l) / 2;
        if (nums[m] > nums[i])
          l = m + 1;
        else
          r = m;
      }
      (nums[i], nums[r - 1]) = (nums[r - 1], nums[i]);
    }
    nums.AsSpan(i + 1).Reverse();
  }
}

[TestFixture]
public class BinarySearchSolutionTests
{
  [TestCase(new[] { 1, 2, 3 }, new[] { 1, 3, 2 })]
  [TestCase(new[] { 3, 2, 1 }, new[] { 1, 2, 3 })]
  [TestCase(new[] { 1, 1, 5 }, new[] { 1, 5, 1 })]
  [TestCase(new[] { 1, 3, 2 }, new[] { 2, 1, 3 })]
  [TestCase(new[] { 2, 3, 1 }, new[] { 3, 1, 2 })]
  public void Test(int[] nums, int[] expected)
  {
    new BinarySearchSolution().NextPermutation(nums);
    nums.Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
