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
    firstIndex.Fill(-1);
    firstIndexWith1.Fill(-1);
    firstIndexWith0.Fill(-1);
    firstIndex[zero] = 0;
    int maxLen = 0;
    for (int i = 1; i <= n; i++)
    {
      int balance = zero + 2 * prefix[i] - i;
      int rightOnes = prefix[n] - prefix[i];
      int rightZeroes = n - i - rightOnes;

      int j = firstIndex[balance];
      if (j >= 0)
      {
        maxLen = Math.Max(maxLen, i - j);
      }

      j = firstIndex[balance - 2];
      if (j >= 0)
      {
        if (rightZeroes > 0)
        {
          maxLen = Math.Max(maxLen, i - j);
        }
        else
        {
          j = firstIndexWith0[balance - 2];
          if (j >= 0)
          {
            maxLen = Math.Max(maxLen, i - j);
          }
        }
      }

      j = firstIndex[balance + 2];
      if (j >= 0)
      {
        if (rightOnes > 0)
        {
          maxLen = Math.Max(maxLen, i - j);
        }
        else
        {
          j = firstIndexWith1[balance + 2];
          if (j >= 0)
          {
            maxLen = Math.Max(maxLen, i - j);
          }
        }
      }

      if (firstIndex[balance] < 0)
      {
        firstIndex[balance] = i;
      }
      if (prefix[i] > 0 && firstIndexWith1[balance] < 0)
      {
        firstIndexWith1[balance] = i;
      }
      if (prefix[i] != i && firstIndexWith0[balance] < 0)
      {
        firstIndexWith0[balance] = i;
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
