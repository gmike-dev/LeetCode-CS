namespace LeetCode._316._Remove_Duplicate_Letters;

public class Solution
{
  public string RemoveDuplicateLetters(string s)
  {
    var last = new int[26];
    for (var i = 0; i < s.Length; i++)
      last[s[i] - 'a'] = i;
    var result = new List<char>();
    for (var i = 0; i < s.Length; i++)
    {
      if (!result.Contains(s[i]))
      {
        while (result.Count > 0 && result[^1] > s[i] && i < last[result[^1] - 'a'])
          result.RemoveAt(result.Count - 1);
        result.Add(s[i]);
      }
    }
    return new string(result.ToArray());
  }
}
