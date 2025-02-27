namespace LeetCode.DP._873._Length_of_Longest_Fibonacci_Subsequence;

public class Solution3
{
  public int LenLongestFibSubseq(int[] arr)
  {
    var n = arr.Length;
    var index = new Dictionary<int, int>();
    for (var i = 0; i < n; i++)
      index[arr[i]] = i;
    var dp = new int[n][];
    for (var i = 0; i < n; i++)
    {
      dp[i] = new int[n];
      dp[i].AsSpan().Fill(2);
    }

    var maxLength = 0;
    for (var k = 2; k < n; k++)
    {
      for (var j = 1; j < k; j++)
      {
        var x = arr[k] - arr[j];
        if (x < arr[j] && index.TryGetValue(x, out var i))
        {
          dp[j][k] = dp[i][j] + 1;
          maxLength = Math.Max(maxLength, dp[j][k]);
        }
      }
    }
    return maxLength > 2 ? maxLength : 0;
  }
}

[TestFixture]
public class Solution3Tests
{
  [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 5)]
  [TestCase(new[] { 1, 3, 7, 11, 12, 14, 18 }, 3)]
  public void Test(int[] arr, int expected)
  {
    new Solution3().LenLongestFibSubseq(arr).Should().Be(expected);
  }

  [Test]
  public void Test2()
  {
    new Solution3().LenLongestFibSubseq(Enumerable.Range(1, 1000).ToArray()).Should().Be(15);
  }
}
