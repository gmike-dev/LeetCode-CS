namespace LeetCode._1851._Minimum_Interval_to_Include_Each_Query;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().MinInterval(
        new[]
        {
          new[] { 1, 4 },
          new[] { 2, 4 },
          new[] { 3, 6 },
          new[] { 4, 4 }
        },
        new[] { 2, 3, 4, 5 })
      .Should().BeEquivalentTo(new[] { 3, 3, 1, 4 }, o => o.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    new Solution().MinInterval(
        new[]
        {
          new[] { 2, 3 }, new[] { 2, 5 }, new[] { 1, 8 }, new[] { 20, 25 }
        },
        new[] { 2, 19, 5, 22 })
      .Should().BeEquivalentTo(new[] { 2, -1, 4, 6 }, o => o.WithStrictOrdering());
  }

  [Test]
  public void Test5()
  {
    new Solution().MinInterval(
        new[]
        {
          new[] { 4, 5 }, new[] { 5, 8 }, new[] { 1, 9 }, new[] { 8, 10 }, new[] { 1, 6 }
        },
        new[] { 7, 9, 3, 9, 3 })
      .Should().BeEquivalentTo(new[] { 4, 3, 6, 3, 6 }, o => o.WithStrictOrdering());
  }
}
