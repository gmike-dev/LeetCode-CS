using System.Collections.Generic;

namespace LeetCode._229._Majority_Element_II;

public class Solution
{
  /// <summary>
  /// Find all elements that appear more than ⌊ n/3 ⌋ times.
  /// </summary>
  public IList<int> MajorityElement(int[] nums)
  {
    var count1 = 0;
    var count2 = 0;
    var major1 = 0;
    var major2 = 0;
    foreach (var n in nums)
    {
      if (n == major1)
        count1++;
      else if (n == major2)
        count2++;
      else if (count1 == 0)
        (major1, count1) = (n, 1);
      else if (count2 == 0)
        (major2, count2) = (n, 1);
      else
      {
        count1--;
        count2--;
      }
    }
    count1 = 0;
    count2 = 0;
    foreach (var n in nums)
    {
      if (n == major1)
        count1++;
      else if (n == major2)
        count2++;
    }
    var ans = new List<int>();
    if (count1 > nums.Length / 3)
      ans.Add(major1);
    if (count2 > nums.Length / 3)
      ans.Add(major2);
    return ans;
  }
}