using LeetCode.Common;

namespace LeetCode.___Two_Pointers._16._3Sum_Closest;

public class Solution
{
  public int ThreeSumClosest(int[] nums, int target)
  {
    Array.Sort(nums);
    var n = nums.Length;
    var closestSum = int.MaxValue;
    var closestDiff = int.MaxValue;
    for (var i = 2; i < n; i++)
    {
      var left = 0;
      var right = i - 1;
      while (left < right)
      {
        var s = nums[left] + nums[right] + nums[i];
        if (s < target)
        {
          left++;
        }
        else if (s > target)
        {
          right--;
        }
        else
        {
          return s;
        }
        var d = Math.Abs(target - s);
        if (d < closestDiff)
        {
          closestDiff = d;
          closestSum = s;
        }
      }
    }
    return closestSum;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("[-1,2,1,-4]", 1, 2)]
  [TestCase("[0,0,0]", 1, 0)]
  [TestCase("[4,0,5,-5,3,3,0,-4,-5]", -2, -2)]
  public void Test(string nums, int target, int expected)
  {
    new Solution().ThreeSumClosest(nums.Array(), target).Should().Be(expected);
  }
}
