namespace LeetCode._42._Trapping_Rain_Water;

public class Solution
{
  public int Trap(int[] height)
  {
    var n = height.Length;
    var maxLeft = new int[n];
    var maxRight = new int[n];

    maxLeft[0] = height[0];
    for (var i = 1; i < n; i++)
      maxLeft[i] = Math.Max(maxLeft[i - 1], height[i]);

    maxRight[^1] = height[^1];
    for (var i = n - 2; i >= 0; i--)
      maxRight[i] = Math.Max(maxRight[i + 1], height[i]);

    var result = 0;
    for (var i = 0; i < n; i++)
      result += Math.Min(maxLeft[i], maxRight[i]) - height[i];

    return result;
  }
}

[TestFixture]
public class Tests
{
  [TestCase(new[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }, 6)]
  [TestCase(new[] { 4, 2, 0, 3, 2, 5 }, 9)]
  [TestCase(new[] { 0, 1 }, 0)]
  [TestCase(new[] { 1, 1 }, 0)]
  [TestCase(new[] { 1, 0 }, 0)]
  [TestCase(new[] { 1 }, 0)]
  public void Test(int[] height, int expected)
  {
    new Solution().Trap(height).Should().Be(expected);
  }
}
