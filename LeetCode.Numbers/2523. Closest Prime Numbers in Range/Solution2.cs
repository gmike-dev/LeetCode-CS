namespace LeetCode.Numbers._2523._Closest_Prime_Numbers_in_Range;

public class Solution2
{
  public int[] ClosestPrimes(int left, int right)
  {
    var prev = -1;
    var minDiff = int.MaxValue;
    var ans = new int[2];
    for (var i = left; i <= right; i++)
    {
      if (!IsPrime(i))
        continue;
      if (prev != -1)
      {
        var diff = i - prev;
        if (diff is 1 or 2)
          return [prev, i];
        if (diff < minDiff)
        {
          minDiff = diff;
          ans = [prev, i];
        }
      }
      prev = i;
    }
    return minDiff == int.MaxValue ? [-1, -1] : ans;
  }

  private static bool IsPrime(int n)
  {
    if (n < 2)
      return false;
    for (var i = 2; i * i <= n; i++)
    {
      if (n % i == 0)
        return false;
    }
    return true;
  }
}

[TestFixture]
public class Solution2Tests
{
  [TestCase(10, 19, new[] { 11, 13 })]
  [TestCase(4, 6, new[] { -1, -1 })]
  [TestCase(1, 1000000, new[] { 2, 3 })]
  public void Test(int left, int right, int[] expected)
  {
    new Solution2().ClosestPrimes(left, right).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
