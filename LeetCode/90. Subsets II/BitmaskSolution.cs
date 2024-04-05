namespace LeetCode._90._Subsets_II;

public class BitmaskSolution
{
  public IList<IList<int>> SubsetsWithDup(int[] nums)
  {
    Array.Sort(nums);
    var n = nums.Length;
    var m = 1 << n;
    var used = new HashSet<long>();
    var result = new List<IList<int>>();
    for (var set = 0; set < m; set++)
    {
      var subset = new List<int>(n);
      var s = set;
      var i = 0;
      var key = 0L;
      while (s != 0)
      {
        if ((s & 1) != 0)
        {
          subset.Add(nums[i]);
          key = (key << 5) + (11 + nums[i]);
        }
        i++;
        s >>= 1;
      }
      if (used.Add(key))
      {
        result.Add(subset);
      }
    }
    return result;
  }
}
