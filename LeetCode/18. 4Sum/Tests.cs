namespace LeetCode._18._4Sum;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().FourSum(new[] { 1, 0, -1, 0, -2, 2 }, 0).Should().BeEquivalentTo(
      new[] { new[] { -2, -1, 1, 2 }, new[] { -2, 0, 0, 2 }, new[] { -1, 0, 0, 1 } });
  }

  [Test]
  public void Test2()
  {
    new Solution().FourSum(new[] { 2, 2, 2, 2, 2 }, 8).Should().BeEquivalentTo(
      new[] { new[] { 2, 2, 2, 2 } });
  }

  [Test]
  public void Test3()
  {
    new Solution().FourSum(new[] { 1, -2, -5, -4, -3, 3, 3, 5 }, -11).Should().BeEquivalentTo(
      new[] { new[] { -5, -4, -3, 1 } });
  }

  [Test]
  public void Test4()
  {
    new Solution().FourSum(new[] { 1000000000, 1000000000, 1000000000, 1000000000 }, -294967296).Should()
      .BeEmpty();
  }
}
