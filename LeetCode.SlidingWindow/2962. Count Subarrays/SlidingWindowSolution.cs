namespace LeetCode.SlidingWindow._2962._Count_Subarrays;

/// <summary>
/// https://leetcode.com/problems/count-subarrays-where-max-element-appears-at-least-k-times/
/// </summary>
public class SlidingWindowSolution
{
  public long CountSubarrays(int[] a, int k)
  {
    var maxElement = a.Max();
    var left = 0;
    var maxElementsInWindow = 0;
    var answer = 0L;
    foreach (var x in a)
    {
      if (x == maxElement)
        maxElementsInWindow++;
      while (maxElementsInWindow == k)
      {
        if (a[left] == maxElement)
          maxElementsInWindow--;
        left++;
      }
      answer += left;
    }
    return answer;
  }

}
