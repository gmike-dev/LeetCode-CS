namespace LeetCode.__Monotonic._3113._Find_the_Number_of_Subarrays;

public class Solution
{
  public long NumberOfSubarrays(int[] a)
  {
    var s = new Stack<(int val, int count)>();
    var result = 0L;
    foreach (var x in a)
    {
      while (s.Count > 0 && s.Peek().val < x)
        s.Pop();
      var count = 1;
      if (s.TryPeek(out var item) && item.val == x)
      {
        count += item.count;
        s.Pop();
      }
      s.Push((x, count));
      result += count;
    }
    return result;
  }
}

[TestFixture]
public class Tests
{
  [TestCase(new[] { 1, 4, 3, 3, 2 }, 6)]
  [TestCase(new[] { 3, 3, 3 }, 6)]
  [TestCase(new[] { 1 }, 1)]
  public void Test1(int[] a, long expected)
  {
    new Solution()
      .NumberOfSubarrays([1, 4, 3, 3, 2])
      .Should()
      .Be(6);
  }
}
