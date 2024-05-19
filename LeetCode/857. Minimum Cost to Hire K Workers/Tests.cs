namespace LeetCode._857._Minimum_Cost_to_Hire_K_Workers;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 10, 20, 5 }, new[] { 70, 50, 30 }, 2, 105.0)]
  [TestCase(new[] { 3, 1, 10, 10, 1 }, new[] { 4, 8, 2, 2, 7 }, 3, 30.66667)]
  public void Test(int[] quality, int[] wage, int k, double expected)
  {
    new Solution().MincostToHireWorkers(quality, wage, k).Should().BeApproximately(expected, 1e-5);
  }
}
