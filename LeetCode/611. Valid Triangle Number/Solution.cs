namespace LeetCode._611._Valid_Triangle_Number;

public class Solution
{
  public int TriangleNumber(int[] nums)
  {
    Array.Sort(nums);
    var n = nums.Length;
    var count = 0;
    for (var i = 0; i < n - 2; i++)
    {
      for (int j = i + 1, k = i + 1; j < n - 1; j++)
      {
        while (k < n && nums[i] + nums[j] > nums[k])
          k++;
        if (j < k)
          count += k - j - 1;
      }
    }
    return count;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { 2, 2, 3, 4 }, 3)]
  [TestCase(new[] { 4, 2, 3, 4 }, 4)]
  [TestCase(new[] { 0, 0, 0 }, 0)]
  public void Test(int[] nums, int expected)
  {
    new Solution().TriangleNumber(nums).Should().Be(expected);
  }
}
