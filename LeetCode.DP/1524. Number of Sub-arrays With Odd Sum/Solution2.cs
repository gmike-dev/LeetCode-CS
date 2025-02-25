namespace LeetCode.DP._1524._Number_of_Sub_arrays_With_Odd_Sum;

public class Solution2
{
  public int NumOfSubarrays(int[] arr)
  {
    const int mod = (int)1e9 + 7;
    var odd = 0;
    var even = 0;
    var result = 0;
    foreach (var x in arr)
    {
      if (x % 2 == 0)
        even++;
      else
        (even, odd) = (odd, even + 1);
      result = (result + odd) % mod;
    }
    return result;
  }
}

[TestFixture]
public class Solution2Tests
{
  [TestCase(new[] { 1, 3, 5 }, 4)]
  [TestCase(new[] { 2, 4, 6 }, 0)]
  [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7 }, 16)]
  public void Test(int[] arr, int expected)
  {
    new Solution2().NumOfSubarrays(arr).Should().Be(expected);
  }
}
