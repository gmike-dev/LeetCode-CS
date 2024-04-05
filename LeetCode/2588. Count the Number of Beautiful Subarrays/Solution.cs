namespace LeetCode._2588._Count_the_Number_of_Beautiful_Subarrays;

/// <summary>
/// https://leetcode.com/problems/count-the-number-of-beautiful-subarrays
/// </summary>
public class Solution
{
  public long BeautifulSubarrays(int[] nums)
  {
    var counter = new int[1 << 21];
    counter[0] = 1;
    var s = 0;
    var ans = 0L;
    foreach (var n in nums)
    {
      s ^= n;
      ans += counter[s]++;
    }
    return ans;
  }
}
