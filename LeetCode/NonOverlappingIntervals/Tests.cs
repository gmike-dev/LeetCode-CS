using NUnit.Framework;

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
    Assert.That(result, Is.EqualTo(1));
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
    Assert.That(result, Is.EqualTo(2));
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
    Assert.That(result, Is.EqualTo(0));
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
    Assert.That(result, Is.EqualTo(2));
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
    Assert.That(result, Is.EqualTo(2));
  }
}