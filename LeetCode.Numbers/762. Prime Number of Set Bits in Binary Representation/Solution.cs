namespace LeetCode.Numbers._762._Prime_Number_of_Set_Bits_in_Binary_Representation;

public class Solution
{
  public int CountPrimeSetBits(int left, int right)
  {
    int count = 0;
    int primes = 0b10100010100010101100;
    for (int n = left; n <= right; n++)
    {
      int k = BitOperations.PopCount((uint)n);
      count += (primes >> k) & 1;
    }
    return count;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(6, 10, 4)]
  [TestCase(10, 15, 5)]
  public void Test(int left, int right, int expected)
  {
    new Solution().CountPrimeSetBits(left, right).Should().Be(expected);
  }
}
