namespace LeetCode._1326._Minimum_Number_of_Taps_to_Open_to_Water_a_Garden;

[TestFixture]
public class Tests
{
  [TestCase(5, new[] { 3, 4, 1, 1, 0, 0 }, 1)]
  [TestCase(3, new[] { 0, 0, 0, 0 }, -1)]
  public void Test(int n, int[] ranges, int expected)
  {
    new Solution().MinTaps(n, ranges).Should().Be(expected);
  }
}
