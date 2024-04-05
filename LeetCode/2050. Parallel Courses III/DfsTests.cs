namespace LeetCode._2050._Parallel_Courses_III;

[TestFixture]
public class DfsTests
{
  [Test]
  public void Test1()
  {
    new DfsSolution().MinimumTime(3, new[]
    {
      new[] { 1, 3 },
      new[] { 2, 3 }
    }, new[] { 3, 2, 5 }).Should().Be(8);
  }

  [Test]
  public void Test2()
  {
    new DfsSolution().MinimumTime(5, new[]
    {
      new[] { 1, 5 },
      new[] { 2, 5 },
      new[] { 3, 5 },
      new[] { 3, 4 },
      new[] { 4, 5 }
    }, new[] { 1, 2, 3, 4, 5 }).Should().Be(12);
  }

  [Test]
  public void Test3()
  {
    new DfsSolution().MinimumTime(9, new[]
    {
      new[] { 9, 3 }, new[] { 2, 3 }, new[] { 9, 5 }, new[] { 2, 5 }, new[] { 3, 5 }, new[] { 2, 8 }, new[] { 3, 8 },
      new[] { 4, 8 }, new[] { 3, 7 }, new[] { 4, 7 }, new[] { 5, 7 }, new[] { 8, 7 }, new[] { 9, 7 }, new[] { 5, 6 },
      new[] { 3, 1 }, new[] { 4, 1 }, new[] { 5, 1 }, new[] { 6, 1 }, new[] { 7, 1 }, new[] { 8, 1 }
    }, new[] { 7, 5, 8, 2, 4, 7, 5, 5, 8 }).Should().Be(34);
  }
}
