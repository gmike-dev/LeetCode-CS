namespace LeetCode.Strings._3900._Longest_Balanced_Substring_After_One_Swap;

/// <summary>
/// https://leetcode.com/problems/longest-balanced-substring-after-one-swap/
/// </summary>
public class Solution2
{
  public int LongestBalanced(string s)
  {
    int n = s.Length;
    if (n < 2)
    {
      return 0;
    }

    Span<int> prefix = stackalloc int[n + 1];
    for (int i = 0; i < n; i++)
    {
      prefix[i + 1] = prefix[i] + s[i] - '0';
    }
    if (prefix[n] == 0 || prefix[n] == n)
    {
      return 0;
    }

    int zero = n + 2;
    Span<int> firstIndex = stackalloc int[2 * zero + 1];
    Span<int> firstIndexWith1 = stackalloc int[2 * zero + 1];
    Span<int> firstIndexWith0 = stackalloc int[2 * zero + 1];
    firstIndex.Fill(int.MaxValue);
    firstIndexWith1.Fill(int.MaxValue);
    firstIndexWith0.Fill(int.MaxValue);
    firstIndex[zero] = 0;
    int maxLen = 0;
    for (int i = 1; i <= n; i++)
    {
      int balance = zero + 2 * prefix[i] - i;
      int rightOnes = prefix[n] - prefix[i];
      int rightZeroes = n - i - rightOnes;

      int j1 = firstIndex[balance];
      int j2 = rightZeroes > 0 ? firstIndex[balance - 2] : firstIndexWith0[balance - 2];
      int j3 = rightOnes > 0 ? firstIndex[balance + 2] : firstIndexWith1[balance + 2];
      int j = Math.Min(j1, Math.Min(j2, j3));
      if (j != int.MaxValue)
      {
        maxLen = Math.Max(maxLen, i - j);
      }

      firstIndex[balance] = Math.Min(firstIndex[balance], i);
      if (prefix[i] > 0)
      {
        firstIndexWith1[balance] = Math.Min(firstIndexWith1[balance], i);
      }
      if (prefix[i] != i)
      {
        firstIndexWith0[balance] = Math.Min(firstIndexWith0[balance], i);
      }
    }
    return maxLen;
  }
}

[TestFixture]
public class Solution2Tests
{
  [TestCase("100001", 4)]
  [TestCase("111", 0)]
  [TestCase("10110011000001101011111011011110010011100101101111100111000111010001011101101100", 38)]
  [TestCase("01111100", 6)]
  [TestCase("10111", 2)]
  [TestCase("10000011", 6)]
  [TestCase("01", 2)]
  [TestCase("0001000001000001100", 8)]
  public void Test(string s, int expected)
  {
    new Solution2().LongestBalanced(s).Should().Be(expected);
  }
}
