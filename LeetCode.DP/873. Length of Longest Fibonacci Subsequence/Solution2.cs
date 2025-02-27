namespace LeetCode.DP._873._Length_of_Longest_Fibonacci_Subsequence;

public class Solution2
{
  public int LenLongestFibSubseq(int[] arr)
  {
    var n = arr.Length;
    var ind = new Dictionary<int, int>();
    for (var i = 0; i < n; i++)
      ind[arr[i]] = i;
    var dp = new int[n, n];
    var maxLength = 0;
    for (var i = 1; i < n - 1; i++)
    {
      for (var j = i + 1; j < n; j++)
        maxLength = Math.Max(maxLength, F(i, j));
    }
    return maxLength > 2 ? maxLength : 0;

    int F(int y, int z)
    {
      if (dp[y, z] != 0)
        return dp[y, z];
      if (ind.TryGetValue(arr[z] - arr[y], out var x) && x < y)
        dp[y, z] = F(x, y) + 1;
      else
        dp[y, z] = 2;
      return dp[y, z];
    }
  }
}

[TestFixture]
public class Solution2Tests
{
  [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 5)]
  [TestCase(new[] { 1, 3, 7, 11, 12, 14, 18 }, 3)]
  public void Test(int[] arr, int expected)
  {
    new Solution2().LenLongestFibSubseq(arr).Should().Be(expected);
  }

  [Test]
  public void Test2()
  {
    new Solution2().LenLongestFibSubseq(Enumerable.Range(1, 1000).ToArray()).Should().Be(15);
  }
}
