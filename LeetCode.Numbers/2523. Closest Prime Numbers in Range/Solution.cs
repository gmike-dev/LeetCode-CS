namespace LeetCode.Numbers._2523._Closest_Prime_Numbers_in_Range;

public class Solution
{
  public int[] ClosestPrimes(int left, int right)
  {
    Span<bool> isPrime = stackalloc bool[right + 1];
    isPrime.Fill(true);
    isPrime[1] = false;
    for (var i = 2; i * i <= right; i++)
    {
      if (isPrime[i])
      {
        for (var j = i + i; j <= right; j += i)
          isPrime[j] = false;
      }
    }
    var primes = new List<int>();
    for (var i = left; i <= right; i++)
    {
      if (isPrime[i])
        primes.Add(i);
    }
    if (primes.Count < 2)
      return [-1, -1];
    var ans = new int[2];
    var minDiff = int.MaxValue;
    for (var i = 1; i < primes.Count; i++)
    {
      var diff = primes[i] - primes[i - 1];
      if (diff < minDiff)
      {
        minDiff = diff;
        ans[0] = primes[i - 1];
        ans[1] = primes[i];
      }
    }
    return ans;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(10, 19, new[] { 11, 13 })]
  [TestCase(4, 6, new[] { -1, -1 })]
  public void Test(int left, int right, int[] expected)
  {
    new Solution().ClosestPrimes(left, right).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
