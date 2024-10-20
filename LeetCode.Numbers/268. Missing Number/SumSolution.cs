namespace LeetCode.Numbers._268._Missing_Number;

public class SumSolution
{
  public int MissingNumber(int[] nums)
  {
    var s = nums.Sum();
    var n = nums.Length;
    return n * (n + 1) / 2 - s;
  }
}
