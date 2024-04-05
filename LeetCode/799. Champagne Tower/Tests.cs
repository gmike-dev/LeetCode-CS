namespace LeetCode._799._Champagne_Tower;

[TestFixture]
public class Tests
{
  [TestCase(1, 1, 1, 0.0)]
  [TestCase(2, 1, 1, 0.5)]
  [TestCase(100000009, 33, 17, 1.0)]
  [TestCase(9, 3, 0, 0.25)]
  [TestCase(9, 3, 1, 1.0)]
  [TestCase(9, 4, 1, 0.125)]
  public void Test(int poured, int queryRow, int queryGlass, double expected)
  {
    new Solution().ChampagneTower(poured, queryRow, queryGlass).Should().Be(expected);
  }
}
