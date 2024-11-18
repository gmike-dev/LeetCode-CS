namespace LeetCode.SlidingWindow._1652._Defuse_the_Bomb;

public class Solution
{
  public int[] Decrypt(int[] code, int k)
  {
    var n = code.Length;
    var ans = new int[n];
    if (k > 0)
    {
      for (var i = 0; i < n; i++)
      {
        for (var j = 1; j <= k; j++)
          ans[i] += code[(i + j) % n];
      }
    }
    else if (k < 0)
    {
      k = -k;
      for (var i = 0; i < n; i++)
      {
        for (var j = 1; j <= k; j++)
          ans[i] += code[(n + i - j) % n];
      }
    }
    return ans;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { 5, 7, 1, 4 }, 3, new[] { 12, 10, 16, 13 })]
  [TestCase(new[] { 1, 2, 3, 4 }, 0, new[] { 0, 0, 0, 0 })]
  [TestCase(new[] { 2, 4, 9, 3 }, -2, new[] { 12, 5, 6, 13 })]
  public void Test(int[] code, int k, int[] expected)
  {
    new Solution().Decrypt(code, k).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
