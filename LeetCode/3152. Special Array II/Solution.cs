namespace LeetCode._3152._Special_Array_II;

public class Solution
{
  public bool[] IsArraySpecial(int[] nums, int[][] queries)
  {
    var len = new int[nums.Length];
    len[0] = 1;
    for (var r = 1; r < nums.Length; r++)
      len[r] = nums[r - 1] % 2 == nums[r] % 2 ? 1 : len[r - 1] + 1;
    return queries.Select(q => len[q[1]] > q[1] - q[0]).ToArray();
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    new Solution().IsArraySpecial([3, 4, 1, 2, 6], [[0, 4]]).Should()
      .BeEquivalentTo([false], o => o.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    new Solution().IsArraySpecial([4, 3, 1, 6], [[0, 2], [2, 3]]).Should()
      .BeEquivalentTo([false, true], o => o.WithStrictOrdering());
  }

  [Test]
  public void Test3()
  {
    new Solution().IsArraySpecial([1], [[0, 0]]).Should()
      .BeEquivalentTo([true], o => o.WithStrictOrdering());
  }
}
