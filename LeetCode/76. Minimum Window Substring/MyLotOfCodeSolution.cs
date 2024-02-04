using System;

namespace LeetCode._76._Minimum_Window_Substring;

public class MyLotOfCodeSolution
{
  public string MinWindow(string s, string t)
  {
    if (t.Length > s.Length)
      return "";

    var minSubstring = ReadOnlySpan<char>.Empty;
    var window = new SubstringWindow(s, t);
    while (window.MoveRightBorder())
    {
      while (window.ContainsSubstring())
      {
        if (minSubstring.IsEmpty || minSubstring.Length > window.Substring.Length)
          minSubstring = window.Substring;
        window.MoveLeftBorder();
      }
    }
    return minSubstring.ToString();
  }

  private class SubstringWindow
  {
    private readonly string s;
    private readonly int[] charDiff = new int[128];

    private int left;
    private int right;
    private int diff;

    public ReadOnlySpan<char> Substring => s.AsSpan(left, right - left);

    public bool ContainsSubstring()
    {
      return diff == 0;
    }

    public bool MoveRightBorder()
    {
      if (right >= s.Length)
        return false;
      if (charDiff[s[right]] > 0)
        diff--;
      charDiff[s[right]]--;
      right++;
      return true;
    }

    public void MoveLeftBorder()
    {
      if (left >= right)
        return;
      if (charDiff[s[left]] >= 0)
        diff++;
      charDiff[s[left]]++;
      left++;
    }

    public SubstringWindow(string s, string t)
    {
      this.s = s;
      foreach (var c in t)
        charDiff[c]++;
      diff = t.Length;
    }
  }
}
