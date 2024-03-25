namespace LeetCode._287._Find_the_Duplicate_Number;

/// <summary>
/// https://leetcode.com/problems/find-the-duplicate-number
/// O(n) solution with O(1) memory.
/// </summary>
public class LinearSolution
{
  public int FindDuplicate(int[] nums)
  {
    var fast = nums[0];
    var slow = nums[0];
    do
    {
      fast = nums[nums[fast]];
      slow = nums[slow];
    } while (fast != slow);
    fast = nums[0];
    while (fast != slow)
    {
      fast = nums[fast];
      slow = nums[slow];
    }
    return slow;
  }
}
