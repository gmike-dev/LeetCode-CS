namespace LeetCode._27._Remove_Element;

public class Solution
{
  public int RemoveElement(int[] nums, int val)
  {
    var n = nums.Length;
    var k = 0;
    for (var i = 0; i < n; i++)
      if (nums[i] != val)
        nums[k++] = nums[i];
    return k;
  }
}