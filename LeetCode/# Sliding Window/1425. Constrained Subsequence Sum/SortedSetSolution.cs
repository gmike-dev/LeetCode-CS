namespace LeetCode.__Sliding_Window._1425._Constrained_Subsequence_Sum;

public class SortedSetSolution
{
  public int ConstrainedSubsetSum(int[] nums, int k)
  {
    var q = new SortedSet<(int sum, int i)> { (nums[0], 0) };
    var s = new int[nums.Length];
    s[0] = nums[0];
    for (var i = 1; i < nums.Length; i++)
    {
      s[i] = Math.Max(nums[i], q.Max.sum + nums[i]);
      q.Add((s[i], i));
      if (i >= k)
        q.Remove((s[i - k], i - k));
    }
    return s.Max();
  }
}
