using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._2055._Plates_Between_Candles;

[TestFixture]
public class LinearSolutionTests
{
  [Test]
  public void Test1()
  {
    new LinearSolution().PlatesBetweenCandles("**|**|***|", new[]
    {
      new[] { 2, 5 },
      new[] { 5, 9 }
    }).Should().BeEquivalentTo(new[] { 2, 3 }, options => options.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    new LinearSolution().PlatesBetweenCandles("***|**|*****|**||**|*", new[]
    {
      new[] { 1, 17 },
      new[] { 4, 5 },
      new[] { 14, 17 },
      new[] { 5, 11 },
      new[] { 15, 16 },
    }).Should().BeEquivalentTo(new[] { 9, 0, 0, 0, 0 }, options => options.WithStrictOrdering());
  }

  [Test]
  public void Test3()
  {
    new LinearSolution().PlatesBetweenCandles("*****|****", new[]
    {
      new[] { 2, 5 },
      new[] { 5, 9 },
      new[] { 0, 9 }
    }).Should().BeEquivalentTo(new[] { 0, 0, 0 }, options => options.WithStrictOrdering());
  }

  [Test]
  public void Test4()
  {
    new LinearSolution().PlatesBetweenCandles("||||", new[]
    {
      new[] { 0, 0 },
      new[] { 0, 1 },
      new[] { 0, 2 },
      new[] { 1, 3 },
      new[] { 0, 3 },
    }).Should().BeEquivalentTo(new[] { 0, 0, 0, 0, 0 }, options => options.WithStrictOrdering());
  }
  
  [Test]
  public void Test5()
  {
    new LinearSolution().PlatesBetweenCandles("|", new[]
    {
      new[] { 0, 0 },
    }).Should().BeEquivalentTo(new[] { 0 }, options => options.WithStrictOrdering());
  }
  
  [Test]
  public void Test6()
  {
    new LinearSolution().PlatesBetweenCandles("***", new[]
    {
      new[] { 2, 2 },
    }).Should().BeEquivalentTo(new[] { 0 }, options => options.WithStrictOrdering());
  }
}