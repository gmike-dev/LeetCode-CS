namespace LeetCode.Numbers._1922._Count_Good_Numbers;

public class BinPowSolution
{
  public int CountGoodNumbers(long n)
  {
    const long mod = (long)1e9 + 7;
    var evenCount = (n + 1) / 2;
    var oddCount = n - evenCount;
    return (int)(BinPow(5, evenCount, mod) * BinPow(4, oddCount, mod) % mod);
  }

  private static long BinPow(long n, long pow, long mod)
  {
    long result = 1;
    while (pow != 0)
    {
      if (pow % 2 != 0)
        result = result * n % mod;
      n = n * n % mod;
      pow /= 2;
    }
    return result;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(1, 5)]
  [TestCase(4, 400)]
  [TestCase(50, 564908303)]
  [TestCase(806166225460393, 643535977)]
  public void Test(long n, int expected)
  {
    new BinPowSolution().CountGoodNumbers(n).Should().Be(expected);
  }
}
