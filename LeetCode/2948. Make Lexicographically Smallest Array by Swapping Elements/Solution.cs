namespace LeetCode._2948._Make_Lexicographically_Smallest_Array_by_Swapping_Elements;

public class Solution
{
  public int[] LexicographicallySmallestArray(int[] nums, int limit)
  {
    var n = nums.Length;
    Span<int> sorted = stackalloc int[n];
    nums.AsSpan().CopyTo(sorted);
    sorted.Sort();
    var numGroup = new Dictionary<int, int> { [sorted[0]] = 0 };
    var groups = new List<Queue<int>> { new() };
    groups[0].Enqueue(sorted[0]);
    for (int i = 1, g = 0; i < n; i++)
    {
      if (sorted[i] - sorted[i - 1] > limit)
        g++;
      numGroup[sorted[i]] = g;
      if (g == groups.Count)
        groups.Add(new Queue<int>());
      groups[g].Enqueue(sorted[i]);
    }
    var result = new int[n];
    for (var i = 0; i < n; i++)
      result[i] = groups[numGroup[nums[i]]].Dequeue();
    return result;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { 1, 5, 3, 9, 8 }, 2, new[] { 1, 3, 5, 8, 9 })]
  [TestCase(new[] { 1, 7, 6, 18, 2, 1 }, 3, new[] { 1, 6, 7, 18, 1, 2 })]
  [TestCase(new[] { 1, 7, 28, 19, 10 }, 3, new[] { 1, 7, 28, 19, 10 })]
  public void Test(int[] nums, int limit, int[] expected)
  {
    new Solution().LexicographicallySmallestArray(nums, limit).Should()
      .BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
