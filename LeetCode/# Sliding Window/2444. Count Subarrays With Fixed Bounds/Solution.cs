namespace LeetCode.__Sliding_Window._2444._Count_Subarrays_With_Fixed_Bounds;

public class Solution
{
  public long CountSubarrays(int[] a, int minK, int maxK)
  {
    var left = -1;
    var lastMinK = -1;
    var lastMaxK = -1;
    var numberOfSubArrays = 0L;
    for (var right = 0; right < a.Length; right++)
    {
      if (a[right] < minK || a[right] > maxK)
      {
        left = right;
        continue;
      }
      if (a[right] == minK)
        lastMinK = right;
      if (a[right] == maxK)
        lastMaxK = right;
      if (lastMinK != -1 && lastMaxK != -1)
        numberOfSubArrays += Math.Max(0, Math.Min(lastMinK, lastMaxK) - left);
    }
    return numberOfSubArrays;
  }
}
