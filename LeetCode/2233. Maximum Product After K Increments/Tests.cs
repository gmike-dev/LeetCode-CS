using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._2233._Maximum_Product_After_K_Increments;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 0, 4 }, 5, 20)]
  [TestCase(new[] { 6, 3, 3, 2 }, 2, 216)]
  [TestCase(new[] { 1 }, 20, 21)]
  public void PriorityQueueSolutionTest(int[] nums, int k, int expected)
  {
    new PriorityQueueSolution().MaximumProduct(nums, k).Should().Be(expected);
  }
  
  [TestCase(new[] { 0, 4 }, 5, 20)]
  [TestCase(new[] { 6, 3, 3, 2 }, 2, 216)]
  [TestCase(new[] { 1 }, 20, 21)]
  public void HeapSolutionTest(int[] nums, int k, int expected)
  {
    new HeapSolution().MaximumProduct(nums, k).Should().Be(expected);
  }
}