namespace LeetCode._2391._Minimum_Amount_of_Time_to_Collect_Garbage;

[TestFixture]
public class Tests
{
  [TestCase(new[] { "G", "P", "GP", "GG" }, new[] { 2, 4, 3 }, 21)]
  [TestCase(new[] { "MMM", "PGM", "GP" }, new[] { 3, 10 }, 37)]
  [TestCase(new[] { "MMM", "PPP" }, new[] { 3 }, 9)]
  public void Test(string[] garbage, int[] travel, int expected)
  {
    new Solution().GarbageCollection(garbage, travel).Should().Be(expected);
  }
}
