namespace LeetCode.NonOverlappingIntervals;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    var sln = new Solution();
    var result = sln.EraseOverlapIntervals(new[]
    {
      new[] { 1, 2 },
      new[] { 2, 3 },
      new[] { 3, 4 },
      new[] { 1, 3 }
    });
    result.Should().Be(1);
  }

  [Test]
  public void Test2()
  {
    var sln = new Solution();
    var result = sln.EraseOverlapIntervals(new[]
    {
      new[] { 1, 2 },
      new[] { 1, 2 },
      new[] { 1, 2 }
    });
    result.Should().Be(2);
  }

  [Test]
  public void Test3()
  {
    var sln = new Solution();
    var result = sln.EraseOverlapIntervals(new[]
    {
      new[] { 1, 2 },
      new[] { 2, 3 }
    });
    result.Should().Be(0);
  }

  [Test]
  public void Test4()
  {
    var sln = new Solution();
    var result = sln.EraseOverlapIntervals(new[]
    {
      new[] { 1, 100 },
      new[] { 11, 22 },
      new[] { 1, 11 },
      new[] { 2, 12 }
    });
    result.Should().Be(2);
  }

  [Test]
  public void Test5()
  {
    var sln = new Solution();
    var result = sln.EraseOverlapIntervals(new[]
    {
      new[] { 0, 2 },
      new[] { 1, 3 },
      new[] { 2, 4 },
      new[] { 3, 5 },
      new[] { 4, 6 }
    });
    result.Should().Be(2);
  }
}
