namespace LeetCode._47._Permutations_II;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().PermuteUnique(new[] { 1, 1, 2 }).Should().BeEquivalentTo(
      new[]
      {
        new[] { 1, 1, 2 },
        new[] { 1, 2, 1 },
        new[] { 2, 1, 1 }
      });
  }

  [Test]
  public void Test2()
  {
    new Solution().PermuteUnique(new[] { 1, 2, 3 }).Should().BeEquivalentTo(
      new[]
      {
        new[] { 1, 2, 3 },
        new[] { 1, 3, 2 },
        new[] { 2, 1, 3 },
        new[] { 2, 3, 1 },
        new[] { 3, 1, 2 },
        new[] { 3, 2, 1 }
      });
  }
}
