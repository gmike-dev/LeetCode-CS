namespace LeetCode._1887._Reduction_Operations;

public class Solution
{
  public int ReductionOperations(int[] nums)
  {
    var cnt = new int[50001];
    foreach (var num in nums)
    {
      cnt[num]++;
    }
    var prev = 0;
    var s = 0;
    for (var i = cnt.Length - 1; i > 0; i--)
    {
      if (cnt[i] > 0)
      {
        s += prev;
        prev += cnt[i];
      }
    }
    return s;
  }
}