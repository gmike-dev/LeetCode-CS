namespace LeetCode._152._Maximum_Product_Subarray;

public class KadanesAlgoSolution
{
  public int MaxProduct(int[] nums)
  {
    var maxProduct = int.MinValue;
    var product = 1;
    for (var i = 0; i < nums.Length; i++)
    {
      product *= nums[i];
      maxProduct = Math.Max(maxProduct, product);
      if (product == 0)
        product = 1;
    }
    product = 1;
    for (var i = nums.Length - 1; i >= 0; i--)
    {
      product *= nums[i];
      maxProduct = Math.Max(maxProduct, product);
      if (product == 0)
        product = 1;
    }
    return maxProduct;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { 2, 3, -2, 4 }, 6)]
  [TestCase(new[] { -2, 0, -1 }, 0)]
  [TestCase(new[] { -2 }, -2)]
  [TestCase(new[] { -4, -3 }, 12)]
  [TestCase(new[] { 0, 2 }, 2)]
  [TestCase(new[] { 0 }, 0)]
  [TestCase(new[] { 1, 0, -5, 2, 3, -8, -9 }, 432)]
  [TestCase(new[] { -1,4,-4,5,-2,-1,-1,-2,-3 }, 960)]
  [TestCase(
    new[]
    {
      0, -1, 4, -4, 5, -2, -1, -1, -2, -3, 0, -3, 0, 1, -1, -4, 4, 6, 2, 3, 0, -5, 2, 1, -4, -2, -1, 3, -4, -6, 0, 2, 2,
      -1, -5, 1, 1, 5, -6, 2, 1, -3, -6, -6, -3, 4, 0, -2, 0, 2
    }, 388800)]
  public void Test(int[] nums, int expected)
  {
    new KadanesAlgoSolution().MaxProduct(nums).Should().Be(expected);
  }

  [Test]
  public void Test_Large()
  {
    new KadanesAlgoSolution().MaxProduct(Enumerable.Repeat(1, 20000).ToArray()).Should().Be(1);
  }
}
