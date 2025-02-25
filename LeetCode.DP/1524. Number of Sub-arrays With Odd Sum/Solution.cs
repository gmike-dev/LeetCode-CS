namespace LeetCode.DP._1524._Number_of_Sub_arrays_With_Odd_Sum;

public class Solution
{
  public int NumOfSubarrays(int[] arr)
  {
    var n = arr.Length;
    Span<int> odd = stackalloc int[n + 1];
    Span<int> even = stackalloc int[n + 1];
    for (var i = 0; i < n; i++)
    {
      if (arr[i] % 2 == 0)
      {
        even[i + 1] = even[i] + 1;
        odd[i + 1] = odd[i];
      }
      else
      {
        even[i + 1] = odd[i];
        odd[i + 1] = even[i] + 1;
      }
    }
    const int mod = (int)1e9 + 7;
    var result = 0;
    foreach (var x in odd)
      result = (result + x) % mod;
    return result;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { 1, 3, 5 }, 4)]
  [TestCase(new[] { 2, 4, 6 }, 0)]
  [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7 }, 16)]
  public void Test(int[] arr, int expected)
  {
    new Solution().NumOfSubarrays(arr).Should().Be(expected);
  }
}
