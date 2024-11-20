namespace LeetCode.SlidingWindow._2516._Take_K_of_Each_Character_From_Left_and_Right;

public class Solution
{
  public int TakeCharacters(string s, int k)
  {
    if (k == 0)
      return 0;
    Span<int> cnt = stackalloc int[3];
    foreach (var c in s)
      cnt[c - 'a']++;
    if (cnt[0] < k || cnt[1] < k || cnt[2] < k)
      return -1;
    var n = s.Length;
    var minNumber = n;
    for (int left = 0, right = 0; right <= n; right++)
    {
      for (; left < right && (cnt[0] < k || cnt[1] < k || cnt[2] < k); left++)
        cnt[s[left] - 'a']++;
      minNumber = Math.Min(minNumber, left + n - right);
      if (right < n)
        cnt[s[right] - 'a']--;
    }
    return minNumber;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("aabaaaacaabc", 2, 8)]
  [TestCase("a", 1, -1)]
  [TestCase("abc", 1, 3)]
  [TestCase("abccba", 1, 3)]
  [TestCase("abccba", 2, 6)]
  [TestCase("a", 0, 0)]
  [TestCase("aabbccca", 2, 6)]
  public void Test(string s, int k, int expected)
  {
    new Solution().TakeCharacters(s, k).Should().Be(expected);
  }
}
