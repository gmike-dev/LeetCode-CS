using System.Collections.Generic;

namespace LeetCode._169._Majority_Element;

public class SolutionUsingDictionary
{
  public int MajorityElement(int[] nums)
  {
    var n = nums.Length;
    var counter = new Dictionary<int, int>();
    foreach (var num in nums)
    {
      if (counter.TryGetValue(num, out var count))
      {
        if (count >= n / 2)
          return num;
        counter[num] = count + 1;
      }
      else
      {
        counter[num] = 1;
      }
    }
    return nums[0];
  }
}