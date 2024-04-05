namespace LeetCode.__Sliding_Window._2962._Count_Subarrays;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 1, 3, 2, 3, 3 }, 2, 6)]
  [TestCase(new[] { 1, 4, 2, 1 }, 3, 0)]
  [TestCase(new[] { 28, 5, 58, 91, 24, 91, 53, 9, 48, 85, 16, 70, 91, 91, 47, 91, 61, 4, 54, 61, 49 }, 1, 187)]
  public void Test(int[] a, int k, long expected)
  {
    new QueueSolution().CountSubarrays(a, k).Should().Be(expected);
    new SlidingWindowSolution().CountSubarrays(a, k).Should().Be(expected);
  }
}
