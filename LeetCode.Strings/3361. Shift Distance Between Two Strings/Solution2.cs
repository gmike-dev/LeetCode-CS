namespace LeetCode.Strings._3361._Shift_Distance_Between_Two_Strings;

public class Solution2
{
  public long ShiftDistance(string s, string t, int[] nextCost, int[] previousCost)
  {
    const int n = 26;
    var cost = new long[n][];
    for (var i = 0; i < n; i++)
    {
      cost[i] = new long[n];
      cost[i].AsSpan().Fill(long.MaxValue);
      cost[i][i] = 0;
      for (var j = 0; j < n - 1; j++)
      {
        cost[i][(i + j + 1) % n] = Math.Min(cost[i][(i + j + 1) % n], cost[i][(i + j) % n] + nextCost[(i + j) % n]);
        cost[i][(n + i - j - 1) % n] = Math.Min(cost[i][(n + i - j - 1) % n], cost[i][(n + i - j) % n] + previousCost[(n + i - j) % n]);
      }
    }
    var result = 0L;
    for (var i = 0; i < s.Length; i++)
      result += cost[s[i] - 'a'][t[i] - 'a'];
    return result;
  }
}

[TestFixture]
public class Solution2Tests
{
  [TestCase("abab", "baba",
    new[] { 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    new[] { 1, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 2)]
  [TestCase("leet", "code",
    new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
    new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 31)]
  [TestCase("ccdbbcaadb", "aadbbdaaac",
    new[] { 6, 6, 9, 8, 2, 4, 10, 10, 6, 4, 9, 5, 5, 5, 2, 7, 9, 7, 4, 1, 4, 10, 1, 5, 2, 4 },
    new[] { 0, 4, 5, 6, 7, 10, 5, 5, 8, 1, 1, 10, 7, 8, 10, 8, 7, 2, 3, 3, 6, 3, 0, 6, 4, 0 }, 48)]
  public void Test(string s, string t, int[] nextCost, int[] previousCost, int expected)
  {
    new Solution2().ShiftDistance(s, t, nextCost, previousCost).Should().Be(expected);
  }
}
