namespace LeetCode.__Graphs._207._Course_Schedule;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().CanFinish(2, new[] { new[] { 1, 0 } }).Should().BeTrue();
  }

  [Test]
  public void Test2()
  {
    new Solution().CanFinish(2, new[] { new[] { 1, 0 }, new[] { 0, 1 } }).Should().BeFalse();
  }

  [Test]
  public void Test3()
  {
    new Solution().CanFinish(4, new[]
    {
      new[] { 2, 0 },
      new[] { 2, 1 },
      new[] { 3, 2 },
      new[] { 2, 3 }
    }).Should().BeFalse();
  }

  [Test]
  public void Test4()
  {
    new Solution().CanFinish(4, new[]
    {
      new[] { 2, 0 },
      new[] { 2, 1 },
      new[] { 3, 2 }
    }).Should().BeTrue();
  }

  [Test]
  public void Test5()
  {
    new Solution().CanFinish(8, new[]
    {
      new[] { 1, 0 }, new[] { 0, 5 },
      new[] { 1, 7 }, new[] { 7, 0 },
      new[] { 4, 6 }, new[] { 6, 2 },
    }).Should().BeTrue();
  }

  [Test]
  public void Test6()
  {
    new Solution().CanFinish(6, new[]
    {
      new[] { 1, 0 }, new[] { 2, 0 },
      new[] { 3, 5 }, new[] { 3, 2 },
      new[] { 4, 3 }, new[] { 5, 1 }
    }).Should().BeTrue();
  }

  [Test]
  public void Test7()
  {
    new Solution().CanFinish(5, new[]
    {
      new[] { 1, 0 }, new[] { 2, 0 },
      new[] { 3, 4 }, new[] { 3, 2 },
      new[] { 4, 1 }
    }).Should().BeTrue();
  }

  [Test]
  public void Test41()
  {
    new Solution().CanFinish(20, new[]
    {
      new[] { 0, 10 }, new[] { 3, 18 },
      new[] { 5, 5 }, new[] { 6, 11 },
      new[] { 11, 14 }, new[] { 13, 1 },
      new[] { 15, 1 }, new[] { 17, 4 }
    }).Should().BeFalse();
  }
}
