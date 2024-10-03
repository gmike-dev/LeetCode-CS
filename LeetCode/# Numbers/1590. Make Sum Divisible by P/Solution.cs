namespace LeetCode.__Numbers._1590._Make_Sum_Divisible_by_P;

public class Solution
{
  public int MinSubarray(int[] nums, int p)
  {
    long sum = 0;
    foreach (var num in nums)
      sum += num;
    if (sum % p == 0)
      return 0;
    if (p > sum)
      return -1;
    var n = nums.Length;
    var d = new Dictionary<int, int> { [0] = -1 };
    var s = 0;
    var length = n;
    for (var i = 0; i < n; i++)
    {
      s = (s + nums[i]) % p;
      d[s] = i;
      sum -= nums[i];
      if (d.TryGetValue((p - (int)(sum % p)) % p, out var j))
      {
        length = Math.Min(length, i - j);
      }
    }
    return length == n ? -1 : length;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { 3, 1, 4, 2 }, 6, 1)]
  [TestCase(new[] { 6, 3, 5, 2 }, 9, 2)]
  [TestCase(new[] { 1, 2, 3 }, 3, 0)]
  [TestCase(new[] { 1, 2, 3 }, 10, -1)]
  [TestCase(new[] { 1, 2, 3 }, 6, 0)]
  [TestCase(new[] { 1000000000, 1000000000, 1000000000 }, 3, 0)]
  [TestCase(new[] { 8, 32, 31, 18, 34, 20, 21, 13, 1, 27, 23, 22, 11, 15, 30, 4, 2 }, 148, 7)]
  public void Test(int[] nums, int p, int expected)
  {
    new Solution().MinSubarray(nums, p).Should().Be(expected);
  }

  [Test]
  public void LargeData()
  {
    var nums = Enumerable.Repeat(1, 100000).ToArray();
    new Solution().MinSubarray(nums, 33337).Should().Be(33326);
  }
}
