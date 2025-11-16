using LeetCode.Common;

namespace LeetCode._3748._Count_Stable_Subarrays;

public class Solution
{
  public long[] CountStableSubarrays(int[] nums, int[][] queries)
  {
    var n = nums.Length;
    var prefixSum = new long[n];
    prefixSum[0] = 1;
    for (var i = 1; i < n; i++)
    {
      if (nums[i - 1] <= nums[i])
        prefixSum[i] = prefixSum[i - 1] + 1;
      else
        prefixSum[i] = 1;
    }
    for (var i = 1; i < n; i++)
      prefixSum[i] += prefixSum[i - 1];

    var end = new int[n];
    end[n - 1] = n - 1;
    for (var i = n - 2; i >= 0; i--)
    {
      if (nums[i] <= nums[i + 1])
        end[i] = end[i + 1];
      else
        end[i] = i;
    }

    var m = queries.Length;
    var result = new long[m];
    for (var i = 0; i < m; i++)
    {
      var q = queries[i];
      var (l, r) = (q[0], q[1]);
      var ll = Math.Min(r, end[l]);
      var k = ll - l + 1;
      result[i] = (long)k * (k + 1) / 2 + prefixSum[r] - prefixSum[ll];
    }
    return result;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("[3,1,2]", "[[0,1],[1,2],[0,2]]", "[2,3,4]")]
  [TestCase("[2,2]", "[[0,1],[0,0]]", "[3,1]")]
  [TestCase("[1,2,3,4,5]", "[[0,4],[1,4],[2,4],[3,4],[4,4]]", "[15,10,6,3,1]")]
  [TestCase("[8,12]", "[[1,1]]", "[1]")]
  [TestCase("[5,8,18,21]", "[[2,2],[2,2]]", "[1,1]")]
  public void Test1(string nums, string queries, string expected)
  {
    var actual = new Solution().CountStableSubarrays(nums.Array(), queries.Array2());
    actual.String().Should().Be(expected);
  }
}
