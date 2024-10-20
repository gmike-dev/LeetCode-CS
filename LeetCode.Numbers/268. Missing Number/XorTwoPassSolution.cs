namespace LeetCode.Numbers._268._Missing_Number;

public class XorTwoPassSolution
{
  public int MissingNumber(int[] nums)
  {
    var result = 0;
    var n = nums.Length;
    for (var i = 0; i <= n; i++)
    {
      result ^= i;
    }
    for (var i = 0; i < n; i++)
    {
      result ^= nums[i];
    }
    return result;
  }
}
