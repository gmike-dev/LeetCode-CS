namespace LeetCode._78._Subsets;

[TestFixture]
public class BitmaskSolutionTests
{
  [Test]
  public void Test1()
  {
    new BitmaskSolution().Subsets(new[] { 1, 2, 3 }).Should().BeEquivalentTo(new[]
    {
      new int[0], new[] { 1 }, new[] { 2 }, new[] { 1, 2 }, new[] { 3 }, new[] { 1, 3 }, new[] { 2, 3 },
      new[] { 1, 2, 3 }
    });
  }
}
