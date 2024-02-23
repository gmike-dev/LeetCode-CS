using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._2642._Design_Graph_With_Shortest_Path_Calculator;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    var g = new Graph(4, new[]
    {
      new[] { 0, 2, 5 },
      new[] { 0, 1, 2 },
      new[] { 1, 2, 1 },
      new[] { 3, 0, 3 }
    });
    g.ShortestPath(3, 2).Should().Be(6);
    g.ShortestPath(0, 3).Should().Be(-1);
    g.AddEdge(new[] { 1, 3, 4 });
    g.ShortestPath(0, 3).Should().Be(6);
  }

  [Test]
  public void Test2()
  {
    var g = new Graph(6, new[]
    {
      new[] { 3, 5, 990551 },
      new[] { 1, 3, 495721 },
      new[] { 0, 1, 985797 },
      new[] { 4, 5, 422863 },
      new[] { 4, 1, 505663 }
    });
    g.ShortestPath(0, 1).Should().Be(985797);
    g.ShortestPath(3, 5).Should().Be(990551);
    g.ShortestPath(4, 4).Should().Be(0);
    g.ShortestPath(0, 3).Should().Be(1481518);
    g.AddEdge(new[] { 5, 0, 250117 });
    g.ShortestPath(4, 5).Should().Be(422863);
    g.AddEdge(new[] { 3, 1, 142005 });
    g.ShortestPath(4, 0).Should().Be(672980);
  }
}