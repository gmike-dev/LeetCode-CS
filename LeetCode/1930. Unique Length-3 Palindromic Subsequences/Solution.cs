namespace LeetCode._1930._Unique_Length_3_Palindromic_Subsequences;

public class Solution
{
  public int CountPalindromicSubsequence(string s)
  {
    var left = new int[26];
    var right = new int[26];
    left[s[0] - 'a'] = 1;
    for (var i = 1; i < s.Length; i++)
      right[s[i] - 'a']++;
    var counter = new int[26];
    for (var i = 1; i < s.Length - 1; i++)
    {
      var c = s[i] - 'a';
      right[c]--;
      for (var j = 0; j < 26; j++)
        if (left[j] > 0 && right[j] > 0)
          counter[c] |= 1 << j;
      left[c]++;
    }
    return counter.Sum(x => BitOperations.PopCount((uint)x));
  }
}
