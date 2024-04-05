namespace LeetCode._526._Beautiful_Arrangement;

[TestFixture]
public class Tests
{
  [TestCase(2, 2)]
  [TestCase(1, 1)]
  public void Test(int n, int expected)
  {
    new Solution().CountArrangement(n).Should().Be(expected);

    var sln = new Solution();
    for (var i = 1; i <= 15; i++)
    {
      TestContext.Write(sln.CountArrangement(i) + ", ");
    }
  }
}
