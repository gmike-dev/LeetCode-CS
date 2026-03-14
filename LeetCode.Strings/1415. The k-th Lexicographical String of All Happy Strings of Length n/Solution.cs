namespace LeetCode.Strings._1415._The_k_th_Lexicographical_String_of_All_Happy_Strings_of_Length_n;

/// <summary>
/// https://leetcode.com/problems/the-k-th-lexicographical-string-of-all-happy-strings-of-length-n/
/// </summary>
public class Solution
{
  public string GetHappyString(int n, int k)
  {
    var s = new char[n];
    return Backtrack(0, '\0') ? new string(s) : "";

    bool Backtrack(int pos, char prev)
    {
      if (pos == n)
      {
        k--;
        return k == 0;
      }
      for (var c = 'a'; c <= 'c'; c++)
      {
        if (prev != c)
        {
          s[pos] = c;
          if (Backtrack(pos + 1, c))
          {
            return true;
          }
        }
      }
      return false;
    }
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(1, 3, "c")]
  [TestCase(1, 4, "")]
  [TestCase(3, 9, "cab")]
  public void Test(int n, int k, string expected)
  {
    new Solution().GetHappyString(n, k).Should().Be(expected);
  }
}
