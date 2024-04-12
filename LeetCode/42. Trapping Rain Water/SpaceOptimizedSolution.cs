namespace LeetCode._42._Trapping_Rain_Water;

public class SpaceOptimizedSolution
{
  public int Trap(int[] height)
  {
    var n = height.Length;
    var maxRight = new int[n];

    maxRight[^1] = height[^1];
    for (var i = n - 2; i >= 0; i--)
      maxRight[i] = Math.Max(maxRight[i + 1], height[i]);

    var result = 0;
    var maxLeft = 0;
    for (var i = 0; i < n; i++)
    {
      maxLeft = Math.Max(maxLeft, height[i]);
      result += Math.Min(maxLeft, maxRight[i]) - height[i];
    }

    return result;
  }
}
