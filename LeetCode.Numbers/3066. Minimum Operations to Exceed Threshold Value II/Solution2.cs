namespace LeetCode.Numbers._3066._Minimum_Operations_to_Exceed_Threshold_Value_II;

public class Solution2
{
  public int MinOperations(int[] nums, int k)
  {
    var q = new PriorityQueue<int, int>(nums.Length);
    foreach (var num in nums)
    {
      if (num < k)
        q.Enqueue(num, num);
    }
    var count = 0;
    while (q.Count > 1)
    {
      var x = q.Dequeue();
      var y = q.Dequeue();
      var z = 2L * x + y;
      if (z < k)
        q.Enqueue((int)z, (int)z);
      count++;
    }
    count += q.Count;
    return count;
  }
}

[TestFixture]
public class Solution2Tests
{
  [TestCase(new[] { 2, 11, 10, 1, 3 }, 10, 2)]
  [TestCase(new[] { 1, 1, 2, 4, 9 }, 20, 4)]
  [TestCase(new[] { 999999999, 999999999, 999999999 }, 1000000000, 2)]
  public void Test(int[] nums, int k, int expected)
  {
    new Solution2().MinOperations(nums, k).Should().Be(expected);
  }
}
