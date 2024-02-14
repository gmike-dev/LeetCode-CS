namespace LeetCode._2149._Rearrange_Array_Elements_by_Sign;

public class TwoPointersSolution
{
  public int[] RearrangeArray(int[] nums)
  {
    var n = nums.Length;
    var result = new int[n];
    var pi = 0;
    var ni = 0;
    for (var i = 0; i < n; i += 2)
    {
      while (nums[pi] < 0)
        pi++;
      while (nums[ni] > 0)
        ni++;
      result[i] = nums[pi++];
      result[i + 1] = nums[ni++];
    }
    return result;
  }
}
