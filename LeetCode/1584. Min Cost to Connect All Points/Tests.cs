namespace LeetCode._1584._Min_Cost_to_Connect_All_Points;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    var points = new[] { new[] { 0, 0 }, new[] { 2, 2 }, new[] { 3, 10 }, new[] { 5, 2 }, new[] { 7, 0 } };
    new Solution().MinCostConnectPoints(points).Should().Be(20);
    new SolutionUsingKruskalMst().MinCostConnectPoints(points).Should().Be(20);
  }

  [Test]
  public void Test2()
  {
    var points = new[] { new[] { 3, 12 }, new[] { -2, 5 }, new[] { -4, 1 } };
    new Solution().MinCostConnectPoints(points).Should().Be(18);
    new SolutionUsingKruskalMst().MinCostConnectPoints(points).Should().Be(18);
  }
}
