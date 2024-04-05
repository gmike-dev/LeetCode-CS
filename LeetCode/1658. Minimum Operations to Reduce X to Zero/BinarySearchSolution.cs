namespace LeetCode._1658._Minimum_Operations_to_Reduce_X_to_Zero;

public class BinarySearchSolution
{
  public int MinOperations(int[] nums, int x)
  {
    var n = nums.Length;
    var sl = new int[n + 1];
    for (var i = 0; i < n; i++)
      sl[i + 1] = sl[i] + nums[i];
    if (sl[^1] < x)
      return -1;
    if (sl[^1] == x)
      return n;
    var ans = int.MaxValue;
    var sr = 0;
    for (var r = 0; r < n && sr <= x; r++, sr += nums[n - r])
    {
      var l = sl.AsSpan(0, n - r).BinarySearch(x - sr);
      if (l >= 0)
        ans = Math.Min(ans, l + r);
    }
    return ans == int.MaxValue ? -1 : ans;
  }

}
