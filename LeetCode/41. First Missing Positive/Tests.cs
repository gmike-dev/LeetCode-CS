namespace LeetCode._41._First_Missing_Positive;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 1, 2, 0 }, 3)]
  [TestCase(new[] { 3, 4, -1, 1 }, 2)]
  [TestCase(new[] { 7, 8, 9, 11, 12 }, 1)]
  [TestCase(new[] { 1, 2, (int)1e6 }, 3)]
  [TestCase(new[] { 1 }, 2)]
  public void Test(int[] a, int expected)
  {
    new SolutionUsingMemory().FirstMissingPositive(a).Should().Be(expected);
    new InPlaceSolution().FirstMissingPositive(a).Should().Be(expected);
  }
}
