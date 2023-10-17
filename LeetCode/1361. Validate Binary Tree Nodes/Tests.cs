using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._1361._Validate_Binary_Tree_Nodes;

public class Tests
{
  [TestCase(4, new[] { 1, -1, 3, -1 }, new[] { 2, -1, -1, -1 }, true)]
  [TestCase(4, new[] { 1, -1, 3, -1 }, new[] { 2, 3, -1, -1 }, false)]
  [TestCase(2, new[] { 1, 0 }, new[] { -1, -1 }, false)]
  public void Test(int n, int[] left, int[] right, bool expected)
  {
    new Solution().ValidateBinaryTreeNodes(n, left, right).Should().Be(expected);
  }
}