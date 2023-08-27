namespace LeetCode._169._Majority_Element;

/// <summary>
/// O(1) memory solution.
/// </summary>
public class Solution
{
  public int MajorityElement(int[] nums)
  {
    var n = nums.Length;
    var major = nums[0];
    var count = 1;
    for (var i = 1; i < n; i++)
    {
      if (count == 0)
      {
        major = nums[i];
        count = 1;
      }
      else if (major == nums[i])
      {
        count++;
      }
      else
      {
        count--;
      }
    }
    return major;
  }
}