namespace LeetCode._862._Shortest_Subarray_with_Sum_at_Least_K;

public class PriorityQueueSolution
{
  public int ShortestSubarray(int[] nums, int k)
  {
    var n = nums.Length;
    var q = new PriorityQueue<int, (long s, int index)>();
    long s = 0;
    var length = int.MaxValue;
    for (var i = 0; i < n; i++)
    {
      s += nums[i];
      if (s >= k)
        length = Math.Min(length, i + 1);
      while (q.TryPeek(out var j, out var p) && s - p.s >= k)
      {
        length = Math.Min(length, i - j);
        q.Dequeue();
      }
      q.Enqueue(i, (s, -i));
    }
    return length == int.MaxValue ? -1 : length;
  }
}

[TestFixture]
public class PriorityQueueSolutionTests
{
  [TestCase(new[] { 1 }, 1, 1)]
  [TestCase(new[] { 1, 2 }, 4, -1)]
  [TestCase(new[] { 2, -1, 2 }, 3, 3)]
  public void Test(int[] nums, int k, int expected)
  {
    new PriorityQueueSolution().ShortestSubarray(nums, k).Should().Be(expected);
  }
}
