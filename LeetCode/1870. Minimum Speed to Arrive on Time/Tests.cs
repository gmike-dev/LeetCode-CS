namespace LeetCode._1870._Minimum_Speed_to_Arrive_on_Time;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 1, 3, 2 }, 6, 1)]
  [TestCase(new[] { 1, 3, 2 }, 2.7, 3)]
  [TestCase(new[] { 1, 3, 2 }, 1.9, -1)]
  public void Test(int[] dist, double hours, int expected)
  {
    new Solution().MinSpeedOnTime(dist, hours).Should().Be(expected);
  }
}
