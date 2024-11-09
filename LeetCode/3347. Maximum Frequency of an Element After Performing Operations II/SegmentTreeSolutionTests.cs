namespace LeetCode._3347._Maximum_Frequency_of_an_Element_After_Performing_Operations_II;

public class SegmentTreeSolutionTests
{
  [TestCase(new[] { 1, 4, 5 }, 1, 2, 2)]
  [TestCase(new[] { 1, 4, 5 }, 0, 2, 1)]
  [TestCase(new[] { 1, 4, 5, 5 }, 0, 2, 2)]
  [TestCase(new[] { 1, 4, 5, 5 }, 1000, 0, 2)]
  [TestCase(new[] { 1, 4, 5, 6 }, 1000, 0, 1)]
  [TestCase(new[] { 5, 11, 20, 20 }, 5, 1, 2)]
  [TestCase(new[] { 5, 64 }, 42, 2, 2)]
  [TestCase(new[] { 25, 59 }, 39, 2, 2)]
  [TestCase(new[] { 1, 78, 70 }, 39, 3, 3)]
  [TestCase(new[] { 94, 10 }, 51, 1, 1)]
  [TestCase(new[] { 1, 2, 4, 5 }, 2, 4, 4)]
  [TestCase(new[] { 15, 113, 122, 102 }, 90, 3, 4)]
  public void Test1(int[] nums, int k, int numOperations, int expected)
  {
    new SegmentTreeSolution().MaxFrequency(nums, k, numOperations).Should().Be(expected);
  }
}
