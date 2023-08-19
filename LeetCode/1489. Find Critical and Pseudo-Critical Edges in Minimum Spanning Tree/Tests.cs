using System;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._1489._Find_Critical_and_Pseudo_Critical_Edges_in_Minimum_Spanning_Tree;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().FindCriticalAndPseudoCriticalEdges(5, new[]
    {
      new[] { 0, 1, 1 }, new[] { 1, 2, 1 }, 
      new[] { 2, 3, 2 }, new[] { 0, 3, 2 }, 
      new[] { 0, 4, 3 }, new[] { 3, 4, 3 }, 
      new[] { 1, 4, 6 }
    }).Should().BeEquivalentTo(new[] { new[] { 0, 1 }, new[] { 2, 3, 4, 5 } });
  }

  [Test]
  public void Test2()
  {
    new Solution().FindCriticalAndPseudoCriticalEdges(4, new[]
    {
      new[] { 0, 1, 1 }, new[] { 1, 2, 1 }, 
      new[] { 2, 3, 1 }, new[] { 0, 3, 1 }
    }).Should().BeEquivalentTo(new[] { Array.Empty<int>(), new[] { 0, 1, 2, 3 } });
  }
}