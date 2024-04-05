namespace LeetCode._3._Longest_Substring_Without_Repeating_Characters;

public class Solution
{
  public int LengthOfLongestSubstring(string s)
  {
    var used = new Dictionary<char, int>();
    var length = 0;
    for (int i = 0, j = 0; j < s.Length; j++)
    {
      if (used.TryGetValue(s[j], out var index))
      {
        length = Math.Max(length, used.Count);
        for (; i <= index; i++)
          used.Remove(s[i]);
      }
      used.Add(s[j], j);
    }
    length = Math.Max(length, used.Count);
    return length;
  }
}
