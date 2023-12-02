using System.Collections.Generic;

namespace LeetCode._78._Subsets;

public class BitmaskSolution
{
  public IList<IList<int>> Subsets(int[] nums)
  {
    var n = nums.Length;
    var m = 1 << n;
    var result = new IList<int>[m];
    for (var set = 0; set < m; set++)
    {
      var subset = new List<int>(n);
      var s = set;
      var i = 0;
      while (s != 0)
      {
        if ((s & 1) != 0)
        {
          subset.Add(nums[i]);
        }
        i++;
        s >>= 1;
      }
      result[set] = subset;
    }
    return result;
  }
}