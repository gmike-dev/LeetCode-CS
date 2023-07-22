namespace LeetCode._26._Remove_Duplicates_from_Sorted_Array;

public class Solution
{
  public int RemoveDuplicates(int[] nums)
  {
    var n = nums.Length;
    var i = 1;
    var k = 1;
    while (true)
    {
      while (i < n && nums[k - 1] == nums[i])
        i++;
      if (i == n)
        break;
      nums[k++] = nums[i++];
    }
    return k;
  }
}