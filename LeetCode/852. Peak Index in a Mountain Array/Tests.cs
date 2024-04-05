namespace LeetCode._852._Peak_Index_in_a_Mountain_Array;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 0, 1, 0 }, 1)]
  [TestCase(new[] { 0, 2, 1, 0 }, 1)]
  [TestCase(new[] { 0, 10, 5, 2 }, 1)]
  public void TestLinear(int[] values, int expected)
  {
    new Solution().PeakIndexInMountainArray(values).Should().Be(expected);
  }

  [TestCase(new[] { 0, 1, 0 }, 1)]
  [TestCase(new[] { 0, 2, 1, 0 }, 1)]
  [TestCase(new[] { 0, 10, 5, 2 }, 1)]
  public void TestBinary(int[] values, int expected)
  {
    new Solution().PeakIndexInMountainArray_BinarySearch(values).Should().Be(expected);
  }

  [TestCase(new[] { 0, 1, 0 }, 1)]
  [TestCase(new[] { 0, 2, 1, 0 }, 1)]
  [TestCase(new[] { 0, 10, 5, 2 }, 1)]
  public void TestTernary(int[] values, int expected)
  {
    new Solution().PeakIndexInMountainArray_TernarySearch(values).Should().Be(expected);
  }
}
