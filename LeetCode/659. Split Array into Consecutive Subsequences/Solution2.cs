namespace LeetCode._659._Split_Array_into_Consecutive_Subsequences;

public class Solution2
{
  public bool IsPossible(int[] nums)
  {
    var d = Enumerable.Range(0, 2002).Select(_ => new PriorityQueue<int, int>()).ToArray();
    foreach (var num in nums)
    {
      // Find the minimum length of a sequence that ends with num - 1
      d[1001 + num - 1].TryDequeue(out var size, out _);
      // Add a new sequence that ends with num
      d[1001 + num].Enqueue(size + 1, size + 1);
    }
    // Check that all sequences are longer than 3
    return d.Where(q => q.Count != 0).Min(q => q.Peek()) >= 3;
  }
}


[TestFixture]
public class Solution2Tests
{
  [TestCase(new[] { 1, 2, 3, 3, 4, 5 }, true)]
  [TestCase(new[] { 1, 2, 3, 3, 4, 4, 5, 5 }, true)]
  [TestCase(new[] { 1, 2, 3, 4, 4, 5 }, false)]
  public void Test(int[] nums, bool expected)
  {
    new Solution2().IsPossible(nums).Should().Be(expected);
  }
}
