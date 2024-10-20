namespace LeetCode.Numbers._1497._Check_If_Array_Pairs_Are_Divisible_by_k;

public class Solution
{
  public bool CanArrange(int[] arr, int k)
  {
    var s = new Dictionary<int, int>();
    foreach (var x in arr)
    {
      var mod = (x % k + k) % k;
      s[mod] = s.GetValueOrDefault(mod) + 1;
    }
    foreach (var x in arr)
    {
      var mod = (x % k + k) % k;
      if (s[mod] > 0)
      {
        s[mod]--;
        if (s.GetValueOrDefault((k - mod) % k) == 0)
          return false;
        s[(k - mod) % k]--;
      }
    }
    return true;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { 1, 2, 3, 4, 5, 10, 6, 7, 8, 9 }, 5, true)]
  [TestCase(new[] { 1, 2, 3, 4, 5, 6 }, 7, true)]
  [TestCase(new[] { 1, 2, 3, 4, 5, 6 }, 10, false)]
  [TestCase(new[] { -1, 1, -2, 2, -3, 3, -4, 4 }, 3, true)]
  public void Test(int[] arr, int k, bool expected)
  {
    new Solution().CanArrange(arr, k).Should().Be(expected);
  }
}
