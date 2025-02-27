namespace LeetCode.DP._873._Length_of_Longest_Fibonacci_Subsequence;

public class Solution
{
  public int LenLongestFibSubseq(int[] arr)
  {
    var n = arr.Length;
    var maxLength = 0;
    var ind = new Dictionary<int, int>();
    for (var i = 0; i < n; i++)
      ind[arr[i]] = i;
    for (var i = 0; i < n - 2; i++)
    {
      for (var j = i + 1; j < n - 1; j++)
      {
        var length = 2;
        var x = i;
        var y = j;
        while (true)
        {
          if (!ind.TryGetValue(arr[x] + arr[y], out var z) || z <= y)
            break;
          (x, y) = (y, z);
          length++;
        }
        if (length >= 3)
          maxLength = Math.Max(maxLength, length);
      }
    }
    return maxLength;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 5)]
  [TestCase(new[] { 1, 3, 7, 11, 12, 14, 18 }, 3)]
  public void Test(int[] arr, int expected)
  {
    new Solution().LenLongestFibSubseq(arr).Should().Be(expected);
  }

  [Test]
  public void Test2()
  {
    new Solution().LenLongestFibSubseq(Enumerable.Range(1, 1000).ToArray()).Should().Be(15);
  }
}
