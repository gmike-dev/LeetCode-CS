namespace LeetCode.Numbers._2523._Closest_Prime_Numbers_in_Range;

public class Solution3
{
  public int[] ClosestPrimes(int left, int right)
  {
    if (right > 2 && left < 3)
      return [2, 3];
    var prev = -1;
    var minDiff = int.MaxValue;
    int[] ans = [-1, -1];
    var i = left % 2 == 0 ? left + 1 : left; // iterate over odd numbers
    while (i <= right)
    {
      if (IsPrime(i))
      {
        if (prev != -1)
        {
          var diff = i - prev;
          if (diff == 2)
            return [prev, i];
          if (diff < minDiff)
          {
            minDiff = diff;
            ans[0] = prev;
            ans[1] = i;
          }
        }
        prev = i;
      }
      i += 2; // iterate over odd numbers
    }
    return ans;
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
public class Solution3Tests
{
  [TestCase(10, 19, new[] { 11, 13 })]
  [TestCase(4, 6, new[] { -1, -1 })]
  [TestCase(1, 1000000, new[] { 2, 3 })]
  [TestCase(2, 1000000, new[] { 2, 3 })]
  [TestCase(3, 1000000, new[] { 3, 5 })]
  public void Test(int left, int right, int[] expected)
  {
    new Solution3().ClosestPrimes(left, right).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
