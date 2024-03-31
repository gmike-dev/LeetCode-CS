using System;

namespace LeetCode.__Sliding_Window._2444._Count_Subarrays_With_Fixed_Bounds;

public class MySolution
{
  public long CountSubarrays(int[] a, int minK, int maxK)
  {
    var answer = 0L;
    var left1 = 0;
    var left2 = 0;
    var min = int.MaxValue;
    var max = int.MinValue;
    var cMin = 0;
    var cMax = 0;
    for (var right = 0; right < a.Length; right++)
    {
      min = Math.Min(min, a[right]);
      max = Math.Max(max, a[right]);

      if (min < minK || max > maxK)
      {
        min = int.MaxValue;
        max = int.MinValue;
        cMin = 0;
        cMax = 0;
        left1 = right + 1;
        left2 = right + 1;
        continue;
      }

      if (a[right] == minK)
        cMin++;
      if (a[right] == maxK)
        cMax++;

      if (min != minK || max != maxK)
        continue;

      while ((a[left2] != minK || cMin > 1) && (a[left2] != maxK || cMax > 1))
      {
        if (a[left2] == minK)
          cMin--;
        if (a[left2] == maxK)
          cMax--;
        left2++;
      }

      answer += left2 - left1 + 1;
    }
    return answer;
  }
}
