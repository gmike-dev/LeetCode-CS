namespace LeetCode._1._Two_Sum;

public class Solution
{
  public int[] TwoSum(int[] nums, int target)
  {
    var s = new Dictionary<int, List<int>>();
    for (int i = 0; i < nums.Length; i++)
    {
      if (s.TryGetValue(nums[i], out var list))
      {
        if (list.Count < 2)
          list.Add(i);
      }
      else
        s[nums[i]] = new List<int> { i };
    }
    foreach (var (x, ix) in s)
    {
      var y = target - x;
      if (s.TryGetValue(y, out var iy))
      {
        if (x == y)
        {
          if (ix.Count > 1)
            return new[] { ix[0], ix[1] };
        }
        else
        {
          return new[] { ix[0], iy[0] };
        }
      }
    }
    return null;
  }
}
