using LeetCode.Common;

namespace LeetCode._3013._Divide_an_Array_Into_Subarrays_With_Minimum_Cost_II;

public class Solution
{
  public long MinimumCost(int[] nums, int k, int dist)
  {
    var n = nums.Length;
    var s1 = new SortedSet<(int value, int index)>();
    var s2 = new SortedSet<(int value, int index)>();
    var sum = 0L;
    for (var i = 2; i < n && i <= 1 + dist; i++)
    {
      s1.Add((nums[i], i));
      sum += nums[i];
      if (s1.Count > k - 2)
      {
        var s1Max = s1.Max;
        sum -= s1Max.value;
        s1.Remove(s1Max);
        s2.Add(s1Max);
      }
    }
    var minSum = nums[1] + sum;
    for (var i = 2; i < n - k + 2; i++)
    {
      if (s1.Remove((nums[i], i)))
      {
        sum -= nums[i];
        if (s2.Count > 0)
        {
          var s2Min = s2.Min;
          s1.Add(s2Min);
          sum += s2Min.value;
          s2.Remove(s2Min);
        }
      }
      else
      {
        s2.Remove((nums[i], i));
      }
      var j = i + dist;
      if (j < n)
      {
        s1.Add((nums[j], j));
        sum += nums[j];
        if (s1.Count > k - 2)
        {
          var s1Max = s1.Max;
          sum -= s1Max.value;
          s1.Remove(s1Max);
          s2.Add(s1Max);
        }
      }
      minSum = Math.Min(minSum, nums[i] + sum);
    }
    return nums[0] + minSum;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("[1,3,2,6,4,2]", 3, 3, 5)]
  [TestCase("[10,1,2,2,2,1]", 4, 3, 15)]
  [TestCase("[10,8,18,9]", 3, 1, 36)]
  [TestCase("[1,5,3,6]", 3, 2, 9)]
  public void Test(string nums, int k, int dist, long expected)
  {
    new Solution().MinimumCost(nums.Array(), k, dist).Should().Be(expected);
  }
}
