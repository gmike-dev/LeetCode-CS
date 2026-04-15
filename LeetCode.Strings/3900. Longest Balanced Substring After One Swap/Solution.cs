namespace LeetCode.Strings._3900._Longest_Balanced_Substring_After_One_Swap;

/// <summary>
/// https://leetcode.com/problems/longest-balanced-substring-after-one-swap/
/// </summary>
public class Solution
{
  public int LongestBalanced(string s)
  {
    int n = s.Length;
    if (n < 2)
    {
      return 0;
    }

    int[] prefix = new int[n + 1];
    for (int i = 0; i < n; i++)
    {
      prefix[i + 1] = prefix[i] + s[i] - '0';
    }

    int rightOnes = prefix[n];
    int rightZeroes = n - rightOnes;

    if (rightOnes == 0 || rightZeroes == 0)
    {
      return 0;
    }

    Dictionary<int, int> firstIndex = new();
    Dictionary<int, int> firstIndexWith1 = new();
    Dictionary<int, int> firstIndexWith0 = new();
    firstIndex[0] = -1;
    int balance = 0;
    int maxLen = 0;
    for (int i = 0; i < n; i++)
    {
      if (s[i] == '0')
      {
        rightZeroes--;
        balance--;
      }
      else
      {
        rightOnes--;
        balance++;
      }
      if (firstIndex.TryGetValue(balance, out int j))
      {
        maxLen = Math.Max(maxLen, i - j);
      }
      if (firstIndex.TryGetValue(balance - 2, out j) &&
          (rightZeroes > 0 || firstIndexWith0.TryGetValue(balance - 2, out j)))
      {
        maxLen = Math.Max(maxLen, i - j);
      }
      if (firstIndex.TryGetValue(balance + 2, out j) &&
          (rightOnes > 0 || firstIndexWith1.TryGetValue(balance + 2, out j)))
      {
        maxLen = Math.Max(maxLen, i - j);
      }
      firstIndex.TryAdd(balance, i);
      int leftOnes = prefix[i + 1];
      if (leftOnes > 0)
      {
        firstIndexWith1.TryAdd(balance, i);
      }
      if (leftOnes != i + 1)
      {
        firstIndexWith0.TryAdd(balance, i);
      }
    }
    return maxLen;
  }
}

[TestFixture]
public class SolutionTests
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
    new Solution().LongestBalanced(s).Should().Be(expected);
  }
}
