using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.__Sliding_Window._3101._Count_Alternating_Subarrays;

public class Solution
{
  public long CountAlternatingSubarrays(int[] a)
  {
    var n = a.Length;
    long answer = n;
    var left = 0;
    for (var right = 1; right < n; right++)
    {
      if (a[right - 1] == a[right])
        left = right;
      else
        answer += right - left;
    }
    return answer;
  }
}

[TestFixture]
public class Tests
{
  [TestCase(new[] { 0, 1, 1, 1 }, 5)]
  [TestCase(new[] { 1, 0, 1, 0 }, 10)]
  public void Test(int[] a, long expected)
  {
    new Solution().CountAlternatingSubarrays(a).Should().Be(expected);
  }
}
