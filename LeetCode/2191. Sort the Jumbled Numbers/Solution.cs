namespace LeetCode._2191._Sort_the_Jumbled_Numbers;

public class Solution
{
  public int[] SortJumbled(int[] mapping, int[] nums)
  {
    var map = new Dictionary<int, int>();
    foreach (var num in nums)
      map[num] = Map(num);
    Array.Sort(nums, (x, y) => map[x] - map[y]);
    return nums;

    int Map(int num)
    {
      if (num == 0)
        return mapping[0];
      var s = new Stack<int>();
      while (num > 0)
      {
        s.Push(mapping[num % 10]);
        num /= 10;
      }
      var result = 0;
      while (s.Count > 0)
        result = result * 10 + s.Pop();
      return result;
    }
  }
}

[TestFixture]
public class Tests
{
  [TestCase(new[] { 8, 9, 4, 0, 2, 1, 3, 5, 7, 6 }, new[] { 991, 338, 38 }, new[] { 338, 38, 991 })]
  [TestCase(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new[] { 789, 456, 123 }, new[] { 123, 456, 789 })]
  [TestCase(new[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }, new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
    new[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 })]
  public void Test(int[] mapping, int[] nums, int[] expected)
  {
    new Solution().SortJumbled(mapping, nums).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
