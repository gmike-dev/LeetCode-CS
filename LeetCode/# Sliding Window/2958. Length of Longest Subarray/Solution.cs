namespace LeetCode.__Sliding_Window._2958._Length_of_Longest_Subarray;

public class Solution
{
  public int MaxSubarrayLength(int[] a, int k)
  {
    var freq = new Dictionary<int, int>();
    var answer = 0;
    var r = 0;
    var n = a.Length;
    for (var l = 0; l < n && r < n; l++)
    {
      while (r < n && freq.GetValueOrDefault(a[r]) + 1 <= k)
      {
        freq[a[r]] = freq.GetValueOrDefault(a[r]) + 1;
        r++;
      }
      answer = Math.Max(answer, r - l);
      freq[a[l]]--;
    }
    return answer;
  }
}

[TestFixture]
public class Tests
{
  [TestCase(new[] { 1, 2, 3, 1, 2, 3, 1, 2 }, 2, 6)]
  [TestCase(new[] { 1, 2, 1, 2, 1, 2, 1, 2 }, 1, 2)]
  [TestCase(new[] { 5, 5, 5, 5, 5, 5, 5 }, 4, 4)]
  public void Test(int[] a, int k, int expected)
  {
    new Solution().MaxSubarrayLength(a, k).Should().Be(expected);
  }
}
