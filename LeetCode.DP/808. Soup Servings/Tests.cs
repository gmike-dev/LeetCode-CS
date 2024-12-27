namespace LeetCode._808._Soup_Servings;

[TestFixture]
public class Tests
{
  [TestCase(50, 0.625)]
  [TestCase(100, 0.71875)]
  public void Test1(int n, double expected)
  {
    new Solution().SoupServings(n).Should().Be(expected);
  }
}
