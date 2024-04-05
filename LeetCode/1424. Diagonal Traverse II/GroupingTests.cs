namespace LeetCode._1424._Diagonal_Traverse_II;

[TestFixture]
public class GroupingTests
{
  [Test]
  public void Test1()
  {
    new GroupingSolution().FindDiagonalOrder(new[]
      {
        new[] { 1, 2, 3 },
        new[] { 4, 5, 6 },
        new[] { 7, 8, 9 }
      })
      .Should()
      .BeEquivalentTo(new[] { 1, 4, 2, 7, 5, 3, 8, 6, 9 },
        o => o.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    new GroupingSolution().FindDiagonalOrder(new[]
      {
        new[] { 1, 2, 3, 4, 5 },
        new[] { 6, 7 },
        new[] { 8 },
        new[] { 9, 10, 11 },
        new[] { 12, 13, 14, 15, 16 }
      })
      .Should()
      .BeEquivalentTo(new[] { 1, 6, 2, 8, 7, 3, 9, 4, 12, 10, 5, 13, 11, 14, 15, 16 },
        o => o.WithStrictOrdering());
  }
}
