namespace LeetCode._659._Split_Array_into_Consecutive_Subsequences;

public class Solution
{
  public bool IsPossible(int[] nums)
  {
    var d = new Dictionary<int, PriorityQueue<int, int>>();
    foreach (var num in nums)
    {
      var size = d.TryGetValue(num - 1, out var q1) && q1.Count != 0 ? q1.Dequeue() : 0;
      if (!d.TryGetValue(num, out var q2))
      {
        q2 = new PriorityQueue<int, int>();
        d.Add(num, q2);
      }
      q2.Enqueue(size + 1, size + 1);
    }
    return d.Values.Where(q => q.Count > 0).Min(q => q.Peek()) >= 3;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { 1, 2, 3, 3, 4, 5 }, true)]
  [TestCase(new[] { 1, 2, 3, 3, 4, 4, 5, 5 }, true)]
  [TestCase(new[] { 1, 2, 3, 4, 4, 5 }, false)]
  public void Test(int[] nums, bool expected)
  {
    new Solution().IsPossible(nums).Should().Be(expected);
  }
}
