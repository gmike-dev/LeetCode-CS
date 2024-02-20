namespace LeetCode.__Numbers._268._Missing_Number;

public class XorOnePassSolution
{
  public int MissingNumber(int[] nums)
  {
    var result = 0;
    var n = nums.Length;
    for (var i = 0; i < n; i++)
    {
      result ^= nums[i] ^ i;
    }
    return result ^ n;
  }
}
