namespace LeetCode._1218._Longest_Arithmetic_Subsequence_of_Given_Difference;

public class Solution
{
  public int LongestSubsequence(int[] arr, int difference)
  {
    var d = new Dictionary<int, int>();
    foreach (var x in arr)
    {
      var prev = x - difference;
      d[x] = d.GetValueOrDefault(prev, 0) + 1;
    }
    return d.Values.Max();
  }
}

[TestFixture]
public class Tests
{
  [TestCase(new[] { 1, 2, 3, 4 }, 1, 4)]
  [TestCase(new[] { 1, 3, 5, 7 }, 1, 1)]
  [TestCase(new[] { 1, 3, 5, 7 }, 2, 4)]
  [TestCase(new[] { 1, 5, 7, 8, 5, 3, 4, 2, 1 }, -2, 4)]
  public void Test1(int[] arr, int difference, int expected)
  {
    new Solution().LongestSubsequence(arr, difference).Should().Be(expected);
  }
}
