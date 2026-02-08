using LeetCode.Common;

namespace LeetCode.__Monotonic._84._Largest_Rectangle_in_Histogram;

public class Solution
{
  public int LargestRectangleArea(int[] heights)
  {
    var n = heights.Length;
    var left = new Stack<int>();
    var countLeft = new int[n];
    for (var i = 0; i < n; i++)
    {
      while (left.Count > 0 && heights[left.Peek()] >= heights[i])
      {
        left.Pop();
      }
      if (left.Count > 0)
      {
        countLeft[i] = i - left.Peek() - 1;
      }
      else
      {
        countLeft[i] = i;
      }
      left.Push(i);
    }
    var right = new Stack<int>();
    var countRight = new int[n];
    for (var i = n - 1; i >= 0; i--)
    {
      while (right.Count > 0 && heights[right.Peek()] >= heights[i])
      {
        right.Pop();
      }
      if (right.Count > 0)
      {
        countRight[i] = right.Peek() - i - 1;
      }
      else
      {
        countRight[i] = n - i - 1;
      }
      right.Push(i);
    }
    var largestArea = 0;
    for (var i = 0; i < n; i++)
    {
      largestArea = Math.Max(largestArea, (countLeft[i] + 1 + countRight[i]) * heights[i]);
    }
    return largestArea;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("[2,1,5,6,2,3]", 10)]
  [TestCase("[2,4]", 4)]
  public void Test(string heights, int expected)
  {
    new Solution().LargestRectangleArea(heights.Array()).Should().Be(expected);
  }
}
