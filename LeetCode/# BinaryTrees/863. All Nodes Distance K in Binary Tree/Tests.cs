using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.__BinaryTrees._863._All_Nodes_Distance_K_in_Binary_Tree;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    var target = new TreeNode(5,
      new TreeNode(6),
      new TreeNode(2,
        new TreeNode(7),
        new TreeNode(4)));
    new Solution().DistanceK(
        new TreeNode(3,
          target,
          new TreeNode(1,
            new TreeNode(0),
            new TreeNode(8))), target, 2)
      .Should()
      .BeEquivalentTo(new[] { 7, 4, 1 });
  }

  [Test]
  public void Test1_1()
  {
    var target = new TreeNode(5,
      new TreeNode(6),
      new TreeNode(2,
        new TreeNode(7),
        new TreeNode(4)));
    new Solution().DistanceK(
        new TreeNode(3,
          target,
          new TreeNode(1,
            new TreeNode(0),
            new TreeNode(8))), target, 1)
      .Should()
      .BeEquivalentTo(new[] { 6, 2, 3 });
  }

  [Test]
  public void Test1_2()
  {
    var target = new TreeNode(5,
      new TreeNode(6),
      new TreeNode(2,
        new TreeNode(7),
        new TreeNode(4)));
    new Solution().DistanceK(
        new TreeNode(3,
          target,
          new TreeNode(1,
            new TreeNode(0),
            new TreeNode(8))), target, 0)
      .Should()
      .BeEquivalentTo(new[] { 5 });
  }

  [Test]
  public void Test1_3()
  {
    var target = new TreeNode(5,
      new TreeNode(6),
      new TreeNode(2,
        new TreeNode(7),
        new TreeNode(4)));
    new Solution().DistanceK(
        new TreeNode(3,
          target,
          new TreeNode(1,
            new TreeNode(0),
            new TreeNode(8))), target, 3)
      .Should()
      .BeEquivalentTo(new[] { 0, 8 });
  }

  [Test]
  public void Test1_4()
  {
    var target = new TreeNode(5,
      new TreeNode(6),
      new TreeNode(2,
        new TreeNode(7),
        new TreeNode(4)));
    new Solution().DistanceK(
        new TreeNode(3,
          target,
          new TreeNode(1,
            new TreeNode(0),
            new TreeNode(8))), target, 4)
      .Should()
      .BeEmpty();
  }

  [Test]
  public void Test2()
  {
    var target = new TreeNode(1);
    new Solution().DistanceK(target, target, 3).Should().BeEmpty();
  }

  [Test]
  public void Test3()
  {
    var target = new TreeNode(1);
    new Solution().DistanceK(target, target, 0).Should().BeEquivalentTo(new[] { 1 });
  }
}
