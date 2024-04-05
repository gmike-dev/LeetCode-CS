namespace LeetCode._287._Find_the_Duplicate_Number;

/// <summary>
/// https://leetcode.com/problems/find-the-duplicate-number
/// O(n * log(n)) solution with O(1) memory.
/// </summary>
public class BinarySearchSolution
{
  public int FindDuplicate(int[] nums)
  {
    var l = 1;
    var r = nums.Length - 1;
    while (l < r)
    {
      var m = l + (r - l) / 2;
      if (nums.Count(x => x <= m) > m)
        r = m;
      else
        l = m + 1;
    }
    return r;
  }
}
