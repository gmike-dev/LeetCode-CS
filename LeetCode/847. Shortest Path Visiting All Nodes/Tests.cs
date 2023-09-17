using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._847._Shortest_Path_Visiting_All_Nodes;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().ShortestPathLength(new[]
    {
      new[] { 1, 2, 3 }, new[] { 0 }, new[] { 0 }, new[] { 0 }
    }).Should().Be(4);
  }

  [Test]
  public void Test2()
  {
    new Solution().ShortestPathLength(new[]
    {
      new[] { 1 }, new[] { 0, 2, 4 }, new[] { 1, 3, 4 }, new[] { 2 }, new[] { 1, 2 }
    }).Should().Be(4);
  }
}