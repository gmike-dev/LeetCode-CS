namespace LeetCode.LongestIncreasingSubsequence;

public class BinarySearchSolution
{
  public int LengthOfLIS(int[] nums)
  {
    var seq = new List<int>(nums.Length) { nums[0] };
    foreach (var x in nums)
    {
      if (seq[^1] < x)
      {
        seq.Add(x);
      }
      else
      {
        var pos = seq.BinarySearch(x);
        if (pos < 0)
          pos = ~pos;
        seq[pos] = x;
      }
    }
    return seq.Count;
  }
}
