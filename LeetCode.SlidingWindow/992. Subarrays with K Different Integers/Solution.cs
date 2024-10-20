namespace LeetCode.SlidingWindow._992._Subarrays_with_K_Different_Integers;

public class Solution
{
  public int SubarraysWithKDistinct(int[] a, int k)
  {
    var freq = new int[20001];
    var uniqCount = 0;
    var answer = 0;
    var left1 = 0;
    var left2 = 0;
    for (var right = 0; right < a.Length; right++)
    {
      if (freq[a[right]]++ == 0)
        uniqCount++;
      if (uniqCount < k)
        continue;
      if (uniqCount > k)
      {
        freq[a[left2]]--;
        uniqCount--;
        left2++;
        left1 = left2;
      }
      while (freq[a[left2]] > 1)
      {
        freq[a[left2]]--;
        left2++;
      }
      answer += left2 - left1 + 1;
    }
    return answer;
  }
}

[TestFixture]
public class Tests
{
  [TestCase(new[] { 1, 2, 1, 2, 3 }, 2, 7)]
  [TestCase(new[] { 1, 2, 1, 3, 4 }, 3, 3)]
  [TestCase(new[] { 1 }, 1, 1)]
  [TestCase(new[] { 1, 2 }, 1, 2)]
  [TestCase(new[] { 2, 1, 1, 1, 2 }, 1, 8)]
  public void Test(int[] a, int k, int expected)
  {
    new Solution().SubarraysWithKDistinct(a, k).Should().Be(expected);
  }
}
