namespace LeetCode.__Sliding_Window._76._Minimum_Window_Substring;

public class ShortButTrickySolution
{
  public string MinWindow(string s, string t)
  {
    if (s.Length < t.Length)
      return "";

    var tc = new int[128];
    foreach (var c in t)
      tc[c]++;

    var count = t.Length;
    var start = 0;
    var end = 0;
    var minLen = int.MaxValue;
    var startIndex = 0;
    while (end < s.Length)
    {
      if (tc[s[end]] > 0)
        count--;
      tc[s[end]]--;
      end++;
      while (count == 0)
      {
        var len = end - start;
        if (len < minLen)
        {
          minLen = len;
          startIndex = start;
        }
        if (tc[s[start]] == 0)
          count++;
        tc[s[start]]++;
        start++;
      }
    }
    return minLen == int.MaxValue ? "" : s.Substring(startIndex, minLen);
  }
}
