namespace LeetCode.Numbers._3066._Minimum_Operations_to_Exceed_Threshold_Value_II;

public class Solution
{
  public int MinOperations(int[] nums, int k)
  {
    var q = new PriorityQueue<long, long>();
    foreach (var num in nums)
      q.Enqueue(num, num);
    var count = 0;
    while (q.Peek() < k)
    {
      var x = q.Dequeue();
      var y = q.Dequeue();
      var z = x * 2L + y;
      q.Enqueue(z, z);
      count++;
    }
    return count;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { 2, 11, 10, 1, 3 }, 10, 2)]
  [TestCase(new[] { 1, 1, 2, 4, 9 }, 20, 4)]
  [TestCase(new[] { 999999999, 999999999, 999999999 }, 1000000000, 2)]
  public void Test(int[] nums, int k, int expected)
  {
    new Solution().MinOperations(nums, k).Should().Be(expected);
  }
}
