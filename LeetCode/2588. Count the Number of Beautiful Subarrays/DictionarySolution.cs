namespace LeetCode._2588._Count_the_Number_of_Beautiful_Subarrays;

/// <summary>
/// https://leetcode.com/problems/count-the-number-of-beautiful-subarrays
/// </summary>
public class DictionarySolution
{
  public long BeautifulSubarrays(int[] nums)
  {
    var prev = new Dictionary<int, int> { { 0, 1 } };
    var s = 0;
    var ans = 0L;
    foreach (var n in nums)
    {
      s ^= n;
      var count = prev.GetValueOrDefault(s, 0);
      if (count != 0)
        ans += count;
      prev[s] = count + 1;
    }
    return ans;
  }
}
