using System.IO;

namespace LeetCode.Numbers._2163._Minimum_Difference_in_Sums_After_Removal_of_Elements;

public class Solution
{
  public long MinimumDifference(int[] nums)
  {
    var n = nums.Length / 3;
    var maxQueue = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y - x));
    var sl = 0L;
    var minSum = new long[nums.Length];
    for (var i = 0; i < n; i++)
    {
      maxQueue.Enqueue(nums[i], nums[i]);
      sl += nums[i];
      minSum[i] = sl;
    }
    for (var i = n; i < 2*n; i++)
    {
      sl += nums[i] - maxQueue.EnqueueDequeue(nums[i], nums[i]);
      minSum[i] = sl;
    }

    var minQueue = new PriorityQueue<int, int>();
    var sr = 0L;
    var maxSum = new long[nums.Length];
    for (var i = nums.Length - 1; i >= 2 * n; i--)
    {
      minQueue.Enqueue(nums[i], nums[i]);
      sr += nums[i];
      maxSum[i] = sr;
    }
    for (var i = 2 * n - 1; i >= n; i--)
    {
      sr += nums[i] - minQueue.EnqueueDequeue(nums[i], nums[i]);
      maxSum[i] = sr;
    }

    var res = long.MaxValue;
    for (var i = n-1; i < 2*n; i++)
    {
      res = Math.Min(res, minSum[i] - maxSum[i + 1]);
    }
    return res;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { 3, 1, 2 }, -1)]
  [TestCase(new[] { 7, 9, 5, 8, 1, 3 }, 1)]
  public void Test(int[] nums, long expected)
  {
    new Solution().MinimumDifference(nums).Should().Be(expected);
  }

  public static IEnumerable<object> GetTestCases()
  {
    var source = Path.Join(TestContext.CurrentContext.WorkDirectory,
      "2163. Minimum Difference in Sums After Removal of Elements", "TestCases.txt");
    using var sr = new StreamReader(source);
    var result = new List<object[]>();
    while (!sr.EndOfStream)
    {
      var nums = sr.ReadLine().Trim('[', ']').Split(",").Select(int.Parse).ToArray();
      var expected = long.Parse(sr.ReadLine());
      result.Add([nums, expected]);
    }
    return result;
  }

  [TestCaseSource(nameof(GetTestCases))]
  public void TestLargeInput(int[] nums, long expected)
  {
    new Solution().MinimumDifference(nums).Should().Be(expected);
  }
}
