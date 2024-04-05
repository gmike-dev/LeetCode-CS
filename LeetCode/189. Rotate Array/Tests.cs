namespace LeetCode._189._Rotate_Array;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7 }, 3, new[] { 5, 6, 7, 1, 2, 3, 4 })]
  [TestCase(new[] { -1, -100, 3, 99 }, 2, new[] { 3, 99, -1, -100 })]
  public void Test(int[] nums, int k, int[] expected)
  {
    new Solution().Rotate(nums, k);
    nums.Should().BeEquivalentTo(expected);
  }

  [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7 }, 3, new[] { 5, 6, 7, 1, 2, 3, 4 })]
  [TestCase(new[] { -1, -100, 3, 99 }, 2, new[] { 3, 99, -1, -100 })]
  public void TempArrayTest(int[] nums, int k, int[] expected)
  {
    new Solution().Rotate_UseTempArray(nums, k);
    nums.Should().BeEquivalentTo(expected);
  }
}
