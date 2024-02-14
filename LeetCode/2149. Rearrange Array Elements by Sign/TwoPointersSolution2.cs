namespace LeetCode._2149._Rearrange_Array_Elements_by_Sign;

public class TwoPointersSolution2
{
  public int[] RearrangeArray(int[] nums)
  {
    var n = nums.Length;
    var result = new int[n];
    var pi = 0;
    var ni = 1;
    for (var i = 0; i < n; i++)
    {
      if (nums[i] > 0)
      {
        result[pi] = nums[i];
        pi += 2;
      }
      else
      {
        result[ni] = nums[i];
        ni += 2;
      }
    }
    return result;
  }
}
