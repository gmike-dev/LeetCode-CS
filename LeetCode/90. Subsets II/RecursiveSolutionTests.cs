namespace LeetCode._90._Subsets_II;

[TestFixture]
public class RecursiveSolutionTests
{
  [Test]
  public void Test1()
  {
    new RecursiveSolution().SubsetsWithDup(new[] { 1, 2, 2 })
      .Should()
      .BeEquivalentTo(new[]
      {
        new int[0], new[] { 1 }, new[] { 1, 2 }, new[] { 1, 2, 2 },
        new[] { 2 }, new[] { 2, 2 }
      });
  }

  [Test]
  public void Test2()
  {
    new RecursiveSolution().SubsetsWithDup(new[] { -1, 1, 1 })
      .Should()
      .BeEquivalentTo(new[]
      {
        new int[0], new[] { -1 }, new[] { -1, 1 }, new[] { -1, 1, 1 },
        new[] { 1 }, new[] { 1, 1 }
      });
  }

  [Test]
  public void Test3()
  {
    new RecursiveSolution().SubsetsWithDup(new[] { -1, 0, 0 })
      .Should()
      .BeEquivalentTo(new[]
      {
        new int[0], new[] { -1 }, new[] { -1, 0 }, new[] { -1, 0, 0 },
        new[] { 0 }, new[] { 0, 0 }
      });
  }

  [Test]
  public void Test4()
  {
    new RecursiveSolution().SubsetsWithDup(new[] { -1, 0, 1 })
      .Should()
      .BeEquivalentTo(new[]
      {
        new int[0], new[] { -1 }, new[] { -1, 0 }, new[] { -1, 0, 1 },
        new[] { 0 }, new[] { 0, 1 }, new[] { 1 }, new[] { -1, 1 }
      });
  }

  [Test]
  public void Test16()
  {
    new RecursiveSolution().SubsetsWithDup(new[] { 1, 9, 8, 3, -1, 0 })
      .Should()
      .BeEquivalentTo(new[]
      {
        new int[0], new[] { -1 }, new[] { -1, 0 }, new[] { -1, 0, 1 }, new[] { -1, 0, 1, 3 }, new[] { -1, 0, 1, 3, 8 },
        new[] { -1, 0, 1, 3, 8, 9 }, new[] { -1, 0, 1, 3, 9 }, new[] { -1, 0, 1, 8 }, new[] { -1, 0, 1, 8, 9 },
        new[] { -1, 0, 1, 9 }, new[] { -1, 0, 3 }, new[] { -1, 0, 3, 8 }, new[] { -1, 0, 3, 8, 9 },
        new[] { -1, 0, 3, 9 }, new[] { -1, 0, 8 }, new[] { -1, 0, 8, 9 }, new[] { -1, 0, 9 }, new[] { -1, 1 },
        new[] { -1, 1, 3 }, new[] { -1, 1, 3, 8 }, new[] { -1, 1, 3, 8, 9 }, new[] { -1, 1, 3, 9 }, new[] { -1, 1, 8 },
        new[] { -1, 1, 8, 9 }, new[] { -1, 1, 9 }, new[] { -1, 3 }, new[] { -1, 3, 8 }, new[] { -1, 3, 8, 9 },
        new[] { -1, 3, 9 }, new[] { -1, 8 }, new[] { -1, 8, 9 }, new[] { -1, 9 }, new[] { 0 }, new[] { 0, 1 },
        new[] { 0, 1, 3 }, new[] { 0, 1, 3, 8 }, new[] { 0, 1, 3, 8, 9 }, new[] { 0, 1, 3, 9 }, new[] { 0, 1, 8 },
        new[] { 0, 1, 8, 9 }, new[] { 0, 1, 9 }, new[] { 0, 3 }, new[] { 0, 3, 8 }, new[] { 0, 3, 8, 9 },
        new[] { 0, 3, 9 }, new[] { 0, 8 }, new[] { 0, 8, 9 }, new[] { 0, 9 }, new[] { 1 }, new[] { 1, 3 },
        new[] { 1, 3, 8 }, new[] { 1, 3, 8, 9 }, new[] { 1, 3, 9 }, new[] { 1, 8 }, new[] { 1, 8, 9 }, new[] { 1, 9 },
        new[] { 3 }, new[] { 3, 8 }, new[] { 3, 8, 9 }, new[] { 3, 9 }, new[] { 8 }, new[] { 8, 9 }, new[] { 9 }
      });
  }
}
