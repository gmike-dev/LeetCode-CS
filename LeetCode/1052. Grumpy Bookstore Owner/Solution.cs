namespace LeetCode._1052._Grumpy_Bookstore_Owner;

public class Solution
{
  public int MaxSatisfied(int[] customers, int[] grumpy, int minutes)
  {
    var n = customers.Length;
    var satisfied = 0;
    for (var i = 0; i < minutes; i++)
      satisfied += customers[i];
    for (var i = minutes; i < n; i++)
      satisfied += customers[i] * (1 - grumpy[i]);
    var ans = satisfied;
    for (var i = 0; i + minutes < n; i++)
    {
      satisfied += customers[i + minutes] * grumpy[i + minutes] - customers[i] * grumpy[i];
      ans = Math.Max(ans, satisfied);
    }
    return ans;
  }
}

[TestFixture]
public class Tests
{
  [TestCase(new[] { 1, 0, 1, 2, 1, 1, 7, 5 }, new[] { 0, 1, 0, 1, 0, 1, 0, 1 }, 3, 16)]
  [TestCase(new[] { 1 }, new[] { 0 }, 1, 1)]
  [TestCase(new[] { 5, 8 }, new[] { 0, 1 }, 1, 13)]
  public void Test(int[] customers, int[] grumpy, int minutes, int expected)
  {
    new Solution().MaxSatisfied(customers, grumpy, minutes).Should().Be(expected);
  }
}
