namespace LeetCode._1358._Number_of_Substrings;

public class Solution
{
  public int NumberOfSubstrings(string s)
  {
    var cnt = new int[3];
    var result = 0;
    for (int l = 0, r = 0; r < s.Length; r++)
    {
      cnt[s[r] - 'a']++;
      for (; cnt[0] > 0 && cnt[1] > 0 && cnt[2] > 0; l++)
        cnt[s[l] - 'a']--;
      result += l;
    }
    return result;
  }
}