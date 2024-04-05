namespace LeetCode._2258._Escape_the_Spreading_Fire;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    var grid = new[]
    {
      new[] { 0, 2, 0, 0, 0, 0, 0 },
      new[] { 0, 0, 0, 2, 2, 1, 0 },
      new[] { 0, 2, 0, 0, 1, 2, 0 },
      new[] { 0, 0, 2, 2, 2, 0, 2 },
      new[] { 0, 0, 0, 0, 0, 0, 0 }
    };
    new Solution().MaximumMinutes(grid).Should().Be(3);
  }

  [Test]
  public void Test2()
  {
    var grid = new[]
    {
      new[] { 0, 0, 0, 0 },
      new[] { 0, 1, 2, 0 },
      new[] { 0, 2, 0, 0 },
    };
    new Solution().MaximumMinutes(grid).Should().Be(-1);
  }

  [Test]
  public void Test3()
  {
    var grid = new[]
    {
      new[] { 0, 0, 0 },
      new[] { 2, 2, 0 },
      new[] { 1, 2, 0 },
    };
    new Solution().MaximumMinutes(grid).Should().Be(1000000000);
  }

  [Test]
  public void Test4()
  {
    var grid = new[]
    {
      new[] { 0, 2, 0, 0, 0, 0, 0 },
      new[] { 0, 0, 1, 2, 2, 1, 0 },
      new[] { 0, 2, 0, 0, 1, 2, 0 },
      new[] { 0, 0, 2, 2, 2, 0, 2 },
      new[] { 0, 0, 0, 0, 0, 0, 0 }
    };
    new Solution().MaximumMinutes(grid).Should().Be(0);
  }

  [Test]
  public void Test5()
  {
    var grid = new[]
    {
      new[] { 0, 2, 0, 0, 0, 0, 0 },
      new[] { 0, 0, 0, 2, 2, 1, 0 },
      new[] { 0, 2, 0, 0, 1, 2, 0 },
      new[] { 0, 0, 2, 2, 2, 1, 2 },
      new[] { 0, 0, 0, 0, 0, 0, 0 }
    };
    new Solution().MaximumMinutes(grid).Should().Be(-1);
  }

  [Test]
  public void Test6()
  {
    var grid = new[]
    {
      new[] { 0, 2, 0, 0, 1 },
      new[] { 0, 2, 0, 2, 2 },
      new[] { 0, 2, 0, 0, 0 },
      new[] { 0, 0, 2, 2, 0 },
      new[] { 0, 0, 0, 0, 0 }
    };
    new Solution().MaximumMinutes(grid).Should().Be(0);
  }

  [Test]
  public void Test7()
  {
    var grid = new[]
    {
      new[] { 0, 0, 0, 0, 0 },
      new[] { 0, 2, 0, 2, 0 },
      new[] { 0, 2, 0, 2, 0 },
      new[] { 0, 2, 1, 2, 0 },
      new[] { 0, 2, 2, 2, 0 },
      new[] { 0, 0, 0, 0, 0 }
    };
    new Solution().MaximumMinutes(grid).Should().Be(1);
  }
}
