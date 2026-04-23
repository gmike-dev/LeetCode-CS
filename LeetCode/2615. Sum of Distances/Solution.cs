using LeetCode.Common;

namespace LeetCode._2615._Sum_of_Distances;

public class Solution
{
  public long[] Distance(int[] nums)
  {
    int n = nums.Length;
    Dictionary<int, long> s = new(n);
    Dictionary<int, long> cnt = new(n);
    long[] arr = new long[n];
    for (int i = 0; i < n; i++)
    {
      arr[i] = cnt.GetValueOrDefault(nums[i]) * i - s.GetValueOrDefault(nums[i]);
      s[nums[i]] = s.GetValueOrDefault(nums[i]) + i;
      cnt[nums[i]] = cnt.GetValueOrDefault(nums[i]) + 1;
    }
    s.Clear();
    cnt.Clear();
    for (int i = n - 1; i >= 0; i--)
    {
      arr[i] += s.GetValueOrDefault(nums[i]) - cnt.GetValueOrDefault(nums[i]) * i;
      s[nums[i]] = s.GetValueOrDefault(nums[i]) + i;
      cnt[nums[i]] = cnt.GetValueOrDefault(nums[i]) + 1;
    }
    return arr;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("[1,3,1,1,2]", "[5,0,3,4,0]")]
  [TestCase("[0,5,3]", "[0,0,0]")]
  public void Test(string nums, string expected)
  {
    new Solution().Distance(nums.Array()).Should().BeEquivalentTo(expected.Array());
  }
}
