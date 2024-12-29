namespace LeetCode.DP._1639._Number_of_Ways_to_Form_a_Target_String_Given_a_Dictionary;

public class Solution
{
  public int NumWays(string[] words, string target)
  {
    var n = words[0].Length;
    var m = target.Length;
    if (n < m)
      return 0;
    var dp = new int[n][];
    for (var i = 0; i < n; i++)
    {
      dp[i] = new int[m];
      dp[i].AsSpan().Fill(-1);
    }
    var cnt = new int[n, 26];
    foreach (var w in words)
    {
      for (var i = 0; i < n; i++)
        cnt[i, w[i] - 'a']++;
    }
    return F(0, 0);

    int F(int pos, int targetPos)
    {
      if (targetPos == m)
        return 1;
      if (pos == n || n - pos < m - targetPos)
        return 0;
      if (dp[pos][targetPos] != -1)
        return dp[pos][targetPos];
      long result = F(pos + 1, targetPos);
      var k = cnt[pos, target[targetPos] - 'a'];
      if (k != 0)
        result += (long)k * F(pos + 1, targetPos + 1);
      return dp[pos][targetPos] = (int)(result % 1000000007);
    }
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { "acca", "bbbb", "caca" }, "aba", 6)]
  [TestCase(new[] { "abba", "baab" }, "bab", 4)]
  [TestCase(new[] { "daa", "bcc", "ddb", "bbd" }, "ba", 5)]
  [TestCase(
    new[]
    {
      "cbabddddbc", "addbaacbbd", "cccbacdccd", "cdcaccacac", "dddbacabbd", "bdbdadbccb", "ddadbacddd", "bbccdddadd",
      "dcabaccbbd", "ddddcddadc", "bdcaaaabdd", "adacdcdcdd", "cbaaadbdbb", "bccbabcbab", "accbdccadd", "dcccaaddbc",
      "cccccacabd", "acacdbcbbc", "dbbdbaccca", "bdbddbddda", "daabadbacb", "baccdbaada", "ccbabaabcb", "dcaabccbbb",
      "bcadddaacc", "acddbbdccb", "adbddbadab", "dbbcdcbcdd", "ddbabbadbb", "bccbcbbbab", "dabbbdbbcb", "dacdabadbb",
      "addcbbabab", "bcbbccadda", "abbcacadac", "ccdadcaada", "bcacdbccdb"
    }, "bcbbcccc", 677452090)]
  [TestCase(
    new[]
    {
      "cabbaacaaaccaabbbbaccacbabbbcb", "bbcabcbcccbcacbbbaacacaaabbbac", "cbabcaacbcaaabbcbaabaababbacbc",
      "aacabbbcaaccaabbaccacabccaacca", "bbabbaabcaabccbbabccaaccbabcab", "bcaccbbaaccaabcbabbacaccbbcbbb",
      "cbbcbcaaaacacabbbabacbaabbabaa", "cbbbbbbcccbabbacacacacccbbccca", "bcbccbccacccacaababcbcbbacbbbc",
      "ccacaabaaabbbacacbacbaaacbcaca", "bacaaaabaabccbcbbaacacccabbbcb", "bcbcbcabbccabacbcbcaccacbcaaab",
      "babbbcccbbbbbaabbbacbbaabaabcc", "baaaacaaacbbaacccababbaacccbcb", "babbaaabaaccaabacbbbacbcbababa",
      "cbacacbacaaacbaaaabacbbccccaca", "bcbcaccaabacaacaaaccaabbcacaaa", "cccbabccaabbcbccbbabaaacbacaaa",
      "bbbcabacbbcabcbcaaccbcacacccca", "ccccbbaababacbabcaacabaccbabaa", "caaabccbcaaccabbcbcaacccbcacba",
      "cccbcaacbabaacbaaabbbbcbbbbcbb", "cababbcacbabcbaababcbcabbaabba", "aaaacacaaccbacacbbbbccaabcccca",
      "cbcaaaaabacbacaccbcbcbccaabaac", "bcbbccbabaccabcccacbbaacbbcbba", "cccbabbbcbbabccbbabbbbcaaccaab",
      "acccacccaabbcaccbcaaccbababacc", "bcacabaacccbbcbbacabbbbbcaaaab", "cacccaacbcbccbabccabbcbabbcacc",
      "aacabbabcaacbaaacaabcabcaccaab", "cccacabacbabccbccaaaaabbcacbcc", "cabaacacacaaabaacaabababccbaaa",
      "caabaccaacccbaabcacbcbbabccabc", "bcbbccbbaaacbaacbccbcbababcacb", "bbabbcabcbbcababbbbccabaaccbca",
      "cacbbbccabaaaaccacbcbabaabbcba", "ccbcacbabababbbcbcabbcccaccbca", "acccabcacbcbbcbccaccaacbabcaab",
      "ccacaabcbbaabaaccbabcbacaaabaa", "cbabbbbcabbbbcbccabaabccaccaca", "acbbbbbccabacabcbbabcaacbbaacc",
      "baaababbcabcacbbcbabacbcbaaabc", "cabbcabcbbacaaaaacbcbbcacaccac"
    }, "acbaccacbbaaabbbabac", 555996654)]
  public void Test(string[] words, string target, int expected)
  {
    new Solution().NumWays(words, target).Should().Be(expected);
  }
}
