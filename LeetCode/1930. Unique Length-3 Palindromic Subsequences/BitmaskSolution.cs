namespace LeetCode._1930._Unique_Length_3_Palindromic_Subsequences;

public class BitmasksSolution
{
  public int CountPalindromicSubsequence(string s)
  {
    var left = 1 << (s[0] - 'a');
    var right = 0;
    var rightCount = new int[26];
    for (var i = 1; i < s.Length; i++)
    {
      var c = s[i] - 'a';
      right |= 1 << c;
      rightCount[c]++;
    }
    var counter = new int[26];
    for (var i = 1; i < s.Length - 1; i++)
    {
      var c = s[i] - 'a';
      rightCount[c]--;
      if (rightCount[c] == 0)
        right &= ~(1 << c);
      counter[c] |= left & right;
      left |= 1 << c;
    }
    var count = 0;
    for (var i = 0; i < 26; i++)
      count += BitOperations.PopCount((uint)counter[i]);
    return count;
  }
}
