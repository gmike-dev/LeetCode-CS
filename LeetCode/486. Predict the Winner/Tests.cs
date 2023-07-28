using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._486._Predict_the_Winner;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 1, 5, 2 }, false)]
  [TestCase(new[] { 1, 5, 233, 7 }, true)]
  public void TestDp(int[] nums, bool result)
  {
    new Solution().PredictTheWinner(nums).Should().Be(result);
  }
  
  [TestCase(new[] { 1, 5, 2 }, false)]
  [TestCase(new[] { 1, 5, 233, 7 }, true)]
  public void TestRecursion(int[] nums, bool result)
  {
    new Solution().PredictTheWinner_Recursion(nums).Should().Be(result);
  }
}