using LeetCode.Common;

namespace LeetCode.BinaryTrees._222._Count_Complete_Tree_Nodes;

[TestFixture]
public class Benchmark
{
  private const int LargeTreeSize = 1_000_000;
  private TreeNode largeTree;

  [OneTimeSetUp]
  public void Warmup()
  {
    largeTree = TreeNode.FromString($"[{string.Join(',', Enumerable.Range(0, LargeTreeSize))}]");
  }

  // [Test]
  // [Repeat(100)]
  // public void LinearSolution()
  // {
  //   new LinearSolution().CountNodes(largeTree).Should().Be(LargeTreeSize);
  // }

  [Test]
  [Repeat(100000)]
  public void LogarithmicSolution()
  {
    new LogarithmicRecursiveSolution().CountNodes(largeTree).Should().Be(LargeTreeSize);
  }

  [Test]
  [Repeat(100000)]
  public void LogarithmicIterativeSolution()
  {
    new LogarithmicIterativeSolution().CountNodes(largeTree).Should().Be(LargeTreeSize);
  }

  [Test]
  [Repeat(100000)]
  public void LogarithmicIterativeSolution2()
  {
    new LogarithmicIterativeSolution2().CountNodes(largeTree).Should().Be(LargeTreeSize);
  }
}
