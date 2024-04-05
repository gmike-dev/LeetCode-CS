namespace LeetCode._2147._Number_of_Ways_to_Divide_a_Long_Corridor;

[TestFixture]
public class Tests
{
  [TestCase("SSPPSPS", 3)]
  [TestCase("PPSPSP", 1)]
  [TestCase("S", 0)]
  public void Test(string corridor, int expected)
  {
    new Solution().NumberOfWays(corridor).Should().Be(expected);
    new OnePassSolution().NumberOfWays(corridor).Should().Be(expected);
  }
}
